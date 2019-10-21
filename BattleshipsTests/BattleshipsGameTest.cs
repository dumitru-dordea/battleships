using Battleships;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BattleshipsTests
{
    public class BattleshipsGameTest
    {
        [Theory]
        [InlineData(10)]
        public void Init_AddShipLengthGridSize_ReturnBool(int size)
        {
            var battleshipsGame = new BattleshipsGame();
            battleshipsGame.BusyMap = new bool[size, size];

            var actual = battleshipsGame.BusyMap;

            Assert.IsType<bool[,]>(actual);
        }

        [Theory]
        [InlineData(4, 10)]
        public void GetRandomShip_AddShipLengthGridSize_ReturnShip(int shipLength, int gridSize)
        {
            var battleshipsGame = new BattleshipsGame();

            var actual = battleshipsGame.GetRandomShip(shipLength, gridSize);

            Assert.IsType<Ship>(actual);
            Assert.Equal(shipLength, actual.Length);
        }

        [Fact]
        public void MarkBusyZone_AddShipGridSize_ReturnBusyZoneTrue()
        {
            // Arrange
            var battleshipsGame = new BattleshipsGame();

            var mock = new Mock<IBattleshipsGrid>();
            mock.Setup(grid => grid.AddShip(It.IsAny<IShip>()));
            mock.Setup(grid => grid.Size).Returns(10);

            battleshipsGame.Init(mock.Object);
            mock.Verify(grid => grid.AddShip(It.IsAny<IShip>()), Times.Exactly(3));
        }
    }
}
