using System.Globalization;
using System.Windows.Controls;

namespace WpfLearning.Step44;

public class NonNegativeIntegerRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        return int.TryParse(value?.ToString(), NumberStyles.Integer, cultureInfo, out var number) && number >= 0
            ? ValidationResult.ValidResult
            : new ValidationResult(false, "Enter a non-negative integer.");
    }
}
