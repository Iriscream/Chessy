using System;
using System.Collections.Generic;

namespace ChessAI.pieces
{
    public class King : Piece
    {
        Boolean _hasMoved = false;

        /**
	 * 
	 */
        public King(bool color) : base(color)
        {
            Value = 0;
        }

        public King(bool color, bool hasMoved) : base(color)
        {
            this._hasMoved = hasMoved;
            Value = 0;
        }

        public override Piece Clone()
        {
            return new King(Color, _hasMoved);
        }

        public override string ToString()
        {
            if (Color == Piece.WHITE)
                return "K";
            else
                return "k";
        }

        public override string GetPieceName()
        {
            if (Color == Piece.WHITE)
                return "wKing";
            else
                return "bKing";
        }

        public override List<Move> GetMoves(Board b, int x, int y)
        {
            List<Move> moves = new List<Move>();

            // N
            if (Valid(x, y + 1) &&
                (!b.GetTile(x, y + 1).IsOccupied() ||
                 (b.GetTile(x, y + 1).IsOccupied() && b.GetTile(x, y + 1).GetPiece().GetColor() != Color)))
                moves.Add(new Move(x, y, x, y + 1));

            // NE
            if (Valid(x + 1, y + 1) &&
                (!b.GetTile(x + 1, y + 1).IsOccupied() ||
                 (b.GetTile(x + 1, y + 1).IsOccupied() && b.GetTile(x + 1, y + 1).GetPiece().GetColor() != Color)))
                moves.Add(new Move(x, y, x + 1, y + 1));

            // E
            if (Valid(x + 1, y) &&
                (!b.GetTile(x + 1, y).IsOccupied() ||
                 (b.GetTile(x + 1, y).IsOccupied() && b.GetTile(x + 1, y).GetPiece().GetColor() != Color)))
                moves.Add(new Move(x, y, x + 1, y));


            // SE
            if (Valid(x + 1, y - 1) &&
                (!b.GetTile(x + 1, y - 1).IsOccupied() ||
                 (b.GetTile(x + 1, y - 1).IsOccupied() && b.GetTile(x + 1, y - 1).GetPiece().GetColor() != Color)))
                moves.Add(new Move(x, y, x + 1, y - 1));

            // S
            if (Valid(x, y - 1) &&
                (!b.GetTile(x, y - 1).IsOccupied() ||
                 (b.GetTile(x, y - 1).IsOccupied() && b.GetTile(x, y - 1).GetPiece().GetColor() != Color)))
                moves.Add(new Move(x, y, x, y - 1));

            // SW
            if (Valid(x - 1, y - 1) &&
                (!b.GetTile(x - 1, y - 1).IsOccupied() ||
                 (b.GetTile(x - 1, y - 1).IsOccupied() && b.GetTile(x - 1, y - 1).GetPiece().GetColor() != Color)))
                moves.Add(new Move(x, y, x - 1, y - 1));

            // W
            if (Valid(x - 1, y) &&
                (!b.GetTile(x - 1, y).IsOccupied() ||
                 (b.GetTile(x - 1, y).IsOccupied() && b.GetTile(x - 1, y).GetPiece().GetColor() != Color)))
                moves.Add(new Move(x, y, x - 1, y));

            // NW
            if (Valid(x - 1, y + 1) &&
                (!b.GetTile(x - 1, y + 1).IsOccupied() ||
                 (b.GetTile(x - 1, y + 1).IsOccupied() && b.GetTile(x - 1, y + 1).GetPiece().GetColor() != Color)))
                moves.Add(new Move(x, y, x - 1, y + 1));

            // Castling
            if (Color == Piece.WHITE)
            {
                if (!_hasMoved && x == Board.e && y == 1 - 1)
                {
                    if (!b.GetTile(Board.f, 1 - 1).IsOccupied() &&
                        !b.GetTile(Board.g, 1 - 1).IsOccupied() &&
                        b.GetTile(Board.h, 1 - 1).IsOccupied() &&
                        b.GetTile(Board.h, 1 - 1).GetPiece().ToString().Equals("R"))
                        moves.Add(new Move(x, y, x + 2, y));
                }
                else
                    _hasMoved = true;
            }
            else
            {
                // color == Piece.BLACK
                if (!_hasMoved && x == Board.e && y == 8 - 1)
                {
                }
                else
                    _hasMoved = true;
            }


            // TODO King cannot move into open fire


            return moves;
        }
    }
}