using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleships
{
    public class Ship
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Direction Direction { get; set; }
        public int Length { get; set; }

        private List<int> HitList = new List<int>();               

        public bool IsAlive()
        {
            return HitList.Count() < Length;
        }

        internal ShotResult Shot(int x, int y)
        {
            if (Direction == Direction.Horizontal)
            {
                if (x >= PosX && x < PosX + Length && y == PosY)
                {
                    int squareIndex = x - PosX;
                    SetHitSquare(squareIndex);
                    return IsAlive() ? ShotResult.Hit : ShotResult.Sink;
                }
            }
            else
            {
                if (x == PosX && y >= PosY && y < PosY + Length)
                {
                    int squareIndex = y - PosY;
                    SetHitSquare(squareIndex);
                    return IsAlive() ? ShotResult.Hit : ShotResult.Sink;
                }
            }
            return ShotResult.Miss;
        }

        private void SetHitSquare(int squareIndex)
        {
            if (!HitList.Contains(squareIndex))
                HitList.Add(squareIndex);
        }
    }
}
