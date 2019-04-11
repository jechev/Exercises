using System;
using System.Collections.Generic;
using System.Linq;

namespace _03CountUppercaseWords
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            List<string> listWithUpperCaseWords = Console.ReadLine()
                .Split(' ')
                .Where(i => char.IsUpper(i[0]))
                .ToList();

            listWithUpperCaseWords.ForEach(Console.WriteLine);

            Console.ReadKey();
        }
    }
}
