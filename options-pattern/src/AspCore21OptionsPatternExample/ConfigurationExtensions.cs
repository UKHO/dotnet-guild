using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core21OptionsPatternExample
{
    public static class ConfigurationExtensions
    {
        public static IEnumerable<string> ValidateDataAnnotations(this object @this)
        {
            var context = new ValidationContext(@this, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(@this, context, results, true);
            foreach (var validationResult in results)
            {
                yield return validationResult.ErrorMessage;
            }
        }
    }

}
