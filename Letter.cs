using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle_Solver
{
    public class Letter
    {
        public bool IsInCorrectPlace { get; set; } = false;
        public bool IsCorrectLetter { get; set; } = false;
        public string ActualLetter { get; set; }


        public Letter(string letter)
        {
            ActualLetter = letter;
        }

    }
}
