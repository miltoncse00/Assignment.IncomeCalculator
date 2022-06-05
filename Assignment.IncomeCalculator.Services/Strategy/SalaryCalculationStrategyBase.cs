using Assignment.IncomeCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Assignment.IncomeCalculator.Common.Extensions;
namespace Assignment.IncomeCalculator.Services.Strategy
{
    public abstract class SalaryCalculationStrategyBase : ISalaryDetailsCalculationStrategy
    {
        public SalaryDetailsModel GetSalaryDetails(SalaryContext context)
        {
            var annualSalaryConvertFactor = GetAnnualSalaryContactFactor();

            var salaryDetailsModel = new SalaryDetailsModel();
            salaryDetailsModel.GrossPackage = context.UserInputs.SalaryPackage;
            var annualSalaryPackage = salaryDetailsModel.GrossPackage;

            salaryDetailsModel.Superannuation = (context.BudgetData.SuperannuationRate * annualSalaryPackage).Round2();

            var taxableIncome = annualSalaryPackage - salaryDetailsModel.Superannuation;
            salaryDetailsModel.TaxableIncome = taxableIncome;

            salaryDetailsModel.MedicareLevy = GetLevy(taxableIncome, context.BudgetData.MedicareLevyRanges);
            salaryDetailsModel.BudgetRepairLevy = GetLevy(taxableIncome, context.BudgetData.BudgetRepairLevyRanges);
            salaryDetailsModel.IncomeTax = GetIncomeTax(taxableIncome, context.BudgetData.IncomeTaxRanges);
            decimal netIncome = CalculateNetIncome(salaryDetailsModel);
            salaryDetailsModel.NetIncome = netIncome;
            salaryDetailsModel.PayPocket = (netIncome / annualSalaryConvertFactor).Round2();
            return salaryDetailsModel;
        }

        private static decimal CalculateNetIncome(SalaryDetailsModel salaryDetailsModel)
        {
            return salaryDetailsModel.TaxableIncome -
                ( salaryDetailsModel.MedicareLevy + salaryDetailsModel.BudgetRepairLevy + salaryDetailsModel.IncomeTax);
        }

        private decimal GetIncomeTax(decimal taxableIncome, ICollection<TaxRangeModel> incomeTaxRanges)
        {
            var rangeModel = incomeTaxRanges.Where(x => x.MinValue < taxableIncome && x.MaxValue > taxableIncome).First();
            return (rangeModel.DefaultTax + (taxableIncome - rangeModel.BaseValue) * rangeModel.ExcessPercentage).Round2();
        }

        private decimal GetLevy(decimal taxableIncome, ICollection<LevyRangeModel> levyRanges)
        {
            var rangeModel = levyRanges.Where(x => x.MinValue < taxableIncome && x.MaxValue > taxableIncome).First();
            return ((taxableIncome - rangeModel.BaseValue) * rangeModel.Levy).Round2();
        }


        protected abstract int GetAnnualSalaryContactFactor();
        public abstract string GetFrequencyName();
    }
}
