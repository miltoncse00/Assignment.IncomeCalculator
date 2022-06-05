using Assignment.IncomeCalculator.Common;
using Assignment.IncomeCalculator.Services.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.IncomeCalculator.Services
{
    public class SalaryCalculationStrategyProvider
    {
        public ISalaryDetailsCalculationStrategy GetStrategy(PayFrequency payFrequency)
        {
            switch (payFrequency)
            {
                case PayFrequency.W:
                    return new WeeklySalaryCalculationStrategy();
                case PayFrequency.F:
                    return new FortnightlySalaryCalculationStrategy();
                case PayFrequency.M:
                    return new MonthlySalaryCalculationStrategy();

            }
            throw new ArgumentException("Invalid pay frequency");

        }
    }
}
