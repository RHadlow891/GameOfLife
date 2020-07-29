using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Grid grid = new Grid();
            grid.displayGrid();
            Console.ReadKey();
        }
    }
}
