using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    public interface IBattleshipsGrid
    {
        public int Size { get; set; }

        public void AddShip(IShip newShip);
        public bool AnyShipAlive();
        public ShotResult Shot(int x, int y);
    }
}
