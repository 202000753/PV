// See https://aka.ms/new-console-template for more information


using System;
using System.Collections.Generic;
using PersonLINQ;


List<Person> people = new List<Person>
            {
                new Person { Name = "João", Age = 20 },
                new Person {Name = "Ana", Age = 21},
                new Person {Name = "Carlos", Age = 20},
                new Person {Name = "Daniela", Age = 22},
                new Person {Name = "António", Age = 19},
                new Person {Name = "André", Age = 18},
                new Person {Name = "Bernardo", Age = 23},
            };

List<int> ages = new List<int>();

foreach (Person p in people)
{
    ages.Add(p.Age);
}

// Where sem LINQ, feito por métodos de extensão
foreach (int n in ages.Where(num => num >= 21))
    Console.WriteLine(n);