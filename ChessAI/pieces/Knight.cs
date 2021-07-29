using System;
using System.Collections.Generic;

namespace ChessAI.pieces
{
    public class Knight : Piece
    {
        public Knight(bool color) : base(color)
        {
            Value = 3;
        }

        public override Piece Clone()
        {
            return new Knight(Color);
        }

        public override string ToString()
        {
            if (Color == Piece.WHITE)
                return "N";
            else
                return "n";
        }

        public override string GetPieceName()
        {
            if (Color == Piece.WHITE)
                return "wKnight";
            else
                return "bKnight";
        }

        public override List<Move> GetMoves(Board b, int x, int y)
        {
            List<Move> moves = new List<Move>();

            // NNE
            if (Valid(x + 1, y + 2) &&
                (!b.GetTile(x + 1, y + 2).IsOccupied() ||
                 (b.GetTile(x + 1, y + 2).IsOccupied() && b.GetTile(x + 1, y + 2).GetPiece().GetColor() != Color)))
                moves.Add(new Move(x, y, x + 1, y + 2));

            // ENE
            if (Valid(x + 2, y + 1) &&
                (!b.GetTile(x + 2, y + 1).IsOccupied() ||
                 (b.GetTile(x + 2, y + 1).IsOccupied() && b.GetTile(x + 2, y + 1).GetPiece().GetColor() != Color)))
                moves.Add(new Move(x, y, x + 2, y + 1));

            // ESE
            if (Valid(x + 2, y - 1) &&
                (!b.GetTile(x + 2, y - 1).IsOccupied() ||
                 (b.GetTile(x + 2, y - 1).IsOccupied() && b.GetTile(x + 2, y - 1).GetPiece().GetColor() != Color)))
                moves.Add(new Move(x, y, x + 2, y - 1));


            // SSE
            if (Valid(x + 1, y - 2) &&
                (!b.GetTile(x + 1, y - 2).IsOccupied() ||
                 (b.GetTile(x + 1, y - 2).IsOccupied() && b.GetTile(x + 1, y - 2).GetPiece().GetColor() != Color)))
                moves.Add(new Move(x, y, x + 1, y - 2));

            // SSW
            if (Valid(x - 1, y - 2) &&
                (!b.GetTile(x - 1, y - 2).IsOccupied() ||
                 (b.GetTile(x - 1, y - 2).IsOccupied() && b.GetTile(x - 1, y - 2).GetPiece().GetColor() != Color)))
                moves.Add(new Move(x, y, x - 1, y - 2));

            // WSW
            if (Valid(x - 2, y - 1) &&
                (!b.GetTile(x - 2, y - 1).IsOccupied() ||
                 (b.GetTile(x - 2, y - 1).IsOccupied() && b.GetTile(x - 2, y - 1).GetPiece().GetColor() != Color)))
                moves.Add(new Move(x, y, x - 2, y - 1));

            // WNW
            if (Valid(x - 2, y + 1) &&
                (!b.GetTile(x - 2, y + 1).IsOccupied() ||
                 (b.GetTile(x - 2, y + 1).IsOccupied() && b.GetTile(x - 2, y + 1).GetPiece().GetColor() != Color)))
                moves.Add(new Move(x, y, x - 2, y + 1));

            // NNW
            if (Valid(x - 1, y + 2) &&
                (!b.GetTile(x - 1, y + 2).IsOccupied() ||
                 (b.GetTile(x - 1, y + 2).IsOccupied() && b.GetTile(x - 1, y + 2).GetPiece().GetColor() != Color)))
                moves.Add(new Move(x, y, x - 1, y + 2));

            // GC.Collect();

            return moves;
        }
    }
}