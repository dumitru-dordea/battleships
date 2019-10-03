using System;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            BattleshipsGame game = new BattleshipsGame();
            game.Init(10);
            game.Play();
            Console.ReadLine();
        }
    }
}
