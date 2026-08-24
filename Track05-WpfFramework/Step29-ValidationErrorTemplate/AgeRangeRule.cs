using System.Globalization;
using System.Windows.Controls;
namespace WpfLearning.Step29;
public sealed class AgeRangeRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (!int.TryParse(value as string, out var age)) return new ValidationResult(false, "Enter a whole-number age.");
        return age is < 21 or > 130 ? new ValidationResult(false, "Age must be from 21 to 130.") : ValidationResult.ValidResult;
    }
}
