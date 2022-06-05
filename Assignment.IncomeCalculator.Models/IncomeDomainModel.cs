using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.IncomeCalculator.Models
{
    public class BudgetDomainModel
    {
        public string TaxYear { get; set; }
        public decimal SuperannuationRate { get; set; }
        public ICollection<LevyRangeModel> MedicareLevyRanges { get; set; }
        public ICollection<LevyRangeModel> BudgetRepairLevyRanges { get; set; }
        public ICollection<TaxRangeModel> IncomeTaxRanges { get; set; }
    }
}
