using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ChessDraw;
using ChessAI;
using ChessAI.pieces;


namespace Chessy1._0
{
    public partial class doubleForm : Form
    {

        Board board = new Board();
        Draw draw = null;
        Piece pieceSelected = null;
        List<Move> AllMoves = new List<Move>();
        int xSelected = 0, ySelected = 2;
        Move lastWhiteMove = null, lastBlackMove = null;

        bool turn = Piece.WHITE;

        bool win = false;
        static string soundPath = @"..\..\..\Resources\棋类.wav";
        SoundPlayer bgm = new SoundPlayer(soundPath);

        public doubleForm()
        {
            InitializeComponent();
            draw = new Draw(boardImage, board, turn);
            label2.Text = turn ? "白棋" : "黑棋";
        }
        private void Play(object sender, MouseEventArgs e)
        {
            if (win)
            {
                MessageBox.Show("本场游戏已结束");
                return;
            }
            int x = (int)((double)((e.X - boardImage.Size.Width / 34.0) / (boardImage.Size.Width / 8.5)));
            int y = (int)((double)((e.Y - boardImage.Size.Height / 34.0) / (boardImage.Size.Height / 8.5)));
            y = 7 - y;

            // 若未选择棋子。
            if (pieceSelected == null)
            {
                pieceSelected = board.GetTile(x, y).GetPiece();
                // （x, y)处有棋子，并且为本方棋子。
                if (pieceSelected != null &&
                    pieceSelected.Color == turn)
                {
                    if (AllMoves.Count > 1)
                        draw.KillHighLight(AllMoves[AllMoves.Count - 2]);
                    draw.KillHighLight(xSelected, ySelected);
                    // 在(x, y)处添加高亮。
                    draw.DrawHighLight(x, y);
                    // 添加提示，显示(x, y)处棋子所有合法移动，
                    draw.DrawHint(pieceSelected, x, y);

                    xSelected = x;
                    ySelected = y;
                }
                else pieceSelected = null;
            }
            else
            {
                draw.KillHint();

                // 创建move对象，表示用户想将（xSelected, ySelected）处的棋子
                // 移动到（x, y）处。
                Move move = new Move(xSelected, ySelected, x, y);
                // 调用方法GetMoves()获取（xSelected, ySelected）处的棋子所有合法移动。
                List<Move> moves = pieceSelected.GetMoves(board, xSelected, ySelected);

                foreach (Move mve in moves)
                {
                    // 如果用户的移动合法。
                    if (move.Equals(mve))
                    {
                        if (CheckWinner(move.GetX2(), move.GetY2(), !turn))
                            win = true;
                        // 在棋盘中更新move所代表的移动。
                        board.MakeMove(move);
                        // 画出这一步移动。
                        draw.DrawMove(move);
                        Thread Bgmthread = new Thread(bgm.Play);
                        Bgmthread.Start();
                        AllMoves.Add(move);
                        if (win)
                        {
                            if (turn)
                                MessageBox.Show("白棋胜利！");
                            else
                                MessageBox.Show("黑棋胜利！");
                        }
                        if (turn)
                            lastWhiteMove = move;
                        else
                            lastBlackMove = move;

                        turn = !turn;
                        label2.Text = turn ? "白棋" : "黑棋";

                        break;
                    }
                }

                pieceSelected = null;
            }
        }
        // 如果有残局，复原棋盘
        private void RecoverBoard()
        {
            try
            {
                StreamReader streamReader = new StreamReader("board2.txt");
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    int[] temp = new int[4];
                    string[] numstr = line.Split(" ");
                    for (int i = 0; i < 4; i++)
                        temp[i] = Convert.ToInt32(numstr[i]);
                    AllMoves.Add(new Move(temp[0], temp[1], temp[2], temp[3]));
                }
                foreach (Move move in AllMoves)
                    board.MakeMove(move);

                draw.ReDraw(board);
                streamReader.Close();

            }
            catch (FileNotFoundException)
            {
                // pass
            }
        }


        // 退出
        private void b_out_Click(object sender, EventArgs e)
        {
            if (win)
            {
                this.Close();
                return;
            }
            FileStream F = new FileStream("board2.txt",
           FileMode.OpenOrCreate, FileAccess.ReadWrite);
            string strMove = "";
            foreach (Move move in AllMoves)
            {
                strMove += move.GetX1() + " " + move.GetY1() + " ";
                strMove += move.GetX2() + " " + move.GetY2() + "\n";
                byte[] bytes = Encoding.UTF8.GetBytes(strMove);
                F.Write(bytes, 0, bytes.Length);
                strMove = "";
            }
            F.Close();
            this.Close();
        }
        private void b_reverse_Click(object sender, EventArgs e)
        {
            if (win)
            {
                MessageBox.Show("本场游戏已结束");
                return;
            }
            if (AllMoves.Count >= 1)
            {
                AllMoves.RemoveRange(AllMoves.Count - 1, 1);
                board = new Board();
                foreach (Move move in AllMoves)
                    board.MakeMove(move);
                draw.ReDraw(board);
            }
        }

        private void doubleForm_Load(object sender, EventArgs e)
        {
            // 当前目录
            DirectoryInfo dir = new DirectoryInfo(@".");
            FileSystemInfo[] fileInfos = dir.GetFileSystemInfos();
            foreach (FileSystemInfo fileInfo in fileInfos)
            {
                // 存在残局。
                if (fileInfo.Name == "board2.txt")
                {
                    var re = MessageBox.Show("是否继续未完成棋局？", " ", MessageBoxButtons.OKCancel);
                    // 询问用户是否继续
                    // yes
                    if (re == DialogResult.OK)
                        RecoverBoard();
                    // no 
                    File.Delete(fileInfo.FullName);
                    break;
                }
            }
        }

        private void doubleForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            this.Owner.Show();
        }

        private void boardImage_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void help_Click(object sender, EventArgs e)
        { 
            ruleForm rule = new ruleForm();
            rule.Show();
        }

        private bool CheckWinner(int Tox, int Toy, bool killcolor)
        {
            if (board.KingKilled(Tox, Toy, killcolor))
                return true;
            return false;
        }
        private void rank_Click(object sender, EventArgs e)
        {
            rankForm f = new rankForm();
            f.Owner = this;
            f.Show();
        }
    }
}
