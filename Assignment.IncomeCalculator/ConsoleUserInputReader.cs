using Assignment.IncomeCalculator.Common;
using Assignment.IncomeCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.IncomeCalculator
{
    public class ConsoleUserInputReader
    {
        
        private const string SalaryPackageConsoleMessage = "Enter your salary package amount:";
        private const string PayFrequencyConsoleMessage = "Enter your pay frequency (W for weekly, F for fortnightly, M for monthly):";

        public UserInputsValidator Validator { get; }

        public ConsoleUserInputReader(UserInputsValidator validator)
        {
            Validator = validator;
        }

        public UserInputsModel GetUserInputs()
        {
           var salaryPackage = GetSalaryPackage();
           var payFrequency = GetPayFrequency();
            return new UserInputsModel { SalaryPackage = salaryPackage, PayFrequency = payFrequency };
        }
        private decimal GetSalaryPackage()
        {
            decimal salaryPackageValue;
            while (true)
            {
                Console.WriteLine(SalaryPackageConsoleMessage);
                string salaryPackage = Console.ReadLine();
                string validationMessage = Validator.ValdateSalaryPackage(salaryPackage);
                if (validationMessage != null)
                {
                    Console.WriteLine(validationMessage);
                }
                else
                {
                    salaryPackageValue = decimal.Parse(salaryPackage);
                    break;
                }
            }
            return salaryPackageValue;
        }

        private PayFrequency GetPayFrequency()
        {
            PayFrequency payFrequency;
            while (true)
            {
                Console.WriteLine(PayFrequencyConsoleMessage);
                string frequency = Console.ReadLine();
                string validationMessage = Validator.ValdatePayFrequency(frequency, Enum.GetNames(typeof(PayFrequency)));
                if (validationMessage != null)
                {
                    Console.WriteLine(validationMessage);
                }
                else
                {
                    Enum.TryParse(frequency, true, out payFrequency);

                    break;
                }
            }
            return payFrequency;
        }    
    }
}
