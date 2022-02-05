using System;
using System.ComponentModel.DataAnnotations;

namespace Budjet.Blazor.Validations
{
    public class GreaterThanZero: ValidationAttribute
    {
        private readonly decimal _val;
        public const string DefaultErrorMessage = "Сумма должнаа быть больше нуля";

        public GreaterThanZero(double val) 
        {
            _val = (decimal)val;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToDecimal(value)<_val)
            {
                return new ValidationResult(DefaultErrorMessage); 
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}

