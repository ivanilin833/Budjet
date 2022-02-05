using System.Collections.Generic;

namespace Budjet.Blazor.Models
{
    public class ResultModel
    {
        public double IncomeOnDate { get; set; }
        public double ExpensesOnDate { get; set; }
        public double IncomePerMonth { get; set; }
        public double ExpensesPerMonth { get; set; }
        public IList<TransactionModel> Transactions { get; set; }
    }
}
