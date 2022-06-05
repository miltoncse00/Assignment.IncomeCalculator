using Assignment.IncomeCalculator.Models;

namespace Assignment.IncomeCalculator.Services.Strategy
{
    public interface ISalaryDetailsCalculationStrategy
    {
        SalaryDetailsModel GetSalaryDetails(SalaryContext context);
        string GetFrequencyName();
    }
}
