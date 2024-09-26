using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    namespace ConsoleApp.Attributes
    {
        public class MinimumLengthAttribute : ValidationAttribute
        {
            private readonly int _minLength;

            public MinimumLengthAttribute(int minLength)
            {
                _minLength = minLength;
            }

            public MinimumLengthAttribute() : this(0) 
            {
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is string str && str.Length < _minLength)
                {
                    return new ValidationResult($"The field {validationContext.DisplayName} must be at least {_minLength} characters long.");
                }
                return ValidationResult.Success;
            }
        }
    }


}
