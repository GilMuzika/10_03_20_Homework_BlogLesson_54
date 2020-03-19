
using System;
using System.Collections.Generic;
using System.Text;

namespace _10_03_20_Homework_BlogLesson_54
{
    class InputIsNotANumberException : Exception
    {
        public InputIsNotANumberException(string input) : base($"Your input \"{input}\" isn't a number") { }



        public static string GetMessageWithoutThrowing(string input)
        {            
            return $"Your input \"{input}\" isn't a number";            
        }
    }

}
