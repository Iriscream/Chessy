using System;
using System.Windows.Forms;
using ChessAI;
using System.Media;
using ChessAI.pieces;
using ChessAI.player;
using ChessDraw;
using System.Collections.Generic;
using System.Threading;

namespace Chessy1._0
{
    public partial class onlineForm : Form
    {
        bool localPlayerColor;
        Board board = new Board();
        Draw draw = null;
        Piece pieceSelected = null;
        List<Move> AllMoves = new List<Move>();
        int xSelected = 0, ySelected = 2;
        int xTo, yTo;
        Move remoteMove = null, lastMove = null;
        bool turn = false;
        Thread RemoteThread;
        public static bool live = false;

        private delegate void DrawRemote();

        private int winner = 0;
        static string soundPath = @"..\..\..\Resources\棋类.wav";
        SoundPlayer bgm = new SoundPlayer(soundPath);

        defeatForm Defeat = new defeatForm();
        vitoryForm Vitory = new vitoryForm();
        public onlineForm()
        {
            InitializeComponent();

            if (!mainForm.cli1.Idread)
            {
                MessageBox.Show("请先登陆或注册！");
                label4.Text = null;
                label5.Text = "未登录...";
                label6.Text = null;
                label10.Text = null;
                label11.Text = "未登录....";
                label12.Text = null;
            }
            else
            {
                if (mainForm.cli1.BegiNetGame() == "FIRST")
                {
                    turn = true;
                    localPlayerColor = Piece.WHITE;
                }
                else
                    localPlayerColor = Piece.BLACK;

                //准备联机
                mainForm.cli1.enemyInform();
                ShowInform();
                live = true;
                //获取对手信息
                draw = new Draw(boardImage, board, localPlayerColor);

                if (localPlayerColor == Piece.WHITE)
                    mainForm.cli1.Receive_Ser();//首先获取信息
            }
        }
        public void ShowInform()
        {
            if (localPlayerColor)
            {
                label4.Text = mainForm.cli1.id;
                label5.Text = Convert.ToString(mainForm.cli1.score);
                label6.Text = Convert.ToString(mainForm.cli1.rank);
                label10.Text = mainForm.cli1.enplayer.id;
                label11.Text = Convert.ToString(mainForm.cli1.enplayer.score);
                label12.Text = Convert.ToString(mainForm.cli1.enplayer.rankNum);
            }
            else
            {
                label10.Text = mainForm.cli1.id;
                label11.Text = Convert.ToString(mainForm.cli1.score);
                label12.Text = Convert.ToString(mainForm.cli1.rank);
                label4.Text = mainForm.cli1.enplayer.id;
                label5.Text = Convert.ToString(mainForm.cli1.enplayer.score);
                label6.Text = Convert.ToString(mainForm.cli1.enplayer.rankNum);
            }
        }

        public void Play(object sender, MouseEventArgs e)
        {
            if (winner != 0)
            {
                MessageBox.Show("本场游戏已结束！");
                return;
            }
            if (!turn)
            {
                MessageBox.Show("对方正在下棋！");
                return;
            }
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
                        winner = CheckWinner(move.GetX2(), move.GetY2(), !localPlayerColor);
                        // 在棋盘中更新move所代表的移动。
                        board.MakeMove(move);
                        // 画出这一步移动。
                        draw.DrawMove(move);
                        Thread Bgmthread = new Thread(bgm.Play);
                        Bgmthread.Start();
                        AllMoves.Add(move);
                        int[] tmp = new int[4]
                        {
                            7 - move.GetX1(), move.GetY1(),
                            7 - move.GetX2(), move.GetY2()
                        };

                        //发送我这一步的信息
                        mainForm.cli1.SendGameInfor(tmp);
                        // 如果这一步棋之后本方未获胜。
                        if (winner == 0)
                        {
                            xTo = x;
                            yTo = y;
                            turn = !turn;
                            RemoteThread = new Thread(RemotePlayerPlay);
                            RemoteThread.Start();
                            break;
                        }
                        if (winner == 1)
                            Vitory.Show();
                        else
                            Defeat.Show();

                    }
                }

                // 重置。
                pieceSelected = null;
            }
        }

        private void onlineForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (live)
            {
                mainForm.cli1.SendToSer("OUT");
                mainForm.cli1.Receive_Ser();
            }
            if (winner == 1)
                mainForm.cli1.score += 20;
            else if (winner == -1)
                mainForm.cli1.score -= 20;
            if (winner == 0)
                mainForm.cli1.upDateScore();
            this.Owner.Show();
        }

        private void onlineForm_Shown(object sender, EventArgs e)
        {
            if (mainForm.cli1.Idread && localPlayerColor == Piece.BLACK)//后下棋
            {
                RemoteThread = new Thread(RemotePlayerPlay);
                RemoteThread.Start();//等待对方下棋
            }
        }
        //排名
        private void rank_Click(object sender, EventArgs e)
        {
            rankForm f = new rankForm();
            f.Owner = this;
            f.Show();
        }

        //撤销按钮
        private void withDraw_Click(object sender, EventArgs e)//请求撤销
        {
            if (winner != 0)
            {
                MessageBox.Show("本场游戏已结束！");
                return;
            }
            if (AllMoves.Count >= 2)
            {
                mainForm.cli1.SendToSer("RESERVE");
                if (mainForm.cli1.Rec_Check())
                {
                    AllMoves.RemoveRange(AllMoves.Count - 2, 2);
                    board = new Board();
                    foreach (Move move in AllMoves)
                        board.MakeMove(move);
                    draw.ReDraw(board);
                }
                else
                {
                    MessageBox.Show("对方拒绝撤销您的上一步！");
                }
            }
            else
            {
                MessageBox.Show("您现在无法撤回您的上一步！");
            }
        }

        private void Out_Click(object sender, EventArgs e)
        {
            if (winner != 0)
            {
                MessageBox.Show("本场游戏已结束！");
                return;
            }
            if (live)
            {
                mainForm.cli1.SendToSer("OUT");
                mainForm.cli1.Receive_Ser();
            }
            else
            {
                MessageBox.Show("游戏已结束");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
                ruleForm rule = new ruleForm();
                rule.Show();
            
        }

        private void RemotePlayerPlay(object obj)
        {
            string msg = mainForm.cli1.Receive_Ser();
            if (msg == "OUT")
            {
                MessageBox.Show("对方已投降或已退出游戏！");
                mainForm.cli1.SendToSer("OUT");
                mainForm.cli1.Receive_Ser();
                live = false;
                remoteMove = null;
            }
            else if (msg == "RESERVE")//对面请求撤销上一步
            {
                // re
                WithDraw withDraw = new WithDraw();
                withDraw.Owner = this;
                withDraw.ShowDialog();
                if (withDraw.Agree)
                {
                    mainForm.cli1.SendToSer("TRUE");//告知同意
                    AllMoves.RemoveRange(AllMoves.Count - 2, 2);//后退两步
                    board = new Board();
                    foreach (Move move in AllMoves)
                        board.MakeMove(move);
                    draw.ReDraw(board);
                }
                else
                    mainForm.cli1.SendToSer("FALSE");
                //RemotePlayerPlay(1);
            }
            else if (msg != null && msg != "")
            {
                int[] temp = new int[4];
                string[] numstr = msg.Split(" ");
                for (int i = 0; i < 4; i++)
                {
                    temp[i] = Convert.ToInt32(numstr[i]);
                }
                winner = CheckWinner(temp[2], temp[3], localPlayerColor);
                Move move = new Move(temp[0], temp[1], temp[2], temp[3]);
                remoteMove = move;
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke(new DrawRemote(DrawRemotePlay));
                }
                if (winner == -1)
                    Defeat.Show();
            }
        }

        private int CheckWinner(int Tox, int Toy, bool killcolor)
        {
            if (board.KingKilled(Tox, Toy, killcolor))//将军被吃，到达的地方为将军之处
            {
                if (killcolor == localPlayerColor)
                    return -1;
                if (killcolor != localPlayerColor)
                    return 1;
            }
            return 0;
        }

        private void DrawRemotePlay()
        {
            board.MakeMove(remoteMove);
            draw.KillHighLight(lastMove);
            draw.DrawMove(remoteMove);
            Thread Bgmthread = new Thread(bgm.Play);
            Bgmthread.Start();
            AllMoves.Add(remoteMove);
            lastMove = remoteMove;
            turn = !turn;
        }
    }

}
