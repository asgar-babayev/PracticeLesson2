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
            SetFullname(out string fullname);
            SetEmail(out string email);
            SetPassword(out string password);
            User user = new User(fullname, email, password);
            string groupno = "";
            int stLimit = 0;
            int choise = 0;
            do
            {
                Console.WriteLine(@"0 - Quit
1 - Show info
2 - Create new group");

                SetChoise(ref choise);

                switch (choise)
                {
                    case 0:
                        break;
                    case 1:
                        user.ShowInfo();
                        Console.WriteLine("-------------------------------------------------------");
                        break;
                    case 2:
                        SetGroupNo(out string groupNo);
                        SetStudentLimit(out int studentLimit);
                        groupno = groupNo;
                        stLimit = studentLimit;
                        Group group = new Group(groupNo, studentLimit);
                        Console.WriteLine("Qrup yaradıldı");
                        Console.WriteLine("-------------------------------------------------------");
                        break;
                    default:
                        break;
                }

            } while (choise != 0);

            do
            {
                Console.WriteLine(@"0 - Quit
1 - Show all students
2 - Get student by id
3 - Add student");

                SetChoise(ref choise);
                Group gr = new Group(groupno, stLimit);
                switch (choise)
                {
                    case 1:
                        try
                        {
                            foreach (var item in gr.GetAllStudents())
                            {
                                Console.WriteLine($@"ID - {item.Id}
Full Name - {item.Fullname}
Point - {item.Point}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        SetStudentId(out int id);
                        try
                        {
                            gr.GetStudent(id);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        SetStudentFullname(out string fullnameS);
                        SetStudentPoint(out double point);
                        Student st = new Student(fullnameS, point);
                        try
                        {
                            if (groupno != "" && stLimit != 0)
                                gr.AddStudent(st);
                            else throw new Exception("Qrup olmadan telebe elave ede bilmezsiniz");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    default:
                        break;
                }
            } while (choise != 0);
        }
        static void SetFullname(out string fullname)
        {
        SetFullname:
            try
            {
                Console.Write("Ad soyad daxil edin: ");
                fullname = Console.ReadLine();
                User.FullnameChecker(fullname);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto SetFullname;
            }
        }
        static void SetStudentFullname(out string fullnameS)
        {
        SetFullname:
            try
            {
                Console.Write("Ad soyad daxil edin: ");
                fullnameS = Console.ReadLine();
                User.FullnameChecker(fullnameS);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto SetFullname;
            }
        }
        static void SetEmail(out string email)
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
        static void SetPassword(out string password)
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
        static void SetGroupNo(out string groupNo)
        {
        SetgroupNo:
            try
            {
                Console.Write("Qrup nömrəsini daxil edin: ");
                groupNo = Console.ReadLine();
                Group.CheckGroupNo(groupNo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto SetgroupNo;
            }
        }
        static void SetStudentLimit(out int studentLimit)
        {
        SetStudentLimit:
            try
            {
                Console.Write("Tələbə sayısını daxil edin: ");
                studentLimit = Convert.ToInt32(Console.ReadLine());
                Group.CheckStudentLimit(studentLimit);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                goto SetStudentLimit;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto SetStudentLimit;
            }
        }
        static void SetStudentPoint(out double point)
        {
        SetStudentLimit:
            try
            {
                Console.Write("Bal daxil edin: ");
                point = Convert.ToInt32(Console.ReadLine());
                if (point < 0 || point > 100)
                    throw new InvalidPointException("Bal 0-100 arası qeyd oluna bilər");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                goto SetStudentLimit;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto SetStudentLimit;
            }
        }
        static void SetStudentId(out int id)
        {
        SetStudentLimit:
            try
            {
                Console.Write("Id daxil edin: ");
                id = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                goto SetStudentLimit;
            }
        }
        static void SetChoise(ref int choise)
        {
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
        }
    }
}

