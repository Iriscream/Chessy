using System;

namespace ChessAI
{
    public class Move
    {
        private int _x1, _y1, _x2, _y2;
        private bool _castling = false;

        /**
	 * 
	 */
        public Move(int x1, int y1, int x2, int y2)
        {
            this._x1 = x1;
            this._y1 = y1;
            this._x2 = x2;
            this._y2 = y2;
        }

        public Move(int x1, int y1, int x2, int y2, bool castling)
        {
            this._x1 = x1;
            this._y1 = y1;
            this._x2 = x2;
            this._y2 = y2;
            this._castling = castling;
        }

        public int GetX1()
        {
            return _x1;
        }

        public void SetX1(int x1)
        {
            this._x1 = x1;
        }

        public int GetX2()
        {
            return _x2;
        }

        public void SetX2(int x2)
        {
            this._x2 = x2;
        }

        public int GetY1()
        {
            return _y1;
        }

        public void SetY1(int y1)
        {
            this._y1 = y1;
        }

        public int GetY2()
        {
            return _y2;
        }

        public void SetY2(int y2)
        {
            this._y2 = y2;
        }

        public bool IsCastling()
        {
            return _castling;
        }

        public override string ToString()
        {
            // TODO change to a1 to b4 etc
            //return x1 + " " + y1 + " " + x2 + " " + y2;
            return (char) ('A' + _x1) + "" + (_y1 + 1) + " " + (char) ('A' + _x2) + "" + (_y2 + 1);
        }

        public override bool Equals(Object o)
        {
            Move op = (Move) o;

            if (op != null && op.GetX1() == _x1 && op.GetY1() == _y1 && op.GetX2() == _x2 && op.GetY2() == _y2 &&
                op.IsCastling() == _castling)
            {
                return true;
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_x1, _y1, _x2, _y2, _castling);
        }
    }
}