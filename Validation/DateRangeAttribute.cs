using System;
using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public class DateRangeAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateRangeAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = (DateTime?)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = (DateTime?)property.GetValue(validationContext.ObjectInstance);

            if (currentValue != null && comparisonValue != null)
            {
                if (currentValue < comparisonValue)
                    return new ValidationResult(ErrorMessage ?? $"End date cannot be earlier than start date.");
            }

            return ValidationResult.Success;
        }
    }
}