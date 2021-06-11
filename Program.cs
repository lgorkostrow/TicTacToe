using System;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter the Player one name:");
            var player1Name = Console.ReadLine();
            if (string.IsNullOrEmpty(player1Name))
            {
                throw new Exception("Name can't be empty");
            }
            
            Console.WriteLine("Enter the Player two name:");
            var player2Name = Console.ReadLine();
            if (string.IsNullOrEmpty(player2Name) || player2Name == player1Name)
            {
                throw new Exception("Name can't be empty or equals to the player one name");
            }

            var players = new[]
            {
                new Player(player1Name, MarkerEnum.X),
                new Player(player2Name, MarkerEnum.O),
            };

            var game = new Game(players);
            
            while (!game.Finished)
            {
                Console.Clear();
                Console.WriteLine(game.PrintCells());
                Console.WriteLine(game.Print());
                
                Console.WriteLine("Enter the index:");
                var index = Console.ReadLine();

                try
                {
                    game.Mark(Int32.Parse(index));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    await Task.Delay(2000);
                }
            }
            
            Console.WriteLine(game.PrintResult());
        }
    }
}