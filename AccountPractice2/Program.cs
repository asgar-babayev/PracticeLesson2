using AccountPractice2.CustomExceptions;
using AccountPractice2.Models;
using System;

namespace AccountPractice2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            SetUserFullname(out string fullname);
            SetUserEmail(out string email);
            SetUserPassword(out string password);
            User user = new User(fullname, email, password);
            user.ShowInfo();
            int choise;
            do
            {
                Console.WriteLine("1 - Show info \n 2 - Create new group");
            CheckChoise:
                try
                {
                    Console.Write("Seçim edin: ");
                    choise = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto CheckChoise;
                }

                switch (choise)
                {
                    case 1:
                        user.ShowInfo();
                        break;
                    default:
                        break;
                }
            } while (choise != 0);
        }

        static void SetUserFullname(out string fullname)
        {
        SetFullname:
            try
            {
                Console.Write("Ad daxil edin: ");
                fullname = Console.ReadLine();
                User.FullnameChecker(fullname);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto SetFullname;
            }

        }
        static void SetUserEmail(out string email)
        {
        CheckEmail:
            try
            {
                Console.Write("Email daxil edin: ");
                email = Console.ReadLine();
                User.EmailChecker(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto CheckEmail;
            }

        }
        static void SetUserPassword(out string password)
        {
        CheckPassword:
            try
            {
                Console.Write("Şifrə daxil edin: ");
                password = Console.ReadLine();
                User.PasswordChecker(password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto CheckPassword;
            }
        }
    }
}

