using System;
using System.Collections.Generic;

namespace Budjet.Domain
{
    public class ListTransaction
    {
        public Guid ListTransactionId { get; set; }

        public Guid UserId { get; set; }

        public DateTime DateCreated { get; set;}

        public string Name { get; set; }

        public IEnumerable<Transaction> Transaction { get; set; }
    }
}
