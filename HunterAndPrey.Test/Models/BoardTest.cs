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

        [Fact]
        public void ShouldBeAbleToMoveToAnotherPosition()
        {
            //Arrange
            var neighbours = _board.GetNeighbours(_board.Hunter.X, _board.Hunter.Y);
            var hunter = _board.Hunter;

            var hunterX = hunter.X;
            var hunterY = hunter.Y;

            var cell = neighbours[0];

            var cellX = cell.X;
            var cellY = cell.Y;            

            //Act
            _board.MovePosition(hunter, cell.X, cell.Y);

            //Assert
            var cellReference = _board.GetCell(hunterX, hunterY);

            Assert.Equal(hunter.X, cellX);
            Assert.Equal(hunter.Y, cellY);
            Assert.Equal(cellReference.X, hunterX);
            Assert.Equal(cellReference.Y, hunterY);
            Assert.IsType<Empty>(cellReference);
        }
    }
}