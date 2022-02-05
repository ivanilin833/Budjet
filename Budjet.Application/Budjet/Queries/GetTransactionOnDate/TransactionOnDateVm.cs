using System.Collections.Generic;
using System.Linq;

namespace Budjet.Application.Budjet.Queries.GetTransactionOnDate
{
    public class TransactionOnDateVm
    {
       public double IncomeOnDate 
        {
            get { return Transactions.Where(c => c.TypeTransaction == "income").Sum(c => c.Value); }
        }

        public double ExpensesOnDate
        {
            get { return Transactions.Where(c => c.TypeTransaction == "expenses").Sum(c => c.Value); }
        }

        public IList<TransactionVm> Transactions { get; set; }
    }
}
