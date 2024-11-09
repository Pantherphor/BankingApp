using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankingApp.Core.Validations
{
    public static class EventValidator
    {
        public static bool TryValidate<T>(T obj, out List<ValidationResult> results)
        {
            var context = new ValidationContext(obj);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, context, results, true);
        }
    }

}
