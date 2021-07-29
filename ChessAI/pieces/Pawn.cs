using System;
using System.Collections.Generic;

namespace ChessAI.pieces
{
    public class Pawn : Piece
    {
        /**
	 * 
	 */
        public Pawn(bool color) : base(color)
        {
            Value = 1;
        }

        public override Piece Clone()
        {
            return new Pawn(Color);
        }

        public override string ToString()
        {
            if (Color == Piece.WHITE)
                return "P";
            else
                return "p";
        }

        public override string GetPieceName()
        {
            if (Color == Piece.WHITE)
                return "wPawn";
            else
                return "bPawn";
        }

        /**
	 * @param b Board
	 * @param x x location of piece
	 * @param y y location of piece
	 * @return
	 */
        public override List<Move> GetMoves(Board b, int x, int y)
        {
            List<Move> moves = new List<Move>();

            if (Color == Piece.WHITE)
            {
                if (y == 1)
                {
                    if (Valid(x, y + 2) && !b.GetTile(x, y + 2).IsOccupied())
                        moves.Add(new Move(x, y, x, y + 2));
                }
                // forward
                if (Valid(x, y + 1) && !b.GetTile(x, y + 1).IsOccupied())
                    moves.Add(new Move(x, y, x, y + 1));

                // kill diagonally
                if (Valid(x + 1, y + 1) && b.GetTile(x + 1, y + 1).IsOccupied() &&
                    b.GetTile(x + 1, y + 1).GetPiece().GetColor() != Color)
                    moves.Add(new Move(x, y, x + 1, y + 1));

                // kill diagonally
                if (Valid(x - 1, y + 1) && b.GetTile(x - 1, y + 1).IsOccupied() &&
                    b.GetTile(x - 1, y + 1).GetPiece().GetColor() != Color)
                    moves.Add(new Move(x, y, x - 1, y + 1));
            }
            else
            {
                if (y == 6)
                {
                    if (Valid(x, y - 2) && !b.GetTile(x, y - 2).IsOccupied())
                        moves.Add(new Move(x, y, x, y - 2));
                }
                // forward
                if (Valid(x, y - 1) && !b.GetTile(x, y - 1).IsOccupied())
                    moves.Add(new Move(x, y, x, y - 1));

                // kill diagonally
                if (Valid(x + 1, y - 1) && b.GetTile(x + 1, y - 1).IsOccupied() &&
                    b.GetTile(x + 1, y - 1).GetPiece().GetColor() != Color)
                    moves.Add(new Move(x, y, x + 1, y - 1));

                // kill diagonally
                if (Valid(x - 1, y - 1) && b.GetTile(x - 1, y - 1).IsOccupied() &&
                    b.GetTile(x - 1, y - 1).GetPiece().GetColor() != Color)
                    moves.Add(new Move(x, y, x - 1, y - 1));
            }

            return moves;
        }
    }
}