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
        public string[] TargetWordArray;
        public string[] CurrentGuess;

        public Dictionary<string, Letter> AvailableLetters = new Dictionary<string, Letter>();
        public string[] ResultArray;

        public void SolveWordle(string targetWord)
        {
            this.TargetWord = targetWord;
            FillAvailableLetters();
            
            string result = "";

            for(int i = 0; i < TargetWord.Length; i++)
            {
                TargetWordArray[i] = TargetWord[i].ToString().ToUpper();
            }

            while (NewGuess() != targetWord)
            {
                NewGuess();
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

        public void CountCorrectLetters()
        {
            int counter = 0;
            foreach(KeyValuePair<string,Letter> kvp in AvailableLetters)
            {
                if (kvp.Value.IsCorrectLetter)
                {
                    counter++;
                    Console.WriteLine($"The letter {kvp.Key} is in the target word. However, it is not in the correct place.");
                }
            }

            Console.WriteLine($"You have a total of {counter} correct letters.");
            
        }

        public void CountCorrectPlace()
        {
            int counter = 0;

            foreach (KeyValuePair<string, Letter> kvp in AvailableLetters)
            {
                if (kvp.Value.IsInCorrectPlace)
                {
                    counter++;
                    Console.WriteLine($"The letter {kvp.Key} is in the target word and in the correct place.");
                }
            }

            Console.WriteLine($"You have a total of {counter} correct letters in the correct place.");
        }


        public string NewGuess()
        {
            
            string displayWord = "";
            string guess = Console.ReadLine().ToUpper();


            if(guess == this.TargetWord)
            {
                Console.WriteLine("CORRECT! You guessed the right word");
                return guess;
            }

            for (int i = 0; i < guess.Length; i++)
            {
                CurrentGuess[i] = guess[i].ToString().ToUpper();
            }


            foreach (string letter in CurrentGuess)
            {
                if (TargetWord.Contains(letter))
                {
                    AvailableLetters[letter].IsCorrectLetter = true;
                    ResultArray[TargetWord.IndexOf(letter)] = letter;
                }
                if (TargetWord.IndexOf(letter) == guess.IndexOf(letter))
                {
                    AvailableLetters[letter].IsInCorrectPlace = true;
                    ResultArray[TargetWord.IndexOf(letter)] = letter;
                }
            }
           

            for(int i = 0; i <ResultArray.Length; i++)
            {
                if(ResultArray[i] == null)
                {
                    ResultArray[i] = "_";
                }
            }


            Console.WriteLine($"Turn Completed.");
            CountCorrectLetters();
            CountCorrectPlace();
            Console.WriteLine($"\n");
            
            DisplayProgress();

            return guess;
        }

        public void DisplayProgress()
        {
            
            foreach(string letter in ResultArray)
            {
                if(letter != "_")
                {
                    if (AvailableLetters[letter].IsInCorrectPlace)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(letter);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else if (AvailableLetters[letter].IsCorrectLetter)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(letter);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.Write($"{letter}");
                    }
                }
                else
                {
                    Console.Write($"{letter}");
                }
                
            }
            Console.WriteLine("\n");
        }


        public Solver(string word)
        {
            TargetWord = word;
            this.TargetWordArray = new string[word.Length];
            this.CurrentGuess = new string[word.Length];
            this.ResultArray = new string[word.Length];
        }
    }
}
