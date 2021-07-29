using System;
using System.Threading;
using System.Media;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using ChessAI;
using ChessAI.pieces;
using ChessAI.player;
using ChessDraw;

namespace Chessy1._0
{
    public partial class singleForm : Form
    {
        Board board = new Board();
        // 玩家为黑棋。
        Player AIPlayer = new AlphaBetaPlayer(Piece.BLACK, 2);

        List<Move> AllMoves = new List<Move>();
        Move AImove = null;
        // 被选中的棋子
        Piece pieceSelected = null;
        Draw draw;
        int winner = 0;
        bool turn = true;
        bool localPlayerColor = Piece.WHITE;
        bool win;
        int xSelected = 0, ySelected = 2;
        int xTo, yTo;

        defeatForm Defeat = new defeatForm();
        vitoryForm Vitory = new vitoryForm();

        static string soundPath = @"..\..\..\Resources\棋类.wav";
        SoundPlayer bgm = new SoundPlayer(soundPath);

        public singleForm()
        {
            InitializeComponent();
            label4.Text = null;
            label5.Text = null;
            label6.Text = null;
            if (mainForm.NetCheck)
            {
                InformShow();
            }
            else
            {
                label1.Text = null;
                label2.Text = "Unconnected...";
                label3.Text = null;
            }
            draw = new Draw(boardImage, board, localPlayerColor);
        }
        public void InformShow()
        {
            label4.Text = mainForm.cli1.id;
            label5.Text = Convert.ToString(mainForm.cli1.score);
            label6.Text = Convert.ToString(mainForm.cli1.myRank());
        }

        //关闭时打开主窗口
        public void Play(object sender, MouseEventArgs e)
        {
            if (win)
            {
                MessageBox.Show("本场游戏已结束");
                return;
            }
            if (!turn)
            {
                MessageBox.Show("对方正在下棋！");
                return;
            }
            // 获取鼠标点击坐标，并转换成棋盘数组坐标。
            // 17 和 78 分别是Form2 中大小为640×640的棋盘图片的
            // 边框尺寸和每个格子的尺寸。
            int x = (int)((double)((e.X - boardImage.Size.Width / 34.0) / (boardImage.Size.Width / 8.5)));
            int y = (int)((double)((e.Y - boardImage.Size.Height / 34.0) / (boardImage.Size.Height / 8.5)));
            if (localPlayerColor)
                y = 7 - y;
            // 若未选择棋子。
            if (pieceSelected == null)
            {
                pieceSelected = board.GetTile(x, y).GetPiece();
                // （x, y)处有棋子，并且为本方棋子。
                if (pieceSelected != null &&
                    pieceSelected.Color == localPlayerColor)
                {
                    // 删除上一次的高亮。
                    draw.KillHighLight(xSelected, ySelected);
                    draw.KillHighLight(xTo, yTo);
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
                        if (board.KingKilled(x, y, !localPlayerColor))
                        {
                            mainForm.cli1.score += 20;
                            win = true;
                        }
                        // 在棋盘中更新move所代表的移动。
                        winner = board.MakeMove(move);
                        //播放音乐
                        // 画出这一步移动。
                        draw.DrawMove(move);
                        Thread Bgmthread = new Thread(bgm.Play);
                        Bgmthread.Start();
                        AllMoves.Add(move);
                        // 如果这一步棋之后本方未获胜。
                        if (!win)
                        {
                            xTo = x;
                            yTo = y;
                            draw.KillHighLight(AImove);
                            AIPlay();
                        }
                        else
                        {
                            Vitory.Show();
                        }
                        break;
                    }
                }

                // 重置。
                pieceSelected = null;
            }

        }
        private void help_Click(object sender, EventArgs e)
        {
            ruleForm rule = new ruleForm();
            rule.Show();
        }

        private void singleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (win == true)
                if (mainForm.NetCheck)
                    mainForm.cli1.upDateScore();
            this.Owner.Show();
        }

        private void mainForm_Click(object sender, EventArgs e)
        {
            if (win)
            {
                this.Close();
                return;
            }
            FileStream F = new FileStream("board.txt",
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

        private void rank_Click(object sender, EventArgs e)
        {
            rankForm f = new rankForm();
            f.Owner = this;
            f.Show();
        }



        private void AIPlay()
        {
            Move move = AIPlayer.GetNextMove(board);
            if (move != null)
            {
                winner = board.MakeMove(move);
                draw.DrawMove(move);
                bgm.Play();
                AICheckWinner(move.GetX2(), move.GetY2(), localPlayerColor);
                // 保存AI这一步移动。
                AllMoves.Add(move);
                AImove = move;
            }
        }

        private void withdraw_Click(object sender, EventArgs e)
        {
            if (win)
            {
                MessageBox.Show("本场游戏已结束");
                return;
            }
            if (AllMoves.Count >= 2)
            {
                AllMoves.RemoveRange(AllMoves.Count - 2, 2);
                board = new Board();
                foreach (Move move in AllMoves)
                    board.MakeMove(move);
                draw.ReDraw(board);
            }
        }

        private void singleForm_Load(object sender, EventArgs e)
        {
            // 当前目录
            DirectoryInfo dir = new DirectoryInfo(@".");
            FileSystemInfo[] fileInfos = dir.GetFileSystemInfos();
            foreach (FileSystemInfo fileInfo in fileInfos)
            {
                // 存在残局。
                if (fileInfo.Name == "board.txt")
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
        private bool AICheckWinner(int Tox, int Toy, Boolean killcolor)
        {
            Move move = AIPlayer.GetNextMove(board);
            if (board.IsCheck(localPlayerColor))//白棋无路可走且被将军
            {
                vitoryForm vitory = new vitoryForm();
                defeatForm defeat = new defeatForm();
                
                if (board.KingKilled(move.GetX2(), move.GetY2(), localPlayerColor))
                    defeat.Show();
                else
                {
                    MessageBox.Show("将军！");
                    return false;
                }
                if (mainForm.NetCheck)
                {
                    mainForm.cli1.score -= 20;
                }
                win = true;
                return true;
            }
            return false;
        }
        private void RecoverBoard()
        {
            try
            {
                StreamReader streamReader = new StreamReader("board.txt");
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


    }
}
