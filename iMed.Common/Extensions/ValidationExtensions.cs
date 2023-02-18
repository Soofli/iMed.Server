﻿namespace iMed.Common.Extensions;

public static class ValidationExtensions
{
    public static bool CheckDateIs(this DateTime dateTime, DateTime From, DateTime To)
    {
        if (dateTime.Date > To.Date && dateTime.Date < From.Date)
            return true;
        return false;
    }

    public static bool CheckDateFromToNow(this DateTime dateTime, int fromDays = 5)
    {
        var From = DateTime.Now.AddDays(-fromDays);
        var To = DateTime.Now;
        if (dateTime.Date > To.Date && dateTime.Date < From.Date)
            return true;
        return false;
    }
}