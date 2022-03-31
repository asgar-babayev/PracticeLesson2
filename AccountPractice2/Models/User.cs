using AccountPractice2.CustomExceptions;
using AccountPractice2.IModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPractice2.Models
{
    public class User : IAccount
    {
        private static int _id;
        private string _fullname;
        private string _email;
        private string _password;
        public int Id { get; }
        public string Fullname
        {
            get { return _fullname; }
            set
            {
                if (!String.IsNullOrWhiteSpace(_fullname) && !String.IsNullOrEmpty(_fullname))
                    _fullname = value;
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (!String.IsNullOrWhiteSpace(_email) && !String.IsNullOrEmpty(_email))
                    _email = value;
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (PasswordChecker(value))
                    _password = value;
            }
        }

        static User()
        {
            _id = 0;
        }

        private User()
        {
            _id++;
            Id = _id;
        }

        public User(string email, string password) : this()
        {
            Email = email;
            Password = password;
        }

        public User(string fullname, string email, string password) : this(email, password)
        {
            Fullname = fullname;
        }

        public static bool PasswordChecker(string password)
        {
            if (!String.IsNullOrEmpty(password) && !String.IsNullOrWhiteSpace(password) && password.Length >= 8)
            {
                int upper = 0;
                int lower = 0;
                int digit = 0;
                foreach (char item in password)
                {
                    if (char.IsUpper(item)) upper++;
                    else if (char.IsLower(item)) lower++;
                    else if (char.IsDigit(item)) digit++;

                    if (upper > 0 && lower > 0 && digit > 0)
                        return true;
                }
            }
            throw new WrongPasswordException(@"şifrədə minimum 8 character olmalıdır
şifrədə ən az 1 böyük hərf olmalıdır
şifrədə ən az 1 kiçik hərf olmalıdır
şifrədə ən az 1 rəqəm olmalıdır");
        }

        public static bool FullnameChecker(string fullname)
        {
            if (!String.IsNullOrWhiteSpace(fullname) && !String.IsNullOrEmpty(fullname))
                return true;
            throw new WrongFullnameException("Ad daxil etmək məcburidir");
        }
        public static bool EmailChecker(string email)
        {
            if (!String.IsNullOrWhiteSpace(email) && !String.IsNullOrEmpty(email))
                return true;
            throw new WrongEmailException("Email daxil etmək məcburidir");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Id - {Id} \nFullname - {Fullname} \nEmail - {Email}");
        }

    }
}
