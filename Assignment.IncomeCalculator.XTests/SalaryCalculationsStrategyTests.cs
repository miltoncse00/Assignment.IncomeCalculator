using Assignment.IncomeCalculator.Common;
using Assignment.IncomeCalculator.Models;
using Assignment.IncomeCalculator.Repository;
using Assignment.IncomeCalculator.Services;
using Assignment.IncomeCalculator.Services.Strategy;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Assignment.IncomeCalculator.XTests
{
    public class SalaryCalculationsStrategyTests
    {
        private WeeklySalaryCalculationStrategy weeklySalaryCalculationStrategy = new WeeklySalaryCalculationStrategy();

        [Fact]
        public void VerifyWeeklySalaryCalculation()
        {
            var userInput = new UserInputsModel() { PayFrequency = PayFrequency.W, SalaryPackage = 180000 };
            var salaryDetail = GetSalaryDetails(userInput);
            Assert.True(salaryDetail.GrossPackage == userInput.SalaryPackage);
            Assert.True(salaryDetail.Superannuation.Equals(17100));
            Assert.True(salaryDetail.TaxableIncome.Equals(162900));
            Assert.True(salaryDetail.MedicareLevy.Equals(3258));
            Assert.True(salaryDetail.BudgetRepairLevy.Equals(0));
            Assert.True(salaryDetail.IncomeTax.Equals(47905));
            Assert.True(salaryDetail.NetIncome.Equals(111737));
            Assert.True(salaryDetail.PayPocket.Equals(2148.79M));

            userInput = new UserInputsModel() { PayFrequency = PayFrequency.M, SalaryPackage = 180000 };
            salaryDetail = GetSalaryDetails(userInput);
            Assert.True(salaryDetail.GrossPackage == userInput.SalaryPackage);
            Assert.True(salaryDetail.Superannuation.Equals(17100));
            Assert.True(salaryDetail.TaxableIncome.Equals(162900));
            Assert.True(salaryDetail.MedicareLevy.Equals(3258));
            Assert.True(salaryDetail.BudgetRepairLevy.Equals(0));
            Assert.True(salaryDetail.IncomeTax.Equals(47905));
            Assert.True(salaryDetail.NetIncome.Equals(111737));
            Assert.True(salaryDetail.PayPocket.Equals(9311.42M));
        }

        private static SalaryDetailsModel GetSalaryDetails(UserInputsModel userInput)
        {
            SalaryCalculationStrategyProvider provider = new SalaryCalculationStrategyProvider();
            var strategy = provider.GetStrategy(userInput.PayFrequency);
            var data = GetBudgetData();
            return strategy.GetSalaryDetails(new SalaryContext(data, userInput));
        }
        private static BudgetDomainModel GetBudgetData()
        {
            var budgetData = new BudgetDomainModel()
            {
                TaxYear = "2021-2022",
                SuperannuationRate = 0.095M,
                MedicareLevyRanges = new List<LevyRangeModel> {
                    new LevyRangeModel {
                        MinValue = 0,
                        MaxValue = 21335,
                        BaseValue = 0,
                        Levy = 0
                    },
                    new LevyRangeModel {

                        MinValue = 21336,
                        MaxValue = 26668,
                        BaseValue = 21335,
                        Levy = 0.1M
                    },
                    new LevyRangeModel {
                        MinValue = 26669,
                        MaxValue = decimal.MaxValue,
                        BaseValue = 0,
                        Levy = 0.02M
                    }
                },
                BudgetRepairLevyRanges = new List<LevyRangeModel> {
                    new LevyRangeModel {
                        MinValue = 0,
                        MaxValue = 180000,
                        BaseValue = 0,
                        Levy = 0
                    },
                    new LevyRangeModel {
                        MinValue = 180001,
                        MaxValue = decimal.MaxValue,
                        BaseValue = 180000,
                        Levy = 0.02M
                    }
                },
                IncomeTaxRanges = new List<TaxRangeModel> {
                    new TaxRangeModel {
                        MinValue = 0,
                        MaxValue = 18200,
                        DefaultTax = 0,
                        BaseValue = 0,
                        ExcessPercentage = 0
                    },
                    new TaxRangeModel {
                        MinValue = 18201,
                        MaxValue = 37000,
                        DefaultTax = 0,
                        BaseValue = 18200,
                        ExcessPercentage = 0.19M
                    },
                    new TaxRangeModel {
                        MinValue = 37001,
                        MaxValue = 87000,
                        DefaultTax = 3572,
                        BaseValue = 37000,
                        ExcessPercentage = 0.325M
                    },
                    new TaxRangeModel {
                        MinValue = 87001,
                        MaxValue = 180000,
                        DefaultTax = 19822,
                        BaseValue = 87000,
                        ExcessPercentage = 0.37M
                    },
                    new TaxRangeModel {
                        MinValue = 180001,
                        MaxValue = decimal.MaxValue,
                        DefaultTax = 54232,
                        BaseValue = 180000,
                        ExcessPercentage = 0.47M
                    }

                }
            };
            return budgetData;
        }
    }
}
