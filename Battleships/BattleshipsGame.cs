using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    public class BattleshipsGame
    {
        private static Random rnd = new Random();

        private BattleshipsGrid grid = new BattleshipsGrid();

        public void Init(int size)
        {
            grid.Size = size;

            bool[,] busyMap = new bool[size, size];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    busyMap[x, y] = false;
                }
            }

            Ship battleship = GetRandomShip(5, size);
            grid.AddShip(battleship);
            MarkBusyZone(battleship, ref busyMap, size);

            int destroyerCount = 0;
            while (destroyerCount < 2)
            {
                Ship destroyer = GetRandomShip(4, size);
                bool isOverBusyZone = ShipOverBusyZone(destroyer, busyMap, size);
                if (!isOverBusyZone)
                {
                    grid.AddShip(destroyer);
                    MarkBusyZone(battleship, ref busyMap, size);
                    destroyerCount++;
                }
            }
        }

        public void Play()
        {
            Console.WriteLine($"Battleships board: A1:{(char)('A' + grid.Size - 1)}{grid.Size}");
            while (grid.AnyShipAlive())
            {
                Console.Write("Shot:");
                string pos = Console.ReadLine().ToUpper();
                if (pos.Length >= 2)
                {
                    char col = pos[0];
                    Int32.TryParse(pos.Substring(1), out int row);
                    
                    int x = col - 'A';
                    int y = row - 1;
                    if (x >= 0 && x < grid.Size && y >= 0 && y < grid.Size)
                    {
                        ShotResult shotResult = grid.Shot(x, y);
                        Console.WriteLine(shotResult);
                    }
                    else
                    {
                        Console.WriteLine("Point outside of the Battleship board.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            Console.WriteLine("Game Over. All Battleships sinked!");
        }

        private void MarkBusyZone(Ship ship, ref bool[,] busyMap, int size)
        {
            int xLastPoint = ship.Direction == Direction.Horizontal ? ship.PosX + ship.Length - 1 : ship.PosX;
            int yLastPoint = ship.Direction == Direction.Horizontal ? ship.PosY : ship.PosY + ship.Length - 1;

            for (int x = ship.PosX - 1; x <= xLastPoint + 1; x++)
            {
                for (int y = ship.PosY - 1; y <= yLastPoint + 1; y++)
                {
                    if (x >= 0 && x < size && y >= 0 && y < size)
                    {
                        busyMap[x, y] = true;
                    }
                }
            }
        }

        private bool ShipOverBusyZone(Ship ship, bool[,] busyMap, int size)
        {
            for (int i = 0; i < ship.Length; i++)
            {
                int x = ship.Direction == Direction.Horizontal ? ship.PosX + i : ship.PosX;
                int y = ship.Direction == Direction.Horizontal ? ship.PosY : ship.PosY + i;
                if (busyMap[x, y])
                    return true;
            }
            return false;
        }

        private Ship GetRandomShip(int shipLength, int gridSize)
        {
            Ship ship = new Ship();
            ship.Length = shipLength;
            ship.Direction = rnd.Next(2) == 1 ? Direction.Horizontal : Direction.Vertical;
            if (ship.Direction == Direction.Horizontal)
            {
                ship.PosX = rnd.Next(gridSize - ship.Length);
                ship.PosY = rnd.Next(gridSize);
            }
            else
            {
                ship.PosX = rnd.Next(gridSize);
                ship.PosY = rnd.Next(gridSize - ship.Length);
            }
            return ship;
        }
    }
}
