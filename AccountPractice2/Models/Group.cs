using AccountPractice2.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPractice2.Models
{
    public class Group
    {
        private int _studentLimit;
        private string _groupNo;
        private Student[] _students;

        public string GroupNo
        {
            get { return _groupNo; }
            set
            {
                if (String.IsNullOrEmpty(value) || !String.IsNullOrWhiteSpace(value))
                    _groupNo = value;
                else throw new InvalidGroupNumberException("Qrup nömrəsi yanlışdır");
            }
        }
        public int StudentLimit
        {
            get { return _studentLimit; }
            set
            {
                if (value >= 5 || value <= 18)
                    _studentLimit = value;
                else throw new StudentLimitException("Qrup 5 nəfərdən az 18 nəfərdən çox ola bilməz");
            }
        }

        private Group()
        {
            _students = new Student[0];
        }

        public Group(string groupNo, int studentLimit) : this()
        {
            GroupNo = groupNo;
            StudentLimit = studentLimit;
        }

        public static bool CheckStudentLimit(int studentLimit)
        {
            if (studentLimit >= 5 && studentLimit <= 18)
                return true;
            throw new StudentLimitException("Qrup 5 nəfərdən az 18 nəfərdən çox ola bilməz");
        }

        public static bool CheckGroupNo(string groupNo)
        {
            if (groupNo.Length == 5 && !String.IsNullOrEmpty(groupNo) && !String.IsNullOrWhiteSpace(groupNo))
            {
                int upper = 0;
                int digit = 0;
                for (int i = 0; i < groupNo.Length; i++)
                {
                    if (i < 2)
                    {
                        if (char.IsUpper(groupNo[i])) upper++;
                    }
                    else if (upper == 2 && i >= 2)
                    {
                        if (char.IsDigit(groupNo[i]))
                        {
                            digit++;
                        }
                    }
                    else return false;

                    if (upper == 2 && digit == 3) return true;
                }
            }
            throw new InvalidGroupNumberException("Qrup nömrəsi yanlışdır");
        }

        public void AddStudent(Student st)
        {
            if (_students.Length < StudentLimit)
            {
                _students = new Student[_students.Length + 1];
                _students[_students.Length - 1] = st;
            }
            else throw new ArgumentOutOfRangeException();
        }

        public Student GetStudent(int? id)
        {
            if (id != null)
            {
                foreach (Student item in _students)
                {
                    if (item.Id == id)
                    {
                        return item;
                    }
                    else throw new NotFoundException("Id tapılmadı");
                }
            }
            throw new NullReferenceException();
        }

        public Student[] GetAllStudents()
        {
            return _students;
        }
    }
}
