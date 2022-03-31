using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPractice2.Models
{
    public class Group
    {
        private int _studentLimit;
        private Student[] _students;
        public string GroupNo { get; set; }
        public int StudentLimit
        {
            get { return _studentLimit; }
            set
            {
                if (value >= 5 || value <= 18)
                    _studentLimit = value;
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

        public bool CheckGroupNo(string groupNo)
        {
            if (!String.IsNullOrEmpty(groupNo) && !String.IsNullOrWhiteSpace(groupNo) && groupNo.Length == 5)
            {
                int upper = 0;
                int digit = 0;
                foreach (var item in groupNo)
                {
                    if (char.IsUpper(item)) upper++;
                    else if (char.IsDigit(item)) digit++;

                    if (upper == 2 && digit == 3) return true;
                }
            }
            return false;
        }

        public void AddStudent(Student st)
        {
            Array.Resize(ref _students, _students.Length + 1);
            _students[_students.Length - 1] = st;
        }

        public Student GetStudent(int? id)
        {
            if (id != null)
            {
                for (int i = 0; i < _students.Length; i++)
                {
                    if (id == i)
                        return _students[i];
                }
                throw new Exception();
            }
            throw new NullReferenceException();
        }

        public Student[] GetAllStudents()
        {
            return _students;
        }

    }
}
