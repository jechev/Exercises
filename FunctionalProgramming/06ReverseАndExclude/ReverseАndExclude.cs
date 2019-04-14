using System;
using System.Collections.Generic;
using System.Linq;

namespace _06ReverseАndExclude
{
    class ReverseАndExclude
    {
        static void Main(string[] args)
        {
            Func<int, bool> filter; 

            List<int> numbers = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int divider = int.Parse(Console.ReadLine());

            filter = n => n % divider != 0;

            numbers = numbers.Where(filter)
                .Reverse()
                .ToList();

            Console.WriteLine(string.Join(" ", numbers));
            Console.ReadKey();
        }
    }
}
