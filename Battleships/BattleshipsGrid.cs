using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    public class BattleshipsGrid
    {
        public int Size { get; set; }

        private List<Ship> Ships = new List<Ship>();

        public void AddShip(Ship newShip)
        {            
            Ships.Add(newShip);
        }

        public bool AnyShipAlive()
        {
            foreach(var ship in Ships)
            {
                if (ship.IsAlive())
                    return true;
            }
            return false;
        }

        internal ShotResult Shot(int x, int y)
        {
            foreach (var ship in Ships)
            {
                ShotResult shotResult = ship.Shot(x, y);
                if (shotResult != ShotResult.Miss)
                    return shotResult;
            }
            return ShotResult.Miss;
        }
    }
}
