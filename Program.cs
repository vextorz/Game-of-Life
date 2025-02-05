///////////////////////////////////////////////////////////////////////////////////////
/// Change history

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayUserInterface();

            Console.Write("How many generations in this sim: ");
            int numGenerations = int.Parse(Console.ReadLine());

            Console.Write("How many rows do you want in the game field: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("How many columns do you want in the game field: ");
            int cols = int.Parse(Console.ReadLine());

            // here is our singlton object that represents the actual "game play"
            Life game = new Life(rows, cols);
            game.Play(numGenerations);
        }

        private static void DisplayUserInterface()
        {
            Console.WriteLine(@"
DISPLAY THE USER INTERFACE ...
");
        }
    }
}
