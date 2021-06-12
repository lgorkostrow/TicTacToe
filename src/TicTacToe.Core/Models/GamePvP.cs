using System;
using System.Linq;

namespace TicTacToe.Core.Models
{
    public class GamePvP : Game
    {
        public GamePvP(Player[] players) : base(players)
        {
        }
        
        public override void Mark(int index)
        {
            if (index < 0 || index > Board.Data.Length - 1)
            {
                throw new Exception("Invalid index");
            }
            
            if (Board.IsFilled())
            {
                throw new Exception("Board is filled");
            }
            
            Board.Mark(index, CurrentPlayer.Marker);

            if (!Board.IsFilled() && !Board.IsWinningCombinationExists())
            {
                CurrentPlayer = Players.First(p => p != CurrentPlayer);
                
                return;
            }

            Finish();
            if (Board.IsWinningCombinationExists())
            {
                Winner = CurrentPlayer;
            }
        }
    }
}