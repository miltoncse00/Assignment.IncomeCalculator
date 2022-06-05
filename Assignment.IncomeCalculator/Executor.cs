using Assignment.IncomeCalculator.Models;
using Assignment.IncomeCalculator.Services;
using System;

namespace Assignment.IncomeCalculator
{
    public class Executor
    {
        private readonly IncomeCalculatorService incomeCalculatorService;
        private readonly SalaryCalculationStrategyProvider strategyProvider;
        private readonly ConsoleUserInputReader consoleInputReader;
        private readonly ConsoleOutputWrinter consoleWriter;

        public Executor(IncomeCalculatorService incomeCalculatorService,
            SalaryCalculationStrategyProvider strategyProvider,
            ConsoleUserInputReader consoleInputReader,
            ConsoleOutputWrinter consoleWriter)
        {
            this.incomeCalculatorService = incomeCalculatorService;
            this.strategyProvider = strategyProvider;
            this.consoleInputReader = consoleInputReader;
            this.consoleWriter = consoleWriter;
        }
        public void Execute()
        {
            var userInputs = consoleInputReader.GetUserInputs();
            var salaryCalculationStartegy = strategyProvider.GetStrategy(userInputs.PayFrequency);
            var salaryDetails = incomeCalculatorService.GetSalaryDetails(userInputs, salaryCalculationStartegy);
            consoleWriter.WriteSalaryDetails(salaryDetails, salaryCalculationStartegy.GetFrequencyName());
        }
    }
}
