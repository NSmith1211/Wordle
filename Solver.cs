using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle_Solver
{
    public class Solver
    {
        public string TargetWord { get; set; }
        public string[] TargetWordArray = new string[5];
        public string[] CurrentGuess = new string[5];
        public Dictionary<string, Letter> AvailableLetters = new Dictionary<string, Letter>();
        public string[] ResultArray = new string[5];
        public List<string> ListOfGuesses = new List<string>();
        public int Turns { get; set; } = 5;

        public void SolveWordle()
        {
            Console.Title = "Wordle";
            FillAvailableLetters();

        
            Console.WriteLine("Please enter the target word:");
            string targetWord = Console.ReadLine().ToUpper();
            Console.Clear();
            
            this.TargetWord = targetWord;

            for (int i = 0; i < TargetWord.Length; i++)
            {
                TargetWordArray[i] = TargetWord[i].ToString().ToUpper();
            }

            while (NewGuess().ToUpper() != TargetWord && this.Turns > 0)
            {
                NewGuess();
                
            }

            if (this.Turns == 0 && !CurrentGuess.Equals(TargetWordArray))
            {
                Console.WriteLine("Sorry, you ran out of guesses.");
            }
                                                                   
        }


        private void FillAvailableLetters()
        {
            AvailableLetters["A"] = new Letter("A");
            AvailableLetters["B"] = new Letter("B");
            AvailableLetters["C"] = new Letter("C");
            AvailableLetters["D"] = new Letter("D");
            AvailableLetters["E"] = new Letter("E");
            AvailableLetters["F"] = new Letter("F");
            AvailableLetters["G"] = new Letter("G");
            AvailableLetters["H"] = new Letter("H");
            AvailableLetters["I"] = new Letter("I");
            AvailableLetters["J"] = new Letter("J");
            AvailableLetters["K"] = new Letter("K");
            AvailableLetters["L"] = new Letter("L");
            AvailableLetters["M"] = new Letter("M");
            AvailableLetters["N"] = new Letter("N");
            AvailableLetters["O"] = new Letter("O");
            AvailableLetters["P"] = new Letter("P");
            AvailableLetters["Q"] = new Letter("Q");
            AvailableLetters["R"] = new Letter("R");
            AvailableLetters["S"] = new Letter("S");
            AvailableLetters["T"] = new Letter("T");
            AvailableLetters["U"] = new Letter("U");
            AvailableLetters["V"] = new Letter("V");
            AvailableLetters["W"] = new Letter("W");
            AvailableLetters["X"] = new Letter("X");
            AvailableLetters["Y"] = new Letter("Y");
            AvailableLetters["Z"] = new Letter("Z");

        }



        private string NewGuess()
        {
            
            Console.Write("Please enter your guess: ");
            string guess = Console.ReadLine().ToUpper();

            if (guess.ToUpper() == this.TargetWord)
            {
                Console.WriteLine($"CORRECT! Your guess: {guess.ToUpper()}");               
                return guess.ToUpper();
            }
            

            for (int i = 0; i < guess.Length; i++)
            {
                CurrentGuess[i] = guess[i].ToString().ToUpper();
            }
            

            ListOfGuesses.Add(guess);

            for(int i = 0; i < TargetWord.Length; i++)
            {
                TargetWordArray[i] = TargetWord[i].ToString().ToUpper(); 
            }

            

            for(int i = 0; i < CurrentGuess.Length; i++)
            {
                
                
                    if (TargetWordArray.Contains(CurrentGuess[i]))
                    {
                        AvailableLetters[CurrentGuess[i]].IsCorrectLetter = true;


                    }
                    if (CurrentGuess[i] == TargetWordArray[i])
                    {
                        AvailableLetters[CurrentGuess[i]].IsInCorrectPlace = true;
                        AvailableLetters[CurrentGuess[i]].IndexInResult = i;
                        ResultArray[i] = CurrentGuess[i];
                    }
                    if (!TargetWordArray.Contains(CurrentGuess[i]))
                    {
                        AvailableLetters[CurrentGuess[i]].isPossibleLetter = false;
                    }
                
                
                
            }




            Console.WriteLine($"Turn Completed.");
            this.Turns -= 1;
            
            Console.WriteLine($"\n");
            
            DisplayProgress();

            return guess.ToUpper();
        }

        private void DisplayProgress()
        {
            Console.Clear();
            Console.WriteLine("Previous Guesses:");
            foreach(string previousGuess in ListOfGuesses)
            {
                
                for(int i = 0;i < previousGuess.Length; i++)
                {
                    if(AvailableLetters[previousGuess[i].ToString().ToUpper()].ActualLetter == TargetWordArray[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(previousGuess[i]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        continue;
                    }
                    if(AvailableLetters[previousGuess[i].ToString().ToUpper()].IsCorrectLetter && AvailableLetters[CurrentGuess[i].ToUpper()].ActualLetter != TargetWordArray[i])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(previousGuess[i]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        continue;

                    }
                    else
                    {
                        Console.Write($"{previousGuess[i]}");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n");
            Console.WriteLine($"Turn Remaining: {Turns}");
            Console.Write("Latest Guess: ");
            for(int i = 0; i < CurrentGuess.Length; i++)
            {
                if(CurrentGuess[i] != "_")
                {
                    if (AvailableLetters[CurrentGuess[i].ToUpper()].ActualLetter == TargetWordArray[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(CurrentGuess[i]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        continue;
                    }
                    if (AvailableLetters[CurrentGuess[i].ToUpper()].IsCorrectLetter && AvailableLetters[CurrentGuess[i].ToUpper()].ActualLetter != TargetWordArray[i])
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(CurrentGuess[i]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        continue;
                    }
                    else
                    {
                        Console.Write($"{CurrentGuess[i]}");
                    }
                                        
                }
                
                
            }
            Console.WriteLine("\nLetters:\n");
            foreach(KeyValuePair<string,Letter> kvp in AvailableLetters)
            {
                if (kvp.Value.IsInCorrectPlace)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{kvp.Key} ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
                if (kvp.Value.IsCorrectLetter)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"{kvp.Key} ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    continue;
                }
                if (kvp.Value.isPossibleLetter)
                {
                    Console.Write($"{kvp.Key} ");
                    continue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"{kvp.Key} ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            Console.WriteLine("\n");
        }

      
    }
}
