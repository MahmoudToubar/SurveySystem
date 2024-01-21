using System.ComponentModel.DataAnnotations;

namespace SurveySystem.Helper
{
    public class PercentageValidationAttribute : ValidationAttribute
{
    private readonly string _measurementUnitProperty;

    public PercentageValidationAttribute(string measurementUnitProperty)
    {
        _measurementUnitProperty = measurementUnitProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var measurementUnitProperty = validationContext.ObjectType.GetProperty(_measurementUnitProperty);
        if (measurementUnitProperty == null)
        {
            return new ValidationResult($"Unknown property: {_measurementUnitProperty}");
        }

        var measurementUnitValue = (bool)measurementUnitProperty.GetValue(validationContext.ObjectInstance, null);
        var targetedValue = (int)value;

        if (measurementUnitValue && targetedValue > 100)
        {
            return new ValidationResult("Targeted value cannot be more than 100%.");
        }

        return ValidationResult.Success;
    }
}
}
