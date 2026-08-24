using System.Globalization;
using System.Windows.Controls;

namespace WpfLearning.Step26;

public sealed class PriceRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        var text = value as string;
        if (!decimal.TryParse(text, NumberStyles.Number, cultureInfo, out var price))
        {
            return new ValidationResult(false, "Enter a decimal number.");
        }

        return price < 0
            ? new ValidationResult(false, "Price cannot be negative.")
            : ValidationResult.ValidResult;
    }
}
