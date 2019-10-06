using Battleships;
using System;
using System.Collections.Generic;
using System.Text;
public class BattleshipsGrid : IBattleshipsGrid
{
    public int Size { get; set; }

    public List<IShip> Ships = new List<IShip>();

    public void AddShip(IShip newShip)
    {
        Ships.Add(newShip);
    }

    public bool AnyShipAlive()
    {
        foreach (var ship in Ships)
        {
            if (ship.IsAlive())
                return true;
        }
        return false;
    }

    public ShotResult Shot(int x, int y)
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

