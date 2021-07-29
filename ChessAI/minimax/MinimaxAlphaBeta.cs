using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using ChessAI.pieces;

namespace ChessAI.minimax
{
    public class MinimaxAlphaBeta
    {
        bool color;
        int maxDepth;
        Random rand;

        /**
     *
     */
        public MinimaxAlphaBeta(bool color, int maxDepth)
        {
            this.color = color;
            this.maxDepth = maxDepth;
            rand = new Random();
        }

        private float MaxValue(Board b, List<Move> state, float alpha, float beta, int depth)
        {
            if (depth > maxDepth)
                return Eval1(b, state, color);

            List<Move> moves = b.GetMovesAfter(color, state);
            if (moves.Count == 0) // TODO add draw
                return float.NegativeInfinity;

            for (int i = 0; i < moves.Count; i++)
            {
                state.Add(moves[i]);
                float tmp = MinValue(b, state, alpha, beta, depth + 1);
                state.Remove(state.FindLast(move => move.Equals(moves[i])));
                if (tmp > alpha)
                {
                    alpha = tmp;
                }

                if (beta <= alpha)
                    break;

                //if (max >= beta)
                //	return max;

                //if (max > alpha)
                //	alpha = max;
            }

            return alpha;
        }

        private float MinValue(Board b, List<Move> state, float alpha, float beta, int depth)
        {
            if (depth > maxDepth)
                return Eval1(b, state, !color);

            List<Move> moves = b.GetMovesAfter(!color, state);
            if (moves.Count == 0) // TODO add draw
                return float.PositiveInfinity;

            for (int i = 0; i < moves.Count; i++)
            {
                state.Add(moves[i]);
                float tmp = MaxValue(b, state, alpha, beta, depth + 1);
                state.Remove(state.FindLast(move => move.Equals(moves[i])));
                if (tmp < beta)
                {
                    beta = tmp;
                }

                if (beta <= alpha)
                    break;


                //if (min <= beta)
                //	return min;

                //if (min < beta)
                //	beta = min;
            }

            return beta;
        }

        public Move Decision(Board b)
        {
            // get maximum move

            List<Move> moves = b.GetMoves(color);
            if (moves.Count == 0)
                return null;

            List<Task<float>> costs = new List<Task<float>>(moves.Count);


            for (var i = 0; i < moves.Count; i++)
            {
                Move move = moves[i];
                Task<float> result = Task.Run((() =>
                {
                    List<Move> state = new List<Move> {move};
                    float tmp = MinValue(b, state, float.NegativeInfinity, float.PositiveInfinity, 1);
                    return tmp;
                }));

                costs.Insert(i, result);
            }

            try
            {
                Task.WaitAll(costs.ToArray());
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e);
                throw;
            }


            // max
            int maxi = -1;

            float max = float.NegativeInfinity;
            for (int i = 0; i < moves.Count; i++)
            {
                float cost;
                try
                {
                    // costs[i].Wait();
                    cost = costs[i].Result;
                }
                catch (Exception e)
                {
                    try
                    {
                        Thread.Sleep(300);
                    }
                    catch (Exception e1)
                    {
                        // ignored
                    }

                    continue;
                }

                if (cost >= max)
                {
                    if (Math.Abs(cost - max) < 0.1) // add a little random element
                        if (rand.Next(0, 2) > 0)
                            continue;

                    max = cost;
                    maxi = i;
                }
            }

            return moves[maxi];
        }

        public Move SingleThreadDecision(Board b)
        {
            // get maximum move

            List<Move> moves = b.GetMoves(color);
            List<Move> state = new List<Move>();
            float[] costs = new float[moves.Count];
            for (int i = 0; i < moves.Count; i++)
            {
                state.Add(moves[i]);
                float tmp = MinValue(b, state, float.NegativeInfinity, float.PositiveInfinity, 1);
                costs[i] = tmp;
                state.Remove(state.FindLast(
                    move => move.Equals(moves[i])));
            }

            // max
            int maxi = -1;
            float max = float.NegativeInfinity;
            for (int i = 0; i < moves.Count; i++)
            {
                if (costs[i] >= max)
                {
                    if (Math.Abs(costs[i] - max) < 0.1) // add a little random element
                        if (rand.Next(0, 2) > 0)
                            continue;

                    max = costs[i];
                    maxi = i;
                }
            }

            if (maxi == -1)
                return null;
            else
                return moves[maxi];
        }

        private float Eval2(Board b, List<Move> moves, bool currentColor)
        {
            Tile[,] tiles = b.GetTilesAfter(moves);

            // check if king missing
            Boolean blackKing = false, whiteKing = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tiles[i, j].IsOccupied())
                    {
                        if (tiles[i, j].GetPiece().ToString().Equals("K"))
                        {
                            whiteKing = true;
                        }

                        if (tiles[i, j].GetPiece().ToString().Equals("k"))
                        {
                            blackKing = true;
                        }
                    }
                }
            }

            if (color == Piece.WHITE)
            {
                if (whiteKing == false)
                    return float.NegativeInfinity;
                if (blackKing == false)
                    return float.PositiveInfinity;
            }
            else
            {
                if (whiteKing == false)
                    return float.PositiveInfinity;
                if (blackKing == false)
                    return float.NegativeInfinity;
            }


            int whiteScore = 0;
            int blackScore = 0;

            for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
            {
                if (tiles[i, j].IsOccupied())
                    if (tiles[i, j].GetPiece().GetColor() == Piece.WHITE)
                        whiteScore += tiles[i, j].GetPiece().GetValue();
                    else
                        blackScore += tiles[i, j].GetPiece().GetValue();
            }


            if (color == Piece.WHITE)
                return whiteScore - blackScore;
            else
                return blackScore - whiteScore;
        }


        private float Eval1(Board b, List<Move> moves, bool currentColor)
        {
            Tile[,] tiles = b.GetTilesAfter(moves);

            if (b.GetMoves(currentColor).Count == 0)
            {
                if (b.IsCheckAfter(currentColor, moves))
                    return (currentColor == this.color) ? float.NegativeInfinity : float.PositiveInfinity;
                else
                    return float.NegativeInfinity; // we don't like draws
            }

            int whiteScore = 0;
            int blackScore = 0;

            for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
            {
                if (tiles[i, j].IsOccupied())
                    if (tiles[i, j].GetPiece().GetColor() == Piece.WHITE)
                        whiteScore += tiles[i, j].GetPiece().GetValue();
                    else
                        blackScore += tiles[i, j].GetPiece().GetValue();
            }


            if (color == Piece.WHITE)
                return whiteScore - blackScore;
            else
                return blackScore - whiteScore;
        }
    }
}