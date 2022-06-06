using HunterAndPrey.Models;
using Xunit;

namespace HunterAndPrey.Test.Models
{
    public class BoardTest
    {
        private Board _board;

        public BoardTest()
        {
            _board = new Board(2, 30, 30);
        }

        [Theory]
        [InlineData(22, 29)]
        [InlineData(23, 22)]
        [InlineData(1, 1)]
        [InlineData(22, 1)]
        [InlineData(29, 1)]
        [InlineData(2, 5)]
        [InlineData(3, 6)]
        [InlineData(16, 22)]
        public void ShouldBeAbleToGetNeighbours(int x, int y)
        {
            //Arrange and Act
            var neighbours = _board.GetNeighbours(x, y);

            //Assert
            Assert.NotNull(neighbours);

            foreach (Cell cell in neighbours)
            {
                Assert.True(cell.X == x + 1 || cell.X == x - 1 || cell.X == x);
                Assert.True(cell.Y == y + 1 || cell.Y == y - 1 || cell.Y == y);                
            }
        }
    }
}