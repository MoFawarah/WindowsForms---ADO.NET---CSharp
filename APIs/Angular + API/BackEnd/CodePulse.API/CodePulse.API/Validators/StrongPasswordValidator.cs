using System.ComponentModel.DataAnnotations;

namespace CodePulse.API.Validators
{
    public class StrongPasswordValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext _vc)
        {
            var password = value as string;

            if (string.IsNullOrEmpty(password))
            {
                return new ValidationResult("Password can't be empty");
            }
            if (password.Length <= 6)
            {
                return new ValidationResult("Password must be more than 6 characters long.");

            }

            if (!password.Any(char.IsUpper))
            {
                return new ValidationResult("Password must contain at least one uppercase letter.");

            }

            if (password.Any(ch => char.IsLetterOrDigit(ch)))
            {
                return new ValidationResult("Password must contain at least one special character (e.g., #, $, etc.).");
            }

            return ValidationResult.Success;

        }
    }
}
