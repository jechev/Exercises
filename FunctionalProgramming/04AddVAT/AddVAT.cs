using System;
using System.Collections.Generic;
using System.Linq;

namespace _04AddVAT
{
    class AddVAT
    {
        static void Main(string[] args)
        {
            Func<double, double> addVat = n => n * 1.2;


            List<double> numbersWithVAT = Console.ReadLine()
                .Split(new[] {' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(addVat)
                .ToList();

            Console.WriteLine(string.Join(", ", numbersWithVAT));
            Console.ReadKey();
        }

    }
}
