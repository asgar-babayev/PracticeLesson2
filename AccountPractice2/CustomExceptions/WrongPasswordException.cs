using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPractice2.CustomExceptions
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException(string message) : base(message)
        {

        }
    }
}
