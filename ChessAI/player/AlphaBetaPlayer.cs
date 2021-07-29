using System;
using ChessAI.minimax;

namespace ChessAI.player
{
    public class AlphaBetaPlayer : Player
    {
        MinimaxAlphaBeta minimax;
	
        /**
	 * @param color
	 */
        public AlphaBetaPlayer(Boolean color, int maxDepth): base(color)
        {
	        minimax = new MinimaxAlphaBeta(color, maxDepth);
        }

        /**
	 * Function to prompt the player to make a move after the first move has
	 * already been made
	 * 
	 * @param b
	 *            the board to parse
	 * @return the selected move
	 */
        public override Move GetNextMove(Board b) {
            Move move = minimax.Decision(b);
            return move;
        }
    }
}