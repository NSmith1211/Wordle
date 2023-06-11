// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle_Solver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Solver s = new Solver();            
            s.SolveWordle();

            while (true)
            {
                Console.WriteLine("Would you like to play again? (Y/N)");
                string userInput = Console.ReadLine().ToUpper();

                if (userInput == "Y")
                {
                    Solver newGame = new Solver();
                    newGame.SolveWordle();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            
            
        }





    }
}