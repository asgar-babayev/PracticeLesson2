using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPractice2.IModels
{
    public interface IAccount
    {
        public static bool PasswordChecker(string password) { return false; }
        public void ShowInfo();
    }
}
