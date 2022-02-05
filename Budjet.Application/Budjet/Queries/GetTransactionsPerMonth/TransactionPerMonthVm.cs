using System.Collections.Generic;
using System.Linq;
using Budjet.Application.Budjet.Queries.GetTransactionOnDate;

namespace Budjet.Application.Budjet.Queries.GetTransactionsPerMonth
{
    public class TransactionPerMonthVm
    {
        public double IncomePerMonth
        {
            get
            {
                return Transactions.Where(c => c.TypeTransaction == "income").Sum(c => c.Value);
            }
        }

        public double ExpensesPerMonth
        {
            get
            {
                return Transactions.Where(c => c.TypeTransaction == "expenses").Sum(c => c.Value);
            }
        }

        public IList<TransactionVm> Transactions { get; set; }
    }
}
