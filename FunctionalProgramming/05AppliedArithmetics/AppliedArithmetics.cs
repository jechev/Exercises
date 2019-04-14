using System;
using System.Collections.Generic;
using System.Linq;

namespace _05AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> addFunc = n => n.Select(i => i + 1).ToList();
            Func<List<int>, List<int>> multiplyFunc = n => n.Select(i => i * 2).ToList();
            Func<List<int>, List<int>> substractFunc = n => n.Select(i => i - 1).ToList();


            List<int> numbers = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                if (command == "add")
                {
                    numbers = addFunc(numbers);
                }
                else if (command == "multiply")
                {
                    numbers = multiplyFunc(numbers);
                }
                else if (command == "substract")
                {
                    numbers = substractFunc(numbers);
                }
                else if(command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }

                command = Console.ReadLine();
            }

            Console.ReadKey();
        }
    }
}
