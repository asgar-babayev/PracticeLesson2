using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPractice2.CustomExceptions
{
    public class WrongEmailException : Exception
    {
        public WrongEmailException(string message) : base(message)
        {

        }
    }
}
