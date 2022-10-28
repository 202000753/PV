using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Course
    {
        public string Name { get; set; }
        public string SchoolYear { get; set; }
        private readonly IList<Student> students = new List<Student>();


        public Course(string nome)
        {
            Name = nome;
            SchoolYear = "2021/2022";
        }

        public void Inscrever(Student student)
        {

            students.Add(student);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name).Append(" -- Ano lectivo: ").Append(SchoolYear);

            if (students.Count > 0)
            {
                sb.Append("\nAlunos:\n");
                foreach (Student student in students)
                    sb.Append(student.ToString()).Append("\n");
            }

            return sb.ToString();
        }

        public int TotalStudents
        {
            get
            {
                return students != null ? students.Count : 0;
            }
        }
    }
}
