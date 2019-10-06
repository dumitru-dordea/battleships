using Battleships;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BattleshipsTests
{
    public class BattleshipsGridTest
    {
        [Fact]
        public void AddIShip_IShip_ReturnCount()
        {
            BattleshipsGrid _battleshipsGrid = new BattleshipsGrid();
            var ship = new Mock<IShip>();
            _battleshipsGrid.Ships.Add(ship.Object);

            var actual = _battleshipsGrid.Ships.Count;

            Assert.Equal(1, actual);
        }

        [Fact]
        public void AnyShipAlive_MockIShip_ReturnFalse()
        {
            BattleshipsGrid _battleshipsGrig = new BattleshipsGrid();

            var mock = new Mock<IShip>();

            _battleshipsGrig.AddShip(mock.Object);
            _battleshipsGrig.AddShip(mock.Object);
            _battleshipsGrig.AddShip(mock.Object);
            _battleshipsGrig.AddShip(mock.Object);
            _battleshipsGrig.AddShip(mock.Object);

            mock.Setup(ship => ship.IsAlive()).Returns(false);

            var actual = _battleshipsGrig.AnyShipAlive();

            Assert.False(actual);
        }

        [Fact]
        public void AnyShipAlive_MockIShip_ReturnFalseTrue()
        {
            BattleshipsGrid _battleshipsGrig = new BattleshipsGrid();
            var mock = new Mock<IShip>();

            _battleshipsGrig.AddShip(mock.Object);
            _battleshipsGrig.AddShip(mock.Object);
            _battleshipsGrig.AddShip(mock.Object);
            _battleshipsGrig.AddShip(mock.Object);
            _battleshipsGrig.AddShip(mock.Object);

            mock.SetupSequence(ship => ship.IsAlive())
                .Returns(false)
                .Returns(false)
                .Returns(false)
                .Returns(false)
                .Returns(true);

            var actual = _battleshipsGrig.AnyShipAlive();

            Assert.True(actual);
        }

        [Fact]
        public void AnyShipAlive_MockIShip_ReturnTrue()
        {
            BattleshipsGrid _battleshipsGrig = new BattleshipsGrid();
            var mock = new Mock<IShip>();

            _battleshipsGrig.AddShip(mock.Object);
            _battleshipsGrig.AddShip(mock.Object);
            _battleshipsGrig.AddShip(mock.Object);
            _battleshipsGrig.AddShip(mock.Object);
            _battleshipsGrig.AddShip(mock.Object);

            mock.Setup(ship => ship.IsAlive()).Returns(true);

            var actual = _battleshipsGrig.AnyShipAlive();

            Assert.True(actual);
        }

        [Fact]
        public void ShotResult_MockIShip_ReturnShotResult()
        {
            var mock = new Mock<IShip>();

            BattleshipsGrid _battleshipsGrig = new BattleshipsGrid();
            _battleshipsGrig.Size = 10;
            _battleshipsGrig.AddShip(mock.Object);

            mock.Setup(ship => ship.Shot(1, 1)).Returns(ShotResult.Hit);
            mock.Setup(ship => ship.Shot(1, 2)).Returns(ShotResult.Miss);

            var actual11 = _battleshipsGrig.Shot(1, 1);
            var actual12 = _battleshipsGrig.Shot(1, 2);

            Assert.Equal(ShotResult.Hit, actual11);
            Assert.Equal(ShotResult.Miss, actual12);
        }


        [Fact]
        public void ShotResult_MockMultipleIShip_ReturnShotResult()
        {
            var mock1 = new Mock<IShip>();
            var mock2 = new Mock<IShip>();

            BattleshipsGrid _battleshipsGrig = new BattleshipsGrid();
            _battleshipsGrig.Size = 10;
            _battleshipsGrig.AddShip(mock1.Object);
            _battleshipsGrig.AddShip(mock2.Object);

            mock1.Setup(ship => ship.Shot(1, 1)).Returns(ShotResult.Hit);
            mock2.Setup(ship => ship.Shot(1, 1)).Returns(ShotResult.Miss);

            var actual = _battleshipsGrig.Shot(1, 1);

            Assert.Equal(ShotResult.Hit, actual);
        }

    }
}
