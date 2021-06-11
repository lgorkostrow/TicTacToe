using System;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {
        public Board Board { get; }
        public Player[] Players { get; }
        public Player CurrentPlayer { get; private set; }
        public Player? Winner { get; private set; }
        public bool Finished { get; private set; }

        public Game(Player[] players)
        {
            if (players.Length != 2)
            {
                throw new Exception("Invalid players count");
            }
            
            Players = players;

            Board = new Board();
            Finished = false;
            CurrentPlayer = Players.First();
        }

        public void Mark(int index)
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

            if (!Board.IsFilled() && !IsWinnerExists())
            {
                CurrentPlayer = Players.First(p => p != CurrentPlayer);
                
                return;
            }

            Finished = true;
            if (IsWinnerExists())
            {
                Winner = CurrentPlayer;
            }
        }
        
        public string Print()
        {
            return $"Current player: {CurrentPlayer.Name} - {CurrentPlayer.Marker} \n" +
                   $"{Board.Print()} \n";
        }

        public string PrintCells()
        {
            return Board.PrintCells();
        }

        public string PrintResult()
        {
            if (!Finished)
            {
                throw new Exception("Game is not finished");
            }

            return Winner == null ? "Result: Draw" : $"Winner is {Winner.Name}";
        }

        private bool IsWinnerExists()
        {
            return Board.CheckColumns() || Board.CheckRows() || Board.CheckDiagonals();
        }
    }
}