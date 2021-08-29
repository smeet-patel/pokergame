using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokergame
{
    class Program
    {
        static void Main(string[] args)
        {
            //title
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "2 Card Poker Game ♣♠♥♦";
            Console.WriteLine("2 Card Poker Game ♣♠♥♦\n");
            Game g = new Game();
            //set quit to false in case we want end the console app
            bool quit = false;

            while (!quit)
            {
                g.RunGame();
            }
            Console.ReadKey();
        }

    }
}
