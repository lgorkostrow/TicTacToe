using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Core.Enums;

namespace TicTacToe.Core.Models
{
    public class Move
    {
        public int MoveIndex { get; }
        public int Score { get; }

        public Move(int moveIndex, int score)
        {
            MoveIndex = moveIndex;
            Score = score;
        }
    }
    
    public class GamePvE : Game
    {
        private static readonly IDictionary<MarkerEnum, int> Scores = new Dictionary<MarkerEnum, int>()
        {
            {MarkerEnum.X, -10},
            {MarkerEnum.O, 10},
        };
        
        public GamePvE(Player[] players) : base(players)
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

                var move = FindBestMove();
                
                Board.Mark(move, CurrentPlayer.Marker);

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
                
                return;
            }

            Finish();
            if (Board.IsWinningCombinationExists())
            {
                Winner = CurrentPlayer;
            }
        }

        private int FindBestMove()
        {
            if (!IsCurrentPlayerBot())
            {
                throw new Exception("Bot should be a current player");
            }

            var bot = GetBot();
            var bestMove = new Move(int.MinValue, int.MinValue); 
            
            for (int i = 0; i < Board.Data.Length; i++)
            {
                if (!Board.IsCellEmpty(i)) continue;

                Board.Mark(i, bot.Marker);

                var score = Minimax(Board, 0, false);
                if (score > bestMove.Score)
                {
                    bestMove = new Move(i, score);
                }
                
                Board.SetToEmptyValue(i);
            }

            return bestMove.MoveIndex;
        }

        private int Minimax(Board board, int depth, bool isMaximizing)
        {
            if (board.IsFilled() && !board.IsWinningCombinationExists())
            {
                return 0;
            }
            
            if (board.IsWinningCombinationExists())
            {
                return isMaximizing ? Scores[board.GetWinedMark()] - depth : Scores[board.GetWinedMark()] + depth;
            }
            
            int bestScore;
            if (isMaximizing)
            {
                bestScore = int.MinValue;
                for (int i = 0; i < board.Data.Length; i++)
                {
                    if (!Board.IsCellEmpty(i)) continue;
                    
                    Board.Mark(i, GetBot().Marker);
                    
                    bestScore = Math.Max(
                        Minimax(board, depth + 1, !isMaximizing), 
                        bestScore
                    );
                    
                    Board.SetToEmptyValue(i);
                }

                return bestScore;
            }
            
            bestScore = int.MaxValue;
            for (int i = 0; i < board.Data.Length; i++)
            {
                if (!Board.IsCellEmpty(i)) continue;
                
                Board.Mark(i, GetHuman().Marker);
                
                bestScore = Math.Min(
                    Minimax(board, depth + 1, !isMaximizing), 
                    bestScore
                );
                
                Board.SetToEmptyValue(i);
            }

            return bestScore;
        }
        
        private bool IsCurrentPlayerBot()
        {
            return CurrentPlayer.Name == Player.BotName;
        }

        private Player GetBot()
        {
            var bot = Players.FirstOrDefault(x => x.Name == Player.BotName);
            if (bot == null)
            {
                throw new Exception("Bot is not found");
            }

            return bot;
        }
        
        private Player GetHuman()
        {
            var bot = Players.FirstOrDefault(x => x.Name != Player.BotName);
            if (bot == null)
            {
                throw new Exception("Human player is not found");
            }

            return bot;
        }
    }
}