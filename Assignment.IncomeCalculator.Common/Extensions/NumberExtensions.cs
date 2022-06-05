using System;
using System.Globalization;

namespace Assignment.IncomeCalculator.Common.Extensions
{
    public static class NumberExtensions
    {
        public static decimal Round2(this decimal value)
        {
            return Math.Round(value, 2);
        }

        public static string ToCurrency(this decimal value)
        {
            return value.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}
