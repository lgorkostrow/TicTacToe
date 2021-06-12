namespace TicTacToe.Core.Models
{
    public class GamePvE : Game
    {
        public GamePvE(Player[] players) : base(players)
        {
        }

        public override void Mark(int index)
        {
            throw new System.NotImplementedException();
        }
    }
}