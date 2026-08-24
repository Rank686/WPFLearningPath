using System.Globalization;
using System.Windows.Controls;

namespace WpfLearning.Step24;

public sealed class PriceRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        var text = value as string;
        if (!decimal.TryParse(text, NumberStyles.Number, cultureInfo, out var price))
        {
            return new ValidationResult(false, "Enter a decimal number.");
        }

        if (price < 0)
        {
            return new ValidationResult(false, "Price cannot be negative.");
        }

        return ValidationResult.ValidResult;
    }
}
