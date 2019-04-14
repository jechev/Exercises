using System;
using System.Linq;

namespace _01ActionPoint
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            Action<string> printName = s => Console.WriteLine(s);

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(printName);

            Console.ReadKey();
        }
    }
}
