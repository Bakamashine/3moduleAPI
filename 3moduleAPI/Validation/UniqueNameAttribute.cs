using System.ComponentModel.DataAnnotations;

namespace _3moduleAPI.Validation
{
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string name)
            {
                ApplicationContext? context = validationContext.GetService(typeof(ApplicationContext)) as ApplicationContext;

                if (context != null && !context.Users.Any(a => a.Name == name)) {
                    return new ValidationResult("Name is exists");
                }
            }
            return ValidationResult.Success;
        }
    }
}
