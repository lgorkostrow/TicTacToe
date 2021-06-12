using System;
using TicTacToe.Core.Enums;
using TicTacToe.Core.Models;
using Xunit;

namespace TicTacToe.Core.Test.Models
{
    public class PlayerTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldThrowExceptionOnEmptyName(string? name)
        {
            Action a = () => new Player(name, MarkerEnum.O);
            
            Assert.Throws<Exception>(a);
        }

        [Theory]
        [InlineData("Vasya")]
        [InlineData("Petya")]
        public void ShouldCreatePlayer(string name)
        {
            var player = new Player(name, MarkerEnum.O);
            
            Assert.Equal(name, player.Name);
        }
    }
}