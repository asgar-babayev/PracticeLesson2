using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPractice2.CustomExceptions
{
    public class InvalidGroupNumberException : Exception
    {
        public InvalidGroupNumberException(string message) : base(message)
        {

        }
    }
}
