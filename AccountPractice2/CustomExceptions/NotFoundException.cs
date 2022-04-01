using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPractice2.CustomExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
