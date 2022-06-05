using System;
using System.ComponentModel;

namespace Assignment.IncomeCalculator.Common
{
    public enum PayFrequency
    {
        [Description("Weekly")]
        W = 7,
        [Description("Forthnightly")]
        F = 14,
        [Description("Monthly")]
        M = 12
    }
}
