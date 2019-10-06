using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    public class BattleshipsGame
    {
        private readonly Random rnd = new Random();

        private IBattleshipsGrid Grid { get; set; }
        public bool[,] BusyMap { get; set; }
        public void Init(IBattleshipsGrid grid)
        {
            Grid = grid;

            BusyMap = new bool[grid.Size, grid.Size];
            for (int x = 0; x < grid.Size; x++)
            {
                for (int y = 0; y < grid.Size; y++)
                {
                    BusyMap[x, y] = false;
                }
            }

            Ship battleship = GetRandomShip(5, grid.Size);
            grid.AddShip(battleship);
            MarkBusyZone(battleship, grid.Size);

            int destroyerCount = 0;
            while (destroyerCount < 2)
            {
                Ship destroyer = GetRandomShip(4, grid.Size);
                bool isOverBusyZone = ShipOverBusyZone(destroyer);
                if (!isOverBusyZone)
                {
                    grid.AddShip(destroyer);
                    MarkBusyZone(battleship, grid.Size);
                    destroyerCount++;
                }
            }
        }

        public void Play()
        {
            Console.WriteLine($"Battleships board: A1:{(char)('A' + Grid.Size - 1)}{Grid.Size}");
            while (Grid.AnyShipAlive())
            {
                Console.Write("Shot:");
                string pos = Console.ReadLine().ToUpper();
                if (pos.Length >= 2)
                {
                    char col = pos[0];
                    Int32.TryParse(pos.Substring(1), out int row);

                    int x = col - 'A';
                    int y = row - 1;
                    if (x >= 0 && x < Grid.Size && y >= 0 && y < Grid.Size)
                    {
                        ShotResult shotResult = Grid.Shot(x, y);
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

        private void MarkBusyZone(Ship ship, int size)
        {
            int xLastPoint = ship.Direction == Direction.Horizontal ? ship.PosX + ship.Length - 1 : ship.PosX;
            int yLastPoint = ship.Direction == Direction.Horizontal ? ship.PosY : ship.PosY + ship.Length - 1;

            for (int x = ship.PosX - 1; x <= xLastPoint + 1; x++)
            {
                for (int y = ship.PosY - 1; y <= yLastPoint + 1; y++)
                {
                    if (x >= 0 && x < size && y >= 0 && y < size)
                    {
                        BusyMap[x, y] = true;
                    }
                }
            }
        }

        private bool ShipOverBusyZone(Ship ship)
        {
            for (int i = 0; i < ship.Length; i++)
            {
                int x = ship.Direction == Direction.Horizontal ? ship.PosX + i : ship.PosX;
                int y = ship.Direction == Direction.Horizontal ? ship.PosY : ship.PosY + i;
                if (BusyMap[x, y])
                    return true;
            }
            return false;
        }

        public Ship GetRandomShip(int shipLength, int gridSize)
        {
            var ship = new Ship();
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
