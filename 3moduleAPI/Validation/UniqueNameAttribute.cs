using System.ComponentModel.DataAnnotations;

namespace _3moduleAPI.Validation;

public class UniqueNameAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string name) return ValidationResult.Success;
        var context = validationContext.GetService(typeof(ApplicationContext)) as ApplicationContext;

        if (context != null && !context.User.Any(a => a.Name == name))
            return ValidationResult.Success;
        return new ValidationResult("The name is exists");
    }
}