using System.Text;
using TicTacToe.Core.Models;

namespace TicTacToe.Console
{
    public class GamePrinter
    {
        public void PrintBoard(Game game)
        {
            var s = new StringBuilder();
            
            for (int i = 0; i < game.Board.Data.Length; i++) 
            {
                if ((i + 1) % 3 == 0) 
                {
                    s.Append(game.Board.Data[i]);
                    
                    if (i != game.Board.Data.Length - 1) 
                    {
                        s.Append("\n-----\n");
                    }
                    
                    continue;
                } 
                
                s.Append(game.Board.Data[i] + "|");
            }
            
            System.Console.WriteLine(s);
        }
        
        public void PrintGameInfo(Game game)
        {
            System.Console.WriteLine($"Current player: {game.CurrentPlayer.Name} - {game.CurrentPlayer.Marker}");
            PrintBoard(game);
        }

        public void PrintCells(Game game)
        {
            var s = new StringBuilder();
            
            for (int i = 0; i < game.Board.Data.Length; i++) 
            {
                if ((i + 1) % 3 == 0)
                {
                    s.Append(i);
                    
                    if (i != game.Board.Data.Length - 1) 
                    {
                        s.Append("\n-----\n");
                    }
                    
                    continue;
                } 
                
                s.Append(i + "|");
            }
            
            System.Console.WriteLine(s.ToString());
        }

        public void PrintGameResult(Game game)
        {
            System.Console.Clear();
            
            PrintBoard(game);

            System.Console.WriteLine(game.Winner == null ? "Result: Draw" : $"Winner is {game.Winner.Name} - {game.Winner.Marker}");
        }
    }
}