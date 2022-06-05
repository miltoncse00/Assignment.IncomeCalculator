using Assignment.IncomeCalculator.Models;
using Assignment.IncomeCalculator.Repository;
using Assignment.IncomeCalculator.Services.Strategy;
using System;

namespace Assignment.IncomeCalculator.Services
{
    public class IncomeCalculatorService
    {
        private readonly IncomeRepository incomeRepository;

        public IncomeCalculatorService(IncomeRepository incomeRepository)
        {
            this.incomeRepository = incomeRepository;
        }
        public SalaryDetailsModel GetSalaryDetails(UserInputsModel userInputs, ISalaryDetailsCalculationStrategy strategy)
        {
            var budgetData = incomeRepository.GetBudgetData(DateTime.Now.Date);
            var context = new SalaryContext(budgetData, userInputs);
            return strategy.GetSalaryDetails(context);
        }
    }
}
