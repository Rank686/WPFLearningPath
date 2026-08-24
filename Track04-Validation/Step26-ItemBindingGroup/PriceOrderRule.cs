using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfLearning.Step26;

public sealed class PriceOrderRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        var group = (BindingGroup)value;
        var offer = group.Items[0];

        if (!group.TryGetValue(offer, nameof(Offer.StartPrice), out var startValue) ||
            !group.TryGetValue(offer, nameof(Offer.BuyNowPrice), out var buyNowValue) ||
            startValue is not decimal startPrice ||
            buyNowValue is not decimal buyNowPrice)
        {
            return new ValidationResult(false, "Enter two valid prices.");
        }

        return buyNowPrice < startPrice
            ? new ValidationResult(false, "Buy-now price must be at least the start price.")
            : ValidationResult.ValidResult;
    }
}
