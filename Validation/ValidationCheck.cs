using CSharpFunctionalExtensions;
using Market.Models;
using System.ComponentModel.DataAnnotations;

namespace Market.OtherScripts
{
    public class ValidationCheck
    {
        private static ILogger<ValidationCheck> _logger = null;
        public static bool IsValid(object obj)
        {
            if (obj is null)
                return false;

            var results = new List<ValidationResult>();
            var context = new ValidationContext(obj);
            _logger ??= context.GetService<ILogger<ValidationCheck>>();

            var isValid = Validator.TryValidateObject(obj, context, results, true);

            foreach (ValidationResult result in results)
            {
                _logger?.LogWarning("Message: {x}. MemberName: {y}",
                    result.ErrorMessage, result.MemberNames);
            }

            return isValid;
        }
    }
}
