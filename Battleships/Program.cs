using System;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            BattleshipsGame game = new BattleshipsGame();
            game.Init(new BattleshipsGrid() { Size = 10 });
            game.Play();
            Console.ReadLine();
        }
    }
}
