using System;

namespace ChessAI.player
{
    public abstract class Player
    {
        protected bool Color;
        /**
	 * Default constructor
	 * 
	 * @param color
	 *            the player's color
	 */
        public Player(bool color) {
            this.Color = color;
        }


        /**
		 * Function to prompt the player to make a move after the first move has
		 * already been made
		 * 
		 * @param b the board to parse
		 * @return the selected move
		 */
        public virtual Move GetNextMove(Board b) {
            return null;
        }

        public bool GetColor() {
            return Color;
        }

        public void SetColor(bool color) {
            this.Color = color;
        }
    }
}