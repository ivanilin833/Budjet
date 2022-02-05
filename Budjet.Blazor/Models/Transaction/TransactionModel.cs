using Budjet.Blazor.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Budjet.Blazor.Models
{
    public class TransactionModel
    {
        public Guid UserId { get; set; }
        public Guid TransactionId { get; set; }
        public Guid ListTransactionId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите название")]
        [GreaterThanZero(1)]
        public double Value { get; set; } = 1;
        public DateTime DateCreated { get; set; }
        public string TypeTransaction { get; set; }
    }
}
