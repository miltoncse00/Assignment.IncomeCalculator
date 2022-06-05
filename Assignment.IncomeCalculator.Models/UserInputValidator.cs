using Assignment.IncomeCalculator.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.IncomeCalculator.Models
{
    public class UserInputsValidator
    {

        private int SalaryPackageMaxLength = 12;

        public string ValdatePayFrequency(string payFrequency, IEnumerable<string> payFrequencies)
        {
            var isValid = payFrequencies.Any(s => s.Equals(payFrequency, StringComparison.CurrentCultureIgnoreCase));
            if (!isValid)
            {
                return StringConstants.PayFreuencyInvalidErrorMessage;
            }
            return null;
        }

        public string ValdateSalaryPackage(string salaryPackage)
        {
            decimal salary;
            if (salaryPackage.Length > SalaryPackageMaxLength)
            {
                return StringConstants.SalaryPackageMaxValueErrorMessage;
            }
            if (!decimal.TryParse(salaryPackage, out salary))
            {
                return StringConstants.SalaryPackageInvalidErrorMessage;
            }
            if (salary <= 0)
            {
                return StringConstants.SalarypackageMinValueErrorMessage;
            }
            return null;
        }
    }
}
