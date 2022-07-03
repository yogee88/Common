using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Attributes
{
    public class DateValidationAttribute : ValidationAttribute
    {
        public bool IsFutureDate { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(IsFutureDate)
            {
                if(value is DateTime && (DateTime) value > DateTime.Now)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
        }
    }
}
