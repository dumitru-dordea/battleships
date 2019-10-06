using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    public interface IShip
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Direction Direction { get; set; }
        public int Length { get; set; }
        public bool IsAlive();
        public ShotResult Shot(int x, int y);
    }
}
