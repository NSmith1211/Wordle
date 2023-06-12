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
        



    }
}
