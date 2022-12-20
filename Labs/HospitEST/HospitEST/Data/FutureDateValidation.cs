using HospitEST.Models;
using System.ComponentModel.DataAnnotations;

namespace HospitEST.Data
{
    public class FutureDateValidation : ValidationAttribute
    {
        public string GetErrorMessage() => $"Data de nascimento não pode ser do futuro.";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var date = ((Patient)validationContext.ObjectInstance).DateOfBirth;

            if (date.CompareTo(DateTime.Now) >= 0)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
