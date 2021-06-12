using System;
using TicTacToe.Core.Enums;
using TicTacToe.Core.Models;

namespace TicTacToe.Core.Factories
{
    public class GameFactory
    {
        public Game Create(GameModeEnum gameMode, params string[] playerNames)
        {
            return gameMode switch
            {
                GameModeEnum.PvP => CreatePvPGame(playerNames),
                GameModeEnum.PvE => CreatePvEGame(playerNames),
                _ => throw new NotImplementedException()
            };
        }

        private Game CreatePvPGame(string[] playerNames)
        {
            if (playerNames.Length != 2)
            {
                throw new Exception("For PvP game should be two players");
            }
            
            var players = new Player[]
            {
                new Player(playerNames[0], MarkerEnum.X),
                new Player(playerNames[1], MarkerEnum.O),
            };

            return new GamePvP(players);
        }
        
        private Game CreatePvEGame(string[] playerNames)
        {
            if (playerNames.Length != 1)
            {
                throw new Exception("For PvE game should be one player");
            }
            
            var players = new Player[]
            {
                new Player(playerNames[0], MarkerEnum.X),
                Player.CreateBot(), 
            };

            return new GamePvE(players);
        }
    }
}