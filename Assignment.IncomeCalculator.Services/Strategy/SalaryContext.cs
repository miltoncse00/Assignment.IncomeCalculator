using Assignment.IncomeCalculator.Models;

namespace Assignment.IncomeCalculator.Services.Strategy
{
    public class SalaryContext
    {
        public SalaryContext(BudgetDomainModel budgetData, UserInputsModel userInputs)
        {
            BudgetData = budgetData;
            UserInputs = userInputs;
        }
        public BudgetDomainModel BudgetData { get; set; }
        public UserInputsModel UserInputs { get; set; }

    }
}