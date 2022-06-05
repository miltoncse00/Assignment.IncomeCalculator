using System;

namespace Assignment.IncomeCalculator.Common
{
    public static class NumberExtension
    {
        public static decimal Round2(this decimal value)
        {
            return Math.Round(value, 2);
        }
    }
}
