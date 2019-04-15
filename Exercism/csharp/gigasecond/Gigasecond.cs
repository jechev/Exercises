using System;

public static class Gigasecond
{
    public static DateTime Add(DateTime moment)
    {
        DateTime momentAfterGigasecond = moment.AddSeconds(1000000000);

        return momentAfterGigasecond;
    }
}