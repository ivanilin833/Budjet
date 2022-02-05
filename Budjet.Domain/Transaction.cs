using System;

namespace Budjet.Domain
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }

        public Guid ListTransactionId { get; set;}

        public ListTransaction ListTransaction { get; set; }

        public DateTime DateCreated { get; set; }

        public string TypeTransaction { get; set; }

        public double Value { get; set; }

        public string Name { get; set; }
    }
}
