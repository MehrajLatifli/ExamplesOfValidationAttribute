using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class AllOfAttribute : ValidationAttribute
    {
        private readonly Type[] _validationTypes;

        public AllOfAttribute(params Type[] validationTypes)
        {
            _validationTypes = validationTypes;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var errors = new List<string>();

            foreach (var type in _validationTypes)
            {
                var validator = (ValidationAttribute)Activator.CreateInstance(type);
                var result = validator.GetValidationResult(value, validationContext);
                if (result != ValidationResult.Success)
                {
                    errors.Add(result.ErrorMessage);
                }
            }

            if (errors.Any())
            {
                return new ValidationResult(string.Join(" ", errors));
            }

            return ValidationResult.Success;
        }
    }

}
