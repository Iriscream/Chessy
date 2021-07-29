using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ChessAI;
using ChessAI.pieces;

namespace ChessDraw
{

    class Draw
    {
        Board board;
        // 用于表示当前选中棋子所有可下坐标。
        List<Move> moves = null;
        PictureBox canvas;
        bool Color;
        private enum IMAGE
        {
            // 白棋
            wKING, wQUEEN, wROOK, wBISHOP, wKNIGHT, wPAWN,
            // 黑棋
            bKING, bQUEEN, bROOK, bBISHOP, bKNIGHT, bPAWN,
            // 浅色格子，深色格子，提示，高亮
            WHITE, BLACK, HINT, HIGHLIGHT
        };

        public Draw(PictureBox pictureBox, Board b, bool color)
        {
            board = b;
            canvas = pictureBox;
            Color = color;
            DrawBoard();
        }

        /// <summary>
        /// 画出初始的棋盘。
        /// </summary>
        private void DrawBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board.GetTile(i, j).GetPiece() != null)
                        DrawImage(GetImagePath(board.GetTile(i, j).GetPiece()),
                                  i, j);
                }
            }
        }

        /// <summary>
        /// 从新绘制棋盘。
        /// </summary>
        /// <param name="b"></param>
        public void ReDraw(Board b)
        {
            board = b;

            Image image = Image.FromFile(@"..\..\..\ChessDraw\res\board.png");
            Image tmp = canvas.BackgroundImage;
            canvas.BackgroundImage = image;
            tmp.Dispose();
            DrawBoard();
        }
        /// <summary>
        /// 获取棋盘（x, y）处的棋子。
        /// </summary>
        /// <returns>棋盘上（x, y）处的棋子</returns>
        public Piece GetPiece(int x, int y)
        {
            return board.GetTile(x, y).GetPiece();
        }

        /// <summary>
        /// 在棋盘上画出move代表的这一步棋。
        /// </summary>
        public void DrawMove(Move move)
        {
            int x1 = move.GetX1(), y1 = move.GetY1();
            int x2 = move.GetX2(), y2 = move.GetY2();

            HideCell(x1, y1);
            HideCell(x2, y2);

            DrawImage(GetImagePath(board.GetTile(x2, y2).GetPiece()),
                      x2, y2);

            DrawHighLight(x1, y1);
            DrawHighLight(x2, y2);
        }

        /// <summary>
        /// 在（x, y）处绘制图片imageName。
        /// </summary>
        private void DrawImage(string imageName, int x, int y)
        {
            try
            {
                if (Color)
                    y = 7 - y;
                Image image = Image.FromFile(imageName);
                Image bgImage = (Image)canvas.BackgroundImage.Clone();
                Graphics graphics = Graphics.FromImage(bgImage);

                // 178 和 44 分别是原始大小的棋盘图片（board.png）
                // 每个格子尺寸和边框尺寸。
                graphics.DrawImage(image, 178 * x + 44, 178 * y + 44, 178, 178);

                Image tmp = canvas.BackgroundImage;
                canvas.BackgroundImage = (Image)bgImage.Clone();

                // 释放资源
                image.Dispose();
                tmp.Dispose();
                graphics.Dispose();
                bgImage.Dispose();
            }
            catch (System.IO.FileNotFoundException)
            {
                // pass
            }
        }

        /// <summary>
        /// 绘制提示。
        /// </summary>
        public void DrawHint(Piece piece, int x, int y)
        {
            if (!Piece.Valid(x, y))
                return;

            moves = piece.GetMoves(board, x, y);
            if (moves == null)
                return;

            foreach (Move move in moves)
            {
                int x2 = move.GetX2(), y2 = move.GetY2();
                HideCell(x2, y2);

                // 先绘制提示，再绘制棋子。
                DrawImage(GetImagePath(IMAGE.HINT), x2, y2);
                if (board.GetTile(x2, y2).GetPiece() != null)
                    DrawImage(GetImagePath(board.GetTile(x2, y2).GetPiece()),
                              x2, y2);
            }
        }

        /// <summary>
        /// 删除提示。
        /// </summary>
        public void KillHint()
        {
            if (moves == null)
                return;
            foreach (Move move in moves)
            {
                int x2 = move.GetX2(), y2 = move.GetY2();
                HideCell(x2, y2);
                if (board.GetTile(x2, y2).GetPiece() != null)
                    DrawImage(GetImagePath(board.GetTile(x2, y2).GetPiece()),
                              x2, y2);
            }
        }

        /// <summary>
        /// 绘制高亮。
        /// 用于提示用户当前选择的棋子，以及显示上一步棋的路径。
        /// </summary>
        public void DrawHighLight(int x, int y)
        {
            try
            {
                HideCell(x, y);
                DrawImage(GetImagePath(IMAGE.HIGHLIGHT), x, y);
                if (board.GetTile(x, y).GetPiece() != null)
                    DrawImage(GetImagePath(board.GetTile(x, y).GetPiece()),
                              x, y);
            }
            catch (System.IndexOutOfRangeException)
            {
                // pass
            }
        }

        /// <summary>
        /// 删除高亮。
        /// </summary>
        public void KillHighLight(int x, int y)
        {
            try
            {
                HideCell(x, y);
                if (board.GetTile(x, y).GetPiece() != null)
                    DrawImage(GetImagePath(board.GetTile(x, y).GetPiece()),
                                x, y);
            }
            catch (System.IndexOutOfRangeException)
            {
                // pass
            }
        }

        public void KillHighLight(Move move)
        {
            if (move == null)
                return;
            KillHighLight(move.GetX1(), move.GetY1());
            KillHighLight(move.GetX2(), move.GetY2());
        }

        /// <summary>
        /// 获取图片路径。
        /// </summary>
        private string GetImagePath(Piece piece)
        {
            try
            {
                return @"..\..\..\ChessDraw\res\" + piece.GetPieceName() + ".png";
            }
            catch (System.NullReferenceException)
            {
                // pass
                return null;
            }
        }

        /// <summary>
        /// 获取图片路径。
        /// </summary>
        private string GetImagePath(IMAGE chess)
        {
            return @"..\..\..\ChessDraw\res\" + chess.ToString() + ".png";
        }

        /// <summary>
        /// 隐藏棋盘上的格子。
        /// </summary>
        private void HideCell(int x, int y)
        {
            if (Color == Piece.BLACK)
            {
                if ((x + y) % 2 == 0)
                    DrawImage(GetImagePath(IMAGE.BLACK), x, y);
                else
                    DrawImage(GetImagePath(IMAGE.WHITE), x, y);
            }
            else
            {
                if ((x + y) % 2 == 0)
                    DrawImage(GetImagePath(IMAGE.WHITE), x, y);
                else
                    DrawImage(GetImagePath(IMAGE.BLACK), x, y);
            }
        }
    }
}
