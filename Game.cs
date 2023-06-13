using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    public class Game
    {
        public string TargetWord { get; set; }
        public string CurrentGuessString { get; set; }
        public string[] TargetWordArray = new string[5];
        public string[] CurrentGuess = new string[5];
        public Dictionary<string, Letter> AvailableLetters = new Dictionary<string, Letter>();
        public string[] ResultArray = new string[5];
        public List<string> ListOfGuesses = new List<string>();
        public int Turns { get; set; } = 5;
       

        public void PlayWordle()
        {
            Console.Title = "Wordle";
            FillAvailableLetters();
       
            Console.WriteLine("Please enter the target word:");
            string targetWord = WordsAvailable.GetRandomWord().ToUpper();            
            Console.Clear();
            
            this.TargetWord = targetWord;

            for (int i = 0; i < TargetWord.Length; i++)
            {
                TargetWordArray[i] = TargetWord[i].ToString().ToUpper();
            }

            CountTargetLetterAppearnces();
            AddIndexes();

            while (!IsGameOver())
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



        private string NewGuess()
        {
            
            AfterLoop:
            Console.Write("Please enter your guess: ");
            string guess = Console.ReadLine().ToUpper();
            if(WordsAvailable.CheckIfValidGuess(guess))
            {
                CurrentGuessString = guess;
            }
            else
            {
                goto AfterLoop;
            }


            

            for (int i = 0; i < guess.Length; i++)
            {
                CurrentGuess[i] = guess[i].ToString().ToUpper();
            }
            

            ListOfGuesses.Add(guess);

            for(int i = 0; i < CurrentGuess.Length; i++)
            {


                if (TargetWordArray.Contains(CurrentGuess[i]))
                {
                    AvailableLetters[CurrentGuess[i]].IsContainedLetter = true;
                    
                    

                }
                if (CurrentGuess[i] == TargetWordArray[i])
                {
                    AvailableLetters[CurrentGuess[i]].IsInCorrectPlace = true;

                    
                    
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

            foreach (string previousGuess in ListOfGuesses)
            {
                string[] newArray = new string[previousGuess.Length];
                for (int i = 0;i < newArray.Length; i++)
                {
                    newArray[i] = previousGuess[i].ToString().ToUpper();
                }

                ConsoleColor[] colors = DetermineLetterColor(newArray, TargetWordArray);

                for (int i = 0; i < colors.Length; i++)
                {
                    Console.ForegroundColor = colors[i];
                    Console.Write(previousGuess[i]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.WriteLine();
            }


            Console.WriteLine("\n");
            Console.WriteLine($"Turn Remaining: {Turns}");
            Console.Write("Latest Guess: ");

            ConsoleColor[] currentGuessColors = DetermineLetterColor(CurrentGuess,TargetWordArray);

            for (int i = 0; i < currentGuessColors.Length; i++)
            {
                Console.ForegroundColor = currentGuessColors[i];
                Console.Write(CurrentGuess[i]);
                Console.ForegroundColor = ConsoleColor.Gray;
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
                if (kvp.Value.IsContainedLetter)
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

        private bool IsGameOver()
        {
            bool isGameOver = false;

            if (CurrentGuessString == TargetWord)
            {
                Console.WriteLine($"CORRECT! The word was {this.TargetWord.ToUpper()}");
                isGameOver = true;
                return isGameOver;
            }
            if (this.Turns == 0)
            {
                Console.WriteLine($"Sorry, you ran out of turns! The word was: {TargetWord.ToUpper()}");
                isGameOver = true;                
            }
            

            return isGameOver;
        }

        private void CountTargetLetterAppearnces()
        {
            foreach(string letter in TargetWordArray)
            {
                AvailableLetters[letter].AmountInTargetWord += 1;
            }
        }

        
        private ConsoleColor[] DetermineLetterColor(string[] guess, string[] target)
        {
            ConsoleColor[] colors = new ConsoleColor[guess.Length];
            List<string> list = new List<string>();

            //Get unique letters
            for(int i  = 0; i < guess.Length; i++)
            {
                if (!list.Contains(guess[i]))
                {
                    list.Add(guess[i]);
                }
            }

            for (int i  = 0; i < guess.Length; i++)
            {
                AvailableLetters[guess[i]].AmountUsedInGuessWord += 1;
            }

            for (int i = 0; i < guess.Length; i++)
            {
                //Loop through unique values
                foreach(string letter in list)
                {
                   
                    for (int j = 0; j < AvailableLetters[letter].IndexesOfLetter.Count; j++)
                    {
                        if (guess[AvailableLetters[letter].IndexesOfLetter[j]] == target[AvailableLetters[letter].IndexesOfLetter[j]] && colors[AvailableLetters[letter].IndexesOfLetter[j]] != ConsoleColor.Green)
                        {
                            colors[AvailableLetters[letter].IndexesOfLetter[j]] = ConsoleColor.Green;
                            AvailableLetters[letter].LettersPlaced += 1;
                            AvailableLetters[letter].CountOfGreensInGuess += 1;
                            
                        }
                    }
                }
                
                if (target.Contains(guess[i]) && colors[i] != ConsoleColor.Green && AvailableLetters[guess[i]].LettersPlaced < AvailableLetters[guess[i]].AmountInTargetWord)
                {
                    colors[i] = ConsoleColor.DarkYellow;
                    AvailableLetters[guess[i]].LettersPlaced += 1;
                }
                else if (colors[i] != ConsoleColor.DarkYellow && colors[i] != ConsoleColor.Green)
                {
                    colors[i] = ConsoleColor.Gray;
                    AvailableLetters[guess[i]].LettersPlaced += 1;
                }
            }
            foreach (string item in list)
            {                
                    AvailableLetters[item].AmountUsedInGuessWord = 0;
                    AvailableLetters[item].CountOfGreensInGuess = 0;
                    AvailableLetters[item].LettersPlaced = 0;

            }


            return colors;
        }
        
        private void AddIndexes()
        {
            for(int i = 0; i < TargetWordArray.Length; i++)
            {
                AvailableLetters[TargetWordArray[i]].IndexesOfLetter.Add(i);
            }
        }

    }
}
