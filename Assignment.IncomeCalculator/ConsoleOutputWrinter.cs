using Assignment.IncomeCalculator.Models;
using System;
using Assignment.IncomeCalculator.Common.Extensions;
namespace Assignment.IncomeCalculator
{
    public class ConsoleOutputWrinter
    {
        public void WriteSalaryDetails(SalaryDetailsModel salaryDetails, string frequencyName)
        {
            Console.WriteLine("Calculating salary details...");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Gross package: {salaryDetails.GrossPackage.ToCurrency()}");
            Console.WriteLine($"Superannuation: {salaryDetails.Superannuation.ToCurrency()}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Taxable income: {salaryDetails.TaxableIncome.ToCurrency()}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Deductions:");
            Console.WriteLine($"Medicare Levy: {salaryDetails.MedicareLevy.ToCurrency()}");
            Console.WriteLine($"Budget Repair Levy: {salaryDetails.BudgetRepairLevy.ToCurrency()}");
            Console.WriteLine($"Income Tax: {salaryDetails.IncomeTax.ToCurrency()}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Net income: {salaryDetails.NetIncome.ToCurrency()}");
            Console.WriteLine($"Pay packet: {salaryDetails.PayPocket.ToCurrency()} per {frequencyName}");
            Console.WriteLine();
            Console.WriteLine();
        }
   
    }
}
