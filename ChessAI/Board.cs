using System;
using System.Collections.Generic;
using ChessAI.pieces;
using ChessAI;

namespace ChessAI
{
    public class Board
    {
        public static int a = 0, b = 1, c = 2, d = 3, e = 4, f = 5, g = 6, h = 7;

        private Tile[,] _tiles;

        /**	
	 * 	 8	r n b q k b n r 
	 *	 7	p p p p p p p p 
	 *	 6	. . . . . . . . 
	 *	 5	. . . . . . . . 
	 *	 4	. . . . . . . . 
	 *	 3	. . . . . . . . 
	 *	 2	P P P P P P P P 
	 *	 1  R N B Q K B N R
	 *    	
	 *    	a b c d e f g h
	 *    
	 * P=pawn, K=king, Q=queen, R=rook, N=knight, B=Bishop
	 * Uppercase is white
	 */
        public Board(Tile[,] tiles)
        {
            this._tiles = tiles;
        }

        /**
	 * 
	 */
        public Board()
        {
            // initialize board
            Boolean co = Piece.WHITE;
            _tiles = new Tile[8, 8];
            _tiles[a, 1 - 1] = new Tile(new Rook(co));
            _tiles[b, 1 - 1] = new Tile(new Knight(co));
            _tiles[c, 1 - 1] = new Tile(new Bishop(co));
            _tiles[d, 1 - 1] = new Tile(new Queen(co));
            _tiles[e, 1 - 1] = new Tile(new King(co));
            _tiles[f, 1 - 1] = new Tile(new Bishop(co));
            _tiles[g, 1 - 1] = new Tile(new Knight(co));
            _tiles[h, 1 - 1] = new Tile(new Rook(co));

            for (int i = 0; i < 8; i++)
            {
                _tiles[i, 2 - 1] = new Tile(new Pawn(co));
            }

            for (int i = 2; i < 7; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    _tiles[j, i] = new Tile();
                }
            }

            co = Piece.BLACK;
            _tiles[a, 8 - 1] = new Tile(new Rook(co));
            _tiles[b, 8 - 1] = new Tile(new Knight(co));
            _tiles[c, 8 - 1] = new Tile(new Bishop(co));
            _tiles[d, 8 - 1] = new Tile(new Queen(co));
            _tiles[e, 8 - 1] = new Tile(new King(co));
            _tiles[f, 8 - 1] = new Tile(new Bishop(co));
            _tiles[g, 8 - 1] = new Tile(new Knight(co));
            _tiles[h, 8 - 1] = new Tile(new Rook(co));

            for (int i = 0; i < 8; i++)
            {
                _tiles[i, 7 - 1] = new Tile(new Pawn(co));
            }
        }

        public static void main(String[] args)
        {
            Board b = new Board();
            Console.Write(b);
        }

        public override string ToString()
        {
            String str = "";
            for (int i = 7; i >= 0; i--)
            {
                str += (i + 1) + "  ";
                for (int j = 0; j < 8; j++)
                {
                    str += _tiles[j, i] + " ";
                }

                str += "\n";
            }

            str += "\n   a b c d e f g h";

            return str;
        }

        public List<Move> GetMoves(Boolean color)
        {
            return GetMoves(color, true);
        }


        /**
	 * Checks if player color is under check
	 * 
	 * @param color
	 * @return
	 */
        public Boolean IsCheck(Boolean color)
        {
            int x = -1, y = -1;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (_tiles[i, j].IsOccupied() &&
                        _tiles[i, j].GetPiece().GetColor() == color &&
                        _tiles[i, j].GetPiece().ToString().ToUpper().Equals("K"))
                    {
                        x = i;
                        y = j;
                    }
                }

            // check a move if after making this move the king can be killed (moving into check)
            List<Move> opponentMoves = GetMoves(!color, false);

            // check all opponent moves if they kill king (opponent moves in next round)
            for (int j = 0; j < opponentMoves.Count; j++)
            {
                if (opponentMoves[j].GetX2() == x && opponentMoves[j].GetY2() == y)
                    return true;
            }

            return false;
        }

        public bool KingKilled(int Tox, int Toy, Boolean color)
        {
            int x = -1, y = -1;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (_tiles[i, j].IsOccupied() &&
                        _tiles[i, j].GetPiece().GetColor() == color &&
                        _tiles[i, j].GetPiece().ToString().ToUpper().Equals("K"))
                    {
                        x = i;
                        y = j;
                    }
                }
            if (x == Tox && y == Toy)
            {
                return true;
            }
            else
                return false;
        }


        /**
         * Checks if player color is under check
         * 
         * @param color
         * @return
         */
        public Boolean IsCheckAfter(Boolean color, List<Move> moves)
        {
            Tile[,] newTiles = GetTilesAfter(moves);

            int x = -1, y = -1;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (newTiles[i, j].IsOccupied() &&
                        newTiles[i, j].GetPiece().GetColor() == color &&
                        newTiles[i, j].GetPiece().ToString().ToUpper().Equals("K"))
                    {
                        x = i;
                        y = j;
                    }
                }

            // check a move if after making this move the king can be killed (moving into check)
            List<Move> opponentMoves = GetMovesAfter(!color, moves, false);

            // check all opponent moves if they kill king (opponent moves in next round)
            for (int j = 0; j < opponentMoves.Count; j++)
            {
                if (opponentMoves[j].GetX2() == x && opponentMoves[j].GetY2() == y)
                    return true;
            }

            return false;
        }

        public List<Move> GetMoves(Boolean color, Boolean checkCheck)
        {
            List<Move> moves = new List<Move>();

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (_tiles[i, j].IsOccupied() &&
                        _tiles[i, j].GetPiece().GetColor() == color)
                    {
                        moves.AddRange(_tiles[i, j].GetPiece().GetMoves(this, i, j));
                    }
                }

            // check if move is valid (must not be check after move) and throw away erroneous moves
            if (checkCheck)
            {
                // find king (of correct color)
                int x = -1, y = -1;
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                    {
                        if (_tiles[i, j].IsOccupied() &&
                            _tiles[i, j].GetPiece().GetColor() == color &&
                            _tiles[i, j].GetPiece().ToString().ToUpper().Equals("K"))
                        {
                            x = i;
                            y = j;
                        }
                    }

                List<Move> removeThese = new List<Move>();
                for (int i = 0; i < moves.Count; i++)
                {
                    // check a move if after making this move the king can be killed (moving into check)
                    List<Move> checkThis = new List<Move>(moves.GetRange(i, 1));
                    List<Move> opponentMoves = GetMovesAfter(!color, checkThis, false);

                    int xUpdated = x, yUpdated = y;
                    if (checkThis[0].GetX1() == x && checkThis[0].GetY1() == y)
                    {
                        // get updated king position
                        xUpdated = checkThis[0].GetX2();
                        yUpdated = checkThis[0].GetY2();
                    }

                    // check all opponent moves if they kill king (opponent moves in next round)
                    for (int j = 0; j < opponentMoves.Count; j++)
                    {
                        if (opponentMoves[j].GetX2() == xUpdated && opponentMoves[j].GetY2() == yUpdated)
                            removeThese.Add(checkThis[0]);
                    }
                }

                moves.RemoveAll(i => removeThese.Contains(i));
                // moves.RemoveAll(removeThese); // remove invalid moves
            }

            return moves;
        }

        public List<Move> GetMovesAfter(Boolean color, List<Move> moves)
        {
            return GetMovesAfter(color, moves, true);
        }

        public List<Move> GetMovesAfter(Boolean color, List<Move> moves, Boolean checkCheck)
        {
            Tile[,] temp = new Tile[8, 8];
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    temp[x, y] = new Tile(this._tiles[x, y]);
                }
            }

            Board b = new Board(temp);

            for (int i = 0; i < moves.Count; i++)
                b.MakeMove(moves[i]);

            List<Move> futureMoves = b.GetMoves(color, checkCheck);

            return futureMoves;
        }

        public Tile[,] GetTilesAfter(List<Move> moves)
        {
            Tile[,] temp = new Tile[8, 8];
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    temp[x, y] = new Tile(this._tiles[x, y]);
                }
            }

            Board b = new Board(temp);

            for (int i = 0; i < moves.Count; i++)
                b.MakeMove(moves[i]);

            Tile[,] temp2 = new Tile[8, 8];
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    temp2[x, y] = new Tile(b.GetTile(x, y));
                }
            }

            return temp2;
        }

        /**
	     * @param m
	     * @return -1 if black wins
	     * 			1 if white wins
	     * 			0 if game continues
	     */
        public int MakeMove(Move m)
        {
            Tile oldTile = _tiles[m.GetX1(), m.GetY1()];

            _tiles[m.GetX2(), m.GetY2()] = _tiles[m.GetX1(), m.GetY1()];
            _tiles[m.GetX1(), m.GetY1()] = new Tile();

            if (m.IsCastling())
            {
                if (m.GetX2() == g && m.GetY2() == 1 - 1)
                {
                    _tiles[f, 1 - 1] = _tiles[h, 1 - 1];
                    _tiles[h, 1 - 1] = new Tile();
                }

                if (m.GetX2() == c && m.GetY2() == 1 - 1)
                {
                    _tiles[d, 1 - 1] = _tiles[a, 1 - 1];
                    _tiles[a, 1 - 1] = new Tile();
                }

                if (m.GetX2() == g && m.GetY2() == 8 - 1)
                {
                    _tiles[f, 8 - 1] = _tiles[h, 8 - 1];
                    _tiles[h, 8 - 1] = new Tile();
                }

                if (m.GetX2() == c && m.GetY2() == 8 - 1)
                {
                    _tiles[d, 8 - 1] = _tiles[a, 8 - 1];
                    _tiles[a, 8 - 1] = new Tile();
                }
            }

            // pawn at top?
            if (oldTile.GetPiece().ToString().Equals("P") && m.GetY2() == 8 - 1)
                _tiles[m.GetX2(), m.GetY2()] = new Tile(new Queen(Piece.WHITE));

            if (oldTile.GetPiece().ToString().Equals("p") && m.GetY2() == 1 - 1)
                _tiles[m.GetX2(), m.GetY2()] = new Tile(new Queen(Piece.BLACK));

            return 0;
        }

        public Tile GetTile(int x, int y)
        {
            return _tiles[x, y];
        }
    }
}