using AccountPractice2.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountPractice2.Models
{
    public class Student
    {
        private static int _id;
        private double _point;
        private string _fullname;
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
        public double Point
        {
            get { return _point; }
            set
            {
                if (value >= 0 || value <= 100)
                    _point = value;
                else throw new InvalidPointException("Bal 0-100 arası qeyd oluna bilər");
            }
        }

        static Student()
        {
            _id = 0;
        }

        private Student()
        {
            _id++;
            Id = _id;
        }

        public Student(string fullname, double point) : this()
        {
            Fullname = fullname;
            Point = point;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Id - {Id} \n Fullname - {Fullname} \n Email - {Point}");
        }
    }
}
