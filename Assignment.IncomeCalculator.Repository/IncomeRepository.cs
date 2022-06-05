using Assignment.IncomeCalculator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace Assignment.IncomeCalculator.Repository
{
    public class IncomeRepository
    {

        public BudgetDomainModel GetBudgetData(DateTime date)
        {
            var taxYear = GetTaxYear(date);
            var budget  = GetBudgetIncomeData();
            var incomeData = budget.Where(x => x.TaxYear == taxYear).FirstOrDefault();
            return incomeData;
        }

        private ICollection<BudgetDomainModel> GetBudgetIncomeData()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "BudgetYearData.json";
            string result;
            using (Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{resourceName}"))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            return JsonSerializer.Deserialize<List<BudgetDomainModel>>(result);
        }


        private string GetTaxYear(DateTime date)
        {
            if (date.Month > 6)
            {
                return $"{date.Year}-{date.Year + 1}";
            }
            return $"{date.Year - 1}-{date.Year}";
        }
    }
}
