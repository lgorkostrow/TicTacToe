using System;
using System.Collections.Generic;
using TicTacToe.Core.Enums;
using TicTacToe.Core.Models;
using Xunit;

namespace TicTacToe.Core.Test.Models
{
    public class BoardTest
    {
        [Theory]
        [InlineData(MarkerEnum.O)]
        [InlineData(MarkerEnum.X)]
        public void ShouldMarkCell(MarkerEnum marker)
        {
            var index = 5;
            var board = new Board();
            
            Assert.Equal(" ", board.Data[index]);
            
            board.Mark(index, marker);
            
            Assert.Equal(marker.ToString(), board.Data[index]);
        }

        [Fact]
        public void ShouldThrowExceptionOnFillingNotEmptyCell()
        {
            var index = 3;
            var board = new Board();
            
            board.Mark(index, MarkerEnum.O);
            
            Action a = () => board.Mark(index, MarkerEnum.X);
            
            Assert.Throws<Exception>(a);
        }

        [Fact]
        public void ShouldReturnTrueOnFillingCheck()
        {
            var board = new Board();

            Assert.False(board.IsFilled());
            
            for (int i = 0; i < board.Data.Length; i++)
            {
                board.Mark(i, MarkerEnum.O);
            }
            
            Assert.True(board.IsFilled());
        }

        [Theory]
        [MemberData(nameof(WinningColumnCombinations))]
        public void ShouldReturnTrueOnColumnWin(int[] combination)
        {
            var board = new Board();
            
            Assert.False(board.CheckColumns());

            foreach (var index in combination)
            {
                board.Mark(index, MarkerEnum.X);
            }
            
            Assert.True(board.CheckColumns());
        }
        
        [Theory]
        [MemberData(nameof(WinningRowCombinations))]
        public void ShouldReturnTrueOnRowWin(int[] combination)
        {
            var board = new Board();
            
            Assert.False(board.CheckRows());

            foreach (var index in combination)
            {
                board.Mark(index, MarkerEnum.O);
            }

            Assert.True(board.CheckRows());
        }
        
        [Theory]
        [MemberData(nameof(WinningDiagonalCombinations))]
        public void ShouldReturnTrueOnDiagonalWin(int[] combination)
        {
            var board = new Board();
            
            Assert.False(board.CheckDiagonals());

            foreach (var index in combination)
            {
                board.Mark(index, MarkerEnum.O);
            }

            Assert.True(board.CheckDiagonals());
        }

        [Theory]
        [MemberData(nameof(AllWinedCombinations))]
        public void ShouldReturnWinedMark(int[] combination, MarkerEnum marker)
        {
            var board = new Board();

            foreach (var index in combination)
            {
                board.Mark(index, marker);
            }

            Assert.Equal(marker, board.GetWinedMark());
        }

        [Fact]
        public void ShouldThrowExceptionOnCallingGetWinedMarkWithoutWinner()
        {
            var board = new Board();
            
            Action a = () => board.GetWinedMark();
            
            Assert.Throws<Exception>(a);
        }

        public static IEnumerable<object[]> WinningColumnCombinations()
        {
            yield return new object[]
            {
                new int[] {0, 3, 6},
            };
            
            yield return new object[]
            {
                new int[] {1, 4, 7},
            };
            
            yield return new object[]
            {
                new int[] {2, 5, 8},
            };
        }
        
        public static IEnumerable<object[]> WinningRowCombinations()
        {
            yield return new object[]
            {
                new int[] {0, 1, 2},
            };
            
            yield return new object[]
            {
                new int[] {3, 4, 5},
            };
            
            yield return new object[]
            {
                new int[] {6, 7, 8},
            };
        }
        
        public static IEnumerable<object[]> WinningDiagonalCombinations()
        {
            yield return new object[]
            {
                new int[] {0, 4, 8},
            };
            
            yield return new object[]
            {
                new int[] {2, 4, 6},
            };
        }

        public static IEnumerable<object[]> AllWinedCombinations()
        {
            yield return new object[]
            {
                new int[] {0, 3, 6},
                MarkerEnum.X,
            };
            
            yield return new object[]
            {
                new int[] {1, 4, 7},
                MarkerEnum.O,
            };
            
            yield return new object[]
            {
                new int[] {2, 5, 8},
                MarkerEnum.X,
            };
            
            yield return new object[]
            {
                new int[] {0, 1, 2},
                MarkerEnum.O,
            };
            
            yield return new object[]
            {
                new int[] {3, 4, 5},
                MarkerEnum.X,
            };
            
            yield return new object[]
            {
                new int[] {6, 7, 8},
                MarkerEnum.O,
            };
            
            yield return new object[]
            {
                new int[] {0, 4, 8},
                MarkerEnum.X,
            };
            
            yield return new object[]
            {
                new int[] {2, 4, 6},
                MarkerEnum.O,
            };
        }
    }
}