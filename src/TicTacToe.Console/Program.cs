using System;
using System.Threading.Tasks;
using TicTacToe.Core.Enums;
using TicTacToe.Core.Factories;

namespace TicTacToe.Console
{
    class Program
    {
        private static readonly GamePrinter _gamePrinter = new GamePrinter();

        static async Task Main(string[] args)
        {
            System.Console.WriteLine($"Chose game mode: {GameModeEnum.PvP}({(int) GameModeEnum.PvP}), {GameModeEnum.PvE}({(int) GameModeEnum.PvE})");
            
            var gameModeInt = int.Parse(System.Console.ReadLine() ?? throw new InvalidOperationException());
            if (!Enum.IsDefined(typeof(GameModeEnum), gameModeInt))
            {
                throw new Exception("Invalid game type");
            }
            var gameMode = (GameModeEnum) gameModeInt;

            var game = GameFactory.Create(gameMode, GetPlayersName(gameMode));

            while (!game.Finished)
            {
                System.Console.Clear();

                _gamePrinter.PrintCells(game);
                _gamePrinter.PrintGameInfo(game);

                System.Console.WriteLine("Enter the index:");
                var index = System.Console.ReadLine();

                try
                {
                    game.Mark(int.Parse(index));
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Message);

                    await Task.Delay(2000);
                }
            }

            _gamePrinter.PrintGameResult(game);
        }

        static string[] GetPlayersName(GameModeEnum gameModeEnum)
        {
            System.Console.WriteLine("Enter the Player one name:");
            var player1Name = GetName();

            if (GameModeEnum.PvE == gameModeEnum)
            {
                return new[] {player1Name};
            }

            System.Console.WriteLine("Enter the Player two name:");
            var player2Name = GetName();

            return new[] {player1Name, player2Name};
        }

        static string GetName()
        {
            var name = System.Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Name can't be empty");
            }

            return name;
        }
    }
}