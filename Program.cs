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
            string todaysTargetWord = Console.ReadLine();
            Solver s = new Solver(todaysTargetWord);
            s.SolveWordle(todaysTargetWord);

            
        }





    }
}