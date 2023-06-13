using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    public static class WordsAvailable
    {

        public static string GetRandomWord()
        {
            string selectedWord = "SHAME";
            try
            {

                string directory = Environment.CurrentDirectory;
                string fileName = "answers.txt";
                string fullPath = Path.Combine(directory, fileName);
                Random r = new Random();
                int lineNumber = r.Next(0, File.ReadLines(fullPath).Count());
                int currentLine = 0;

                using (StreamReader sr = new StreamReader(fullPath))
                {           
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();

                        if (currentLine == lineNumber)
                        {
                            selectedWord = line;
                            return selectedWord;
                        }
                        
                        currentLine++;
                    }
                    
                }

            }
            catch 
            {

                Console.WriteLine("Sorry, there was an error reading the file.");

            }

            return selectedWord;
        }

        public static bool CheckIfValidGuess(string guess)
        {
            try
            {
                string directory = Environment.CurrentDirectory;
                string fileName = "guesses.txt";
                string fullPath = Path.Combine(directory, fileName);

                using(StreamReader sr = new StreamReader(fullPath))
                {
                    if (sr.ReadToEnd().ToUpper().Contains(guess))
                    {
                        return true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Not a valid guess, please try again");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return false;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Sorry, an error occured retriveing your guess");
                return false;
            }

            
        }
        



    }
}
