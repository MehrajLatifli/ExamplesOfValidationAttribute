using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Attributes
{
    public class UppercaseLetterAttribute : ValidationAttribute
    {

        public UppercaseLetterAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string str && !HasUppercase(str))
            {
                return new ValidationResult("The password must contain at least one uppercase letter.");
            }
            return ValidationResult.Success;
        }

        private bool HasUppercase(string str)
        {
            foreach (char c in str)
            {
                if (char.IsUpper(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
