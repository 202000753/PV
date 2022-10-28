using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public Student()
        {
        }

        public Student(string name, int number)
        {
            Name = name;
            Number = number;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Number: {Number}";
        }
    }
}
