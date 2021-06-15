using System;
using System.Linq;
using TicTacToe.Core.Enums;

namespace TicTacToe.Core.Models
{
    public abstract class Game
    {
        public Board Board { get; }
        public Player[] Players { get; }
        public Player CurrentPlayer { get; protected set; }
        public Player? Winner { get; protected set; }
        
        private GameStateEnum _state;
        public bool Finished => GameStateEnum.Finished == _state;

        protected Game(Player[] players)
        {
            if (players.Length != 2)
            {
                throw new Exception("Invalid players count");
            }

            if (players.Length != players.Select(x => x.Name).Distinct().ToArray().Length)
            {
                throw new Exception("Use unique names");
            }
            
            if (players.Length != players.Select(x => x.Marker).Distinct().ToArray().Length)
            {
                throw new Exception("Use unique markers");
            }
            
            Players = players;

            Board = new Board();
            _state = GameStateEnum.InProcess;
            CurrentPlayer = Players.First();
        }

        public virtual void Mark(int index)
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

        protected void Finish()
        {
            _state = GameStateEnum.Finished;
        }
    }
}