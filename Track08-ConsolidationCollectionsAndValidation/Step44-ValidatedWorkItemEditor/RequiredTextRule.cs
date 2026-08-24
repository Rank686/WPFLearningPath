using System.Globalization;
using System.Windows.Controls;

namespace WpfLearning.Step44;

public class RequiredTextRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        return string.IsNullOrWhiteSpace(value?.ToString())
            ? new ValidationResult(false, "Title is required.")
            : ValidationResult.ValidResult;
    }
}
