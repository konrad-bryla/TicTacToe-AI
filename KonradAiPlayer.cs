using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class KonradAiPlayer : Player
    {
        public KonradAiPlayer(TicTacToeBoard.CHOICE playerChoice)
            : base(playerChoice)
        { }

        public override TicTacToeAction makeMove(TicTacToeBoard board)
        {
            //////////////////////////////////////
            // Approach #3
            // List a series of rules, the first one that has an available action will be used
            // In this case, IS_CENTER is first, so it will look to see if there's an available move to the center
            // If so, it takes that move, otherwise it looks at the next rule
            // The next rule is to see if it's a corner--if that's available, it moves to a corner (if more than one is available, it picks one at random)
            // The last rule has no filters, it chooses any available square at random--important to have that last so that you will move somewhere
            // You can combine rules: if you only want the center if you are player X, the first rule could instead be "IS_CENTER+PARTNER_IN_ROW"

            // if the the AI goes second

                if(this.PlayerMarker == TicTacToeBoard.CHOICE.O && board.getSquare(1,1) == TicTacToeBoard.CHOICE.EMPTY)
            {
                return (TicTacToeAction)board.availableActions().applyRules(new string[]{
                    "CAN_WIN",    // See if you can win
                    "CAN_LOSE",    // See if you are going to lose
                    "IS_CENTER",      // Bc of the if statement the middle is open
                    ""          // Place anywhere so a move would be made no matter what
                });
            }
            else if(this.PlayerMarker == TicTacToeBoard.CHOICE.O && board.getSquare(1,1) == TicTacToeBoard.CHOICE.X) {
                return (TicTacToeAction)board.availableActions().applyRules(new string[]{
                    "CAN_WIN",    // See if you can win
                    "CAN_LOSE",    // See if you are going to lose
                    "IS_CENTER",      // Place in the center tile
                    "OPPONENT_ON_DIAGONAL_1 + IS_CORNER", //forces the middle and corner to use up one move from other player to force a tie.
                    ""              // Place anywhere so a move would be made no matter what
                });
            }

                //if the AI goes first
                return (TicTacToeAction)board.availableActions().applyRules(new string[]{
                    "CAN_WIN",    // See if you can win
                    "CAN_LOSE",    // See if you are going to lose
                    "IS_CORNER",      // Place in a corner tile to set up a side or diagnal win.
                    ""          // Place anywhere so a move would be made no matter what
                                
                });
           
                
            
                    
                
                
            
            
                
            
            
        }

    }
}
