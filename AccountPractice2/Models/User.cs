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
                if (!String.IsNullOrWhiteSpace(value) || !String.IsNullOrEmpty(value))
                    _fullname = value;
                else throw new WrongFullnameException("Ad daxil etmək məcburidir");
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (!String.IsNullOrWhiteSpace(value) || !String.IsNullOrEmpty(value))
                    _email = value;
                else throw new WrongEmailException("Email daxil etmək məcburidir");
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (!String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value) && value.Length >= 8)
                    _password = value;
                else throw new WrongPasswordException(@"şifrədə minimum 8 character olmalıdır
şifrədə ən az 1 böyük hərf olmalıdır
şifrədə ən az 1 kiçik hərf olmalıdır
şifrədə ən az 1 rəqəm olmalıdır");
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

        public User(string fullname, string email, string password) : this()
        {
            Fullname = fullname;
            Email = email;
            Password = password;
        }


        public static bool PasswordChecker(string password)
        {
            if (password.Length >= 8 && !String.IsNullOrEmpty(password) && !String.IsNullOrWhiteSpace(password))
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
            if (!String.IsNullOrWhiteSpace(fullname) || !String.IsNullOrEmpty(fullname))
                return true;
            throw new WrongFullnameException("Ad daxil etmək məcburidir");
        }
        public static bool EmailChecker(string email)
        {
            if (!String.IsNullOrWhiteSpace(email) || !String.IsNullOrEmpty(email))
                return true;
            throw new WrongEmailException("Email daxil etmək məcburidir");
        }

        public void ShowInfo()
        {
            Console.WriteLine(@$"Id - {Id}
Fullname - {Fullname} 
Email - {Email}");
        }

    }
}
