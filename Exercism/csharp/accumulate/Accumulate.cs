using System;
using System.Collections.Generic;

public static class AccumulateExtensions
{
    public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> collection, Func<T, U> func)
    {
        U result;
        foreach (var item in collection)
        {
            result = func(item);
            yield return result;
        }
        
    }
}