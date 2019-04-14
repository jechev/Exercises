using System;
using System.Collections.Generic;
using System.Linq;

namespace _07PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int filterLength = int.Parse(Console.ReadLine());
            Func<string, bool> filterName = n => n.Length <= filterLength ? true : false;

            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            names.Where(filterName)
               .ToList()
               .ForEach(Console.WriteLine);

            Console.ReadKey();
        }
    }
}
