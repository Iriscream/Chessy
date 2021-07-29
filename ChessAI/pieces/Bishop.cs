using System;
using System.Collections.Generic;

namespace ChessAI.pieces
{
    public class Bishop : Piece
    {
        public Bishop(bool color) : base(color)
        {
            Value = 3;
        }

        public override string ToString()
        {
            if (Color == Piece.WHITE)
                return "B";
            else
                return "b";
        }

        public override string GetPieceName()
        {
            if (Color == Piece.WHITE)
                return "wBishop";
            else
                return "bBishop";
        }

        public override Piece Clone()
        {
            return new Bishop(Color);
        }

        public override List<Move> GetMoves(Board b, int x, int y)
        {
            List<Move> moves = new List<Move>();


            // NE
            for (int i = 1; i < 8; i++)
            {
                if (Valid(x + i, y + i))
                {
                    if (b.GetTile(x + i, y + i).IsOccupied())
                    {
                        if (b.GetTile(x + i, y + i).GetPiece().Color != Color)
                            moves.Add(new Move(x, y, x + i, y + i));

                        break;
                    }
                    else
                        moves.Add(new Move(x, y, x + i, y + i));
                }
            }

            // NW
            for (int i = 1; i < 8; i++)
            {
                if (Valid(x - i, y + i))
                {
                    if (b.GetTile(x - i, y + i).IsOccupied())
                    {
                        if (b.GetTile(x - i, y + i).GetPiece().Color != Color)
                            moves.Add(new Move(x, y, x - i, y + i));

                        break;
                    }
                    else
                        moves.Add(new Move(x, y, x - i, y + i));
                }
            }

            // SE
            for (int i = 1; i < 8; i++)
            {
                if (Valid(x + i, y - i))
                {
                    if (b.GetTile(x + i, y - i).IsOccupied())
                    {
                        if (b.GetTile(x + i, y - i).GetPiece().Color != Color)
                            moves.Add(new Move(x, y, x + i, y - i));

                        break;
                    }
                    else
                        moves.Add(new Move(x, y, x + i, y - i));
                }
            }

            // SW
            for (int i = 1; i < 8; i++)
            {
                if (Valid(x - i, y - i))
                {
                    if (b.GetTile(x - i, y - i).IsOccupied())
                    {
                        if (b.GetTile(x - i, y - i).GetPiece().Color != Color)
                            moves.Add(new Move(x, y, x - i, y - i));

                        break;
                    }
                    else
                        moves.Add(new Move(x, y, x - i, y - i));
                }
            }

            return moves;
        }
    }
}