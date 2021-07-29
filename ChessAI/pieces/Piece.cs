using System;
using System.Collections.Generic;

namespace ChessAI.pieces
{
    public abstract class Piece
    {
        public static bool WHITE = true, BLACK = false;
        protected internal bool Color;
        protected int Value;

        public bool GetColor()
        {
            return Color;
        }

        public Piece(bool color)
        {
            this.Color = color;
            Value = 0;
        }

        public int GetValue()
        {
            return Value;
        }

        public abstract string GetPieceName();
        public abstract Piece Clone();

        public abstract List<Move> GetMoves(Board b, int x, int y);

        /**
	     * @param b Board
	     * @param x x location of piece
	     * @param y y location of piece
	     * @return
	     */
        public static bool Valid(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
                return false;
            else
                return true;
        }
    }
}