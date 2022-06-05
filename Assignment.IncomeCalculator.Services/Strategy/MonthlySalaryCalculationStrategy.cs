using Assignment.IncomeCalculator.Models;
using System;

namespace Assignment.IncomeCalculator.Services.Strategy
{
    public class MonthlySalaryCalculationStrategy : SalaryCalculationStrategyBase
    {
        protected override int GetAnnualSalaryContactFactor()
        {
            return 12;
        }

        public override string GetFrequencyName()
        {
            return "month";
        }
    }
}
