using System.Collections.Generic;

namespace ChessAI.pieces
{
    public class Rook : Piece
    {
        public Rook(bool color) : base(color)
        {
            Value = 5;
        }

        public override string ToString()
        {
            if (Color == Piece.WHITE)
                return "R";
            else
                return "r";
        }

        public override string GetPieceName()
        {
            if (Color == Piece.WHITE)
                return "wRook";
            else
                return "bRook";
        }

        public override Piece Clone()
        {
            return new Rook(Color);
        }

        public override List<Move> GetMoves(Board b, int x, int y)
        {
            List<Move> moves = new List<Move>();

            // up
            for (int i = 1; i < 8; i++)
            {
                if (Valid(x, y + i))
                {
                    if (b.GetTile(x, y + i).IsOccupied())
                    {
                        if (b.GetTile(x, y + i).GetPiece().Color != Color)
                            moves.Add(new Move(x, y, x, y + i));

                        break;
                    }
                    else
                        moves.Add(new Move(x, y, x, y + i));
                }
            }

            // down
            for (int i = 1; i < 8; i++)
            {
                if (Valid(x, y - i))
                {
                    if (b.GetTile(x, y - i).IsOccupied())
                    {
                        if (b.GetTile(x, y - i).GetPiece().Color != Color)
                            moves.Add(new Move(x, y, x, y - i));

                        break;
                    }
                    else
                        moves.Add(new Move(x, y, x, y - i));
                }
            }

            // left
            for (int i = 1; i < 8; i++)
            {
                if (Valid(x - i, y))
                {
                    if (b.GetTile(x - i, y).IsOccupied())
                    {
                        if (b.GetTile(x - i, y).GetPiece().Color != Color)
                            moves.Add(new Move(x, y, x - i, y));

                        break;
                    }
                    else
                        moves.Add(new Move(x, y, x - i, y));
                }
            }

            // right
            for (int i = 1; i < 8; i++)
            {
                if (Valid(x + i, y))
                {
                    if (b.GetTile(x + i, y).IsOccupied())
                    {
                        if (b.GetTile(x + i, y).GetPiece().Color != Color)
                            moves.Add(new Move(x, y, x + i, y));

                        break;
                    }
                    else
                        moves.Add(new Move(x, y, x + i, y));
                }
            }


            return moves;
        }
    }
}