using System;
using ChessAI.pieces;

namespace ChessAI
{
    public class Tile
    {
        private bool _occupied;
        private Piece _piece;


        public Tile()
        {
            _occupied = false;
        }

        public Tile(Tile tile)
        {
            this._occupied = tile.IsOccupied();
            this._piece = tile.IsOccupied() ? tile.GetPiece().Clone() : null;
        }

        public Tile(Piece piece)
        {
            _occupied = true;
            this._piece = piece;
        }

        public override string ToString()
        {
            if (_occupied)
                return _piece.ToString();
            else
                return ".";
        }

        public Piece GetPiece()
        {
            return _piece;
        }

        public Boolean IsOccupied()
        {
            return _occupied;
        }
    }
}