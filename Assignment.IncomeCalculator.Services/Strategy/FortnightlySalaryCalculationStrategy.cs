namespace Assignment.IncomeCalculator.Services.Strategy
{
    public class FortnightlySalaryCalculationStrategy : SalaryCalculationStrategyBase
    {
        protected override int GetAnnualSalaryContactFactor()
        {
            return 26;
        }

        public override string GetFrequencyName()
        {
            return "fortnight";
        }
    }
}
