using System;

namespace HandCricket
{
    class Program
    {
        static void Main()
        {
            Player playerA = new Player("A");
            Player playerB = new Player("B");
            GameSimulator.SimulateGame(playerA, playerB);
            Console.Read();
        }
    }
}
