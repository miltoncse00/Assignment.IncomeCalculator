namespace Assignment.IncomeCalculator.Models
{
    public class SalaryDetailsModel
    {
        public decimal GrossPackage { get; set; }
        public decimal Superannuation { get; set; }
        public decimal TaxableIncome { get; set; }
        public decimal MedicareLevy { get; set; }
        public decimal BudgetRepairLevy { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetIncome { get; set; }
        public decimal PayPocket { get; set; }
    }
}
