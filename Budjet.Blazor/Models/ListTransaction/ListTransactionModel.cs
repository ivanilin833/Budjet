using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budjet.Blazor.Models
{
    public class ListTransactionModel
    {
        public Guid UserId { get; set; }
        public Guid ListTransactionId { get; set; }

        [Required(ErrorMessage = "Введите название")]
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public IList<TransactionModel> Income { get; set; }
        public IList<TransactionModel> Expenses { get; set; }
    }
}
