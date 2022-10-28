using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class School
    {
        public void Run()
        {
            //
            // Introdução à utilização de LINQ
            //
            Console.WriteLine("\n\nIntrodução à utilização de LINQ\n");

            List<Student> stds = new List<Student> {
                            new Student {Name = "Joao Carlos", Number = 1234},
                            new Student {Name = "Jose Antunes", Number = 2345},
                            new Student {Name = "Joao Silva", Number = 3456},
                            new Student {Name = "Ana Costa", Number = 4567},
                            new Student {Name = "Ivo Tiago", Number = 5678},
                            new Student {Name = "Manuel Jose", Number = 6789},
                            new Student {Name = "Jose Jacinto", Number = 7890}
                        };

            Console.WriteLine("ALUNOS: \n");
            foreach (Student std in stds)
                Console.WriteLine("> " + std);

            Console.ReadKey();
            Console.Clear();

            // Selecciona alunos que têm José no nome
            var res = from s in stds where s.Name.Contains("Jose") select s;

            Console.WriteLine("\n\nALUNOS com o nome 'Jose': \n");

            foreach (var s in res)
                Console.WriteLine("> " + s);

            Console.ReadKey();
            Console.Clear();


            // Projecção de dados com tipos anónimos

            Course pv = new Course("Programação Visual");
            Course es = new Course("Engenharia de Software");

            pv.Inscrever(stds[0]);
            pv.Inscrever(stds[1]);
            es.Inscrever(stds[0]);
            es.Inscrever(stds[2]);

            Console.WriteLine("\nCursos:");
            Console.WriteLine(pv);
            Console.WriteLine(es);

            List<Course> courses = new List<Course>();
            courses.Add(pv);
            courses.Add(es);

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\n3 - Nome das disciplinas e número de alunos");
            var res3 = from c in courses select new { Name = c.Name, NumberStudents = c.TotalStudents };
            Console.WriteLine("\nDISCIPLINAS: \n");
            foreach (var r in res3)
            {
                Console.WriteLine("> " + r.Name + " com " + r.NumberStudents + " alunos.");
            }

            Console.ReadKey();
            Console.Clear();


            //
            // LINQ utilizando directamente os métodos de extensão
            //
            Console.WriteLine("\n\nLINQ utilizando directamente os métodos de extensão\n");

            // Selecciona alunos que têm José no nome
            Console.WriteLine("\n4 - Alunos que têm Jose no nome");
            // var res4 = from s in stds where s.Name.Contains("Jose") select s.Name;
            var res4 = stds.Where(s => s.Name.Contains("Jose")).OrderByDescending(s => s.Name).Select(s => s.Name);

            Console.WriteLine("\nALUNOS com o nome 'Jose': \n");
            foreach (var s in res4)
                Console.WriteLine("> " + s);

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\n5 - Alunos ordenados pelo nome");
            // var res5 = from s in stds orderby s.Name select s;
            var res5 = stds.OrderBy(s => s.Name).Select(s => s);

            Console.WriteLine("\nALUNOS: \n");
            foreach (var s in res5)
                Console.WriteLine("> " + s);

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\n6 - Nome dos alunos com número superior a 5000");
            //var res6 = from s in stds where s.Number > 5000 select s.Name;
            var res6 = stds.Where(s => s.Number > 5000).Select(s => s.Name);

            IEnumerable<string> nomesmais5000 = (stds.Where(s => s.Number > 5000).Select(s => s.Name)).ToList();

            Console.WriteLine("\nALUNOS: \n");
            foreach (var s in res6)
                Console.WriteLine("> " + s);

            Console.ReadKey();
        }

    }
}
