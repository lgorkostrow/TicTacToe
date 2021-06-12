using System;
using TicTacToe.Core.Enums;

namespace TicTacToe.Core.Models
{
    public class Player
    {
        public const string BotName = "John Bot";
        
        public string Name { get; }
        public MarkerEnum Marker { get; }

        public Player(string name, MarkerEnum marker)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Name can't be empty");
            }
            
            Name = name;
            Marker = marker;
        }

        public static Player CreateBot(MarkerEnum marker = MarkerEnum.O)
        {
            return new Player(BotName, marker);
        }
    }
}