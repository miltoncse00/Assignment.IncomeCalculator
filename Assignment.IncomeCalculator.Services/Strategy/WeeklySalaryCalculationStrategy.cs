using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.IncomeCalculator.Services.Strategy
{
    public class WeeklySalaryCalculationStrategy : SalaryCalculationStrategyBase
    {
        protected override int GetAnnualSalaryContactFactor()
        {
            return 52;
        }

        public override string GetFrequencyName()
        {
            return "week";
        }
    }
}
