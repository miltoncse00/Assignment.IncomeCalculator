using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.IncomeCalculator.Models
{
    public class TaxRangeModel
    {
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public decimal DefaultTax { get; set; }
        public decimal BaseValue { get; set; }
        public decimal ExcessPercentage { get; set; }
    }
}
