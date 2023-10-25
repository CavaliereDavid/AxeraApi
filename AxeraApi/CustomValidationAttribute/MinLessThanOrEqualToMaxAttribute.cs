using AxeraApi.Domain.DTO;
using System.ComponentModel.DataAnnotations;

namespace AxeraApi.CustomValidationAttribute;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false)]
public class MinLessThanOrEqualToMaxAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is int minValue)
        {
            var maxUsersProperty = validationContext.ObjectType.GetProperty("MaxUsers");

            if (value is CreateMeetingRequestDTO dto)
            {
                var maxValue = (int)maxUsersProperty.GetValue(validationContext.ObjectInstance, null);

                if (minValue > maxValue)
                {
                    return new ValidationResult("MinUsers must be less than or equal to MaxUsers.");
                }
            }
        }

        return ValidationResult.Success;
    }
}
