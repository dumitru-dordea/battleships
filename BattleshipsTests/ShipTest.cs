using Battleships;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BattleshipsTests
{
    public class ShipTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void IsAlive_AddHitValue_ReturnTrue(int value)
        {
            // Arrange
            var ship = new Ship();
            ship.Length = 4;
            // Act
            ship.HitList.Add(value);
            var actual = ship.IsAlive();
            // Assert
            Assert.True(actual);
        }

        [Theory]
        [InlineData(4)]
        public void IsAlive_AddHitValue_ReturnFalse(int value)
        {
            // Arrange
            var ship = new Ship();
            ship.Length = 4;
            ship.HitList = new List<int> { 0, 1, 2 };
            ship.HitList.Add(value);
            // Act
            var actual = ship.IsAlive();
            // Assert
            Assert.False(actual);
        }
        [Theory]
        [InlineData(5, 4)]
        public void Shot_AddShotHorizontal_ReturnMiss(int x, int y)
        {
            // Arrange
            var ship = new Ship();
            ship.Length = 4;
            ship.PosX = 1;
            ship.PosY = 5;
            ship.Direction = Direction.Horizontal;
            ship.HitList = new List<int> { 0, 1 };
            // Act
            var actual = ship.Shot(x, y);
            // Assert
            Assert.Equal(ShotResult.Miss, actual);
        }

        [Theory]
        [InlineData(3, 5)]
        public void Shot_AddShotHorizontal_ReturnHit(int x, int y)
        {
            // Arrange
            var ship = new Ship();
            ship.Length = 4;
            ship.PosX = 1;
            ship.PosY = 5;
            ship.Direction = Direction.Horizontal;
            ship.HitList = new List<int> { 0, 1 };
            // Act
            var actual = ship.Shot(x, y);
            // Assert
            Assert.Equal(ShotResult.Hit, actual);
        }

        [Theory]
        [InlineData(4, 5)]
        public void Shot_AddShotHorizontal_ReturnSink(int x, int y)
        {
            // Arrange
            var ship = new Ship();
            ship.Length = 4;
            ship.PosX = 1;
            ship.PosY = 5;
            ship.Direction = Direction.Horizontal;
            ship.HitList = new List<int> { 0, 1, 2 };
            // Act
            var actual = ship.Shot(x, y);
            // Assert
            Assert.Equal(ShotResult.Sink, actual);
        }

        [Theory]
        [InlineData(4, 5)]
        public void Shot_AddShotHorizontal_ReturnSinkShotResult(int x, int y)
        {
            // Arrange
            var ship = new Ship();
            ship.Length = 4;
            ship.PosX = 1;
            ship.PosY = 5;
            ship.Direction = Direction.Horizontal;
            ship.HitList = new List<int> { 0, 1, 2 };
            // Act
            var actual = ship.Shot(x, y);
            // Assert
            Assert.IsType<ShotResult>(actual);
        }

        [Theory]
        [InlineData(5, 4)]
        public void Shot_AddShotVertical_ReturnMiss(int x, int y)
        {
            // Arrange
            var ship = new Ship();
            ship.Length = 4;
            ship.PosX = 1;
            ship.PosY = 5;
            ship.Direction = Direction.Vertical;
            ship.HitList = new List<int> { 0, 1 };
            // Act
            var actual = ship.Shot(x, y);
            // Assert
            Assert.Equal(ShotResult.Miss, actual);
        }

        [Theory]
        [InlineData(1, 6)]
        public void Shot_AddShotVertical_ReturnHit(int x, int y)
        {
            // Arrange
            var ship = new Ship();
            ship.Length = 4;
            ship.PosX = 1;
            ship.PosY = 5;
            ship.Direction = Direction.Vertical;
            ship.HitList = new List<int> { 0, 1 };
            // Act
            var actual = ship.Shot(x, y);
            // Assert
            Assert.Equal(ShotResult.Hit, actual);
        }

        [Theory]
        [InlineData(1, 8)]
        public void Shot_AddShotVertical_ReturnSink(int x, int y)
        {
            // Arrange
            var ship = new Ship();
            ship.Length = 4;
            ship.PosX = 1;
            ship.PosY = 5;
            ship.Direction = Direction.Vertical;
            ship.HitList = new List<int> { 0, 1, 2 };
            // Act
            var actual = ship.Shot(x, y);
            // Assert
            Assert.Equal(ShotResult.Sink, actual);
        }

        [Theory]
        [InlineData(4, 5)]
        public void Shot_AddShotVertical_ReturnSinkShotResult(int x, int y)
        {
            // Arrange
            var ship = new Ship();
            ship.Length = 4;
            ship.PosX = 1;
            ship.PosY = 5;
            ship.Direction = Direction.Vertical;
            ship.HitList = new List<int> { 0, 1, 2 };
            // Act
            var actual = ship.Shot(x, y);
            // Assert
            Assert.IsType<ShotResult>(actual);
        }
    }
}
