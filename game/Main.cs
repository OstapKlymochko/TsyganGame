﻿using System;

namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Values.Ace.GetHashCode());
            GameTable.startGame(new Player[] {});
        }
    }
}
