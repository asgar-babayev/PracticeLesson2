using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPractice2.CustomExceptions
{
    public class InvalidPointException:Exception
    {
        public InvalidPointException(string message):base(message)
        {

        }
    }
}
