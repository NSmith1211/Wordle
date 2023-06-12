// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Game s = new Game();            
            s.PlayWordle();

            while (true)
            {
                Console.WriteLine("Would you like to play again? (Y/N)");
                string userInput = Console.ReadLine().ToUpper();

                if (userInput == "Y")
                {
                    Game newGame = new Game();
                    newGame.PlayWordle();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            
            
        }





    }
}