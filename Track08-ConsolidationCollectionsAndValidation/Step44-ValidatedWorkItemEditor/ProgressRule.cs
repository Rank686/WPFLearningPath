using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfLearning.Step44;

public class ProgressRule : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        var group = (BindingGroup)value;
        if (group.Items.Count == 0) return ValidationResult.ValidResult;
        var item = group.Items[0];
        if (!group.TryGetValue(item, nameof(WorkItem.Estimate), out var estimateValue) ||
            !group.TryGetValue(item, nameof(WorkItem.Completed), out var completedValue))
            return new ValidationResult(false, "Enter valid Estimate and Completed values.");
        return (int)completedValue <= (int)estimateValue
            ? ValidationResult.ValidResult
            : new ValidationResult(false, "Completed cannot exceed Estimate.");
    }
}
