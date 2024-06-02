using Cervantes.Arquisoft.View.Models;
using System.ComponentModel.DataAnnotations;

namespace Cervantes.Arquisoft.View
{
    public class RangeMaxGreaterThanMinAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var projectTypeViewModel = (ProjectTypeViewModel)validationContext.ObjectInstance;

            if (projectTypeViewModel.RangeMax <= projectTypeViewModel.RangeMin)
            {
                return new ValidationResult("El valor máximo debe ser mayor que el valor mínimo.");
            }

            return ValidationResult.Success;
        }
    }
}
