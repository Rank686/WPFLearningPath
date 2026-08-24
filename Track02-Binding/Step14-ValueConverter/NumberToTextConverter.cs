using System.Globalization;
using System.Windows.Data;

namespace WpfLearning.Step14;

public sealed class NumberToTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var number = (double)value;
        return $"Current number: {number:0}";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
