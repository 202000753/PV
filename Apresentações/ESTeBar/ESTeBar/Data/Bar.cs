using ESTeBar.Models;

namespace ESTeBar.Data
{
    public class Bar
    {
        private static List<Person> barMembers = new List<Person>()
                {
                    new Person
                    {
                        Name = "Joao",
                        Age = 22
                    },
                    new Person
                    {
                        Name ="Ana",
                        Age = 25
                    },
                    new Person
                    {
                        Name ="Carlos",
                        Age = 21
                    }
                };
        public static List<Person> Members => barMembers;
    }
}
