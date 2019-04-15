using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static long Sum(IEnumerable<int> multiples, int max)
    {
        var arr = Enumerable.Range(1, max - 1).ToArray();
        List<int> naturalMembers = new List<int>();
        foreach (var multiple in multiples)
        {
            if (multiple != 0)
            {
                naturalMembers.AddRange(arr.Where(n => n % multiple == 0 
                    && !naturalMembers.Contains(n)));
            }
        }
        return naturalMembers.Sum();
    }
}

