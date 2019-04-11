using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FilterByAge
{
    class FilterByAge
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                Person newPerson = CreatePerson(Console.ReadLine());
                persons.Add(newPerson);

            }

            string ageCondition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> filterPredicate;

            if (ageCondition == "older")
            {
                filterPredicate = p => p.Age >= age;
            }
            else 
            {
                filterPredicate = p => p.Age <= age;
            }

            Func<Person, string> selectFunc;

            if (format == "name age")
            {
                selectFunc = p => $"{p.Name} - {p.Age}";
            }
            else if (format =="name")
            {
                selectFunc = p => $"{p.Name}";
            } else
            {
                selectFunc = p => $"{p.Age}";
            }

            persons
                .Where(filterPredicate)
                .Select(selectFunc)
                .ToList()
                .ForEach(Console.WriteLine);

            Console.ReadKey();
        }

        public static Person CreatePerson(string input)
        {
            string name = input.Split(", ")[0];
            int age = int.Parse(input.Split(", ")[1]);

            Person newPerson = new Person
            {
                Name = name,
                Age = age
            };

            return newPerson;
        }

    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
