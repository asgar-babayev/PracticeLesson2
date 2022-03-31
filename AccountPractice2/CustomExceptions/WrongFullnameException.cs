using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPractice2.CustomExceptions
{
    public class WrongFullnameException : Exception
    {
        public WrongFullnameException(string message) : base(message)
        {

        }
    }
}
