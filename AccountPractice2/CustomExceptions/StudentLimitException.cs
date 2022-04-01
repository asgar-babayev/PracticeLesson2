using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPractice2.CustomExceptions
{
    internal class StudentLimitException : Exception
    {
        public StudentLimitException(string message) : base(message)
        {

        }
    }
}
