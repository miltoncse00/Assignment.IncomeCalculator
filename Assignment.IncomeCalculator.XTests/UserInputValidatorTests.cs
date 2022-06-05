using Assignment.IncomeCalculator.Common;
using Assignment.IncomeCalculator.Models;
using System;
using Xunit;

namespace Assignment.IncomeCalculator.XTests
{
    public class UserInputValidatorTests
    {
        UserInputsValidator validator = new UserInputsValidator();

        [Fact]
        public void SalaryPackageIsEmptyThenReturnErrorMessage()
        {
            var message = validator.ValdateSalaryPackage(string.Empty);
            Assert.Equal(message, StringConstants.SalaryPackageInvalidErrorMessage);
        }

        [Fact]
        public void SalaryPackageIsZeroThenReturnErrorMessage()
        {
            var message = validator.ValdateSalaryPackage("0");
            Assert.Equal(message, StringConstants.SalarypackageMinValueErrorMessage);
        }

        [Fact]
        public void SalaryPackageIsValidThenReturnErrorMessage()
        {
            var message = validator.ValdateSalaryPackage("1000");
            Assert.Null(message);
        }

        [Fact]
        public void SalaryPackageIsExeedLengthThenReturnErrorMessage()
        {
            var message = validator.ValdateSalaryPackage("1000000000000");
            Assert.Equal(message, StringConstants.SalaryPackageMaxValueErrorMessage);
        }

        [Fact]
        public void PayFrequencyIsInvalidThenReturnErrorMessage()
        {
            var message = validator.ValdatePayFrequency("1", Enum.GetNames(typeof(PayFrequency)));
            Assert.Equal(message, StringConstants.PayFreuencyInvalidErrorMessage);
        }

        [Fact]
        public void PayFrequencyValidThenReturnErrorMessage()
        {
            var message = validator.ValdatePayFrequency("M", Enum.GetNames(typeof(PayFrequency)));
            Assert.Null(message);
        }

    }
}
