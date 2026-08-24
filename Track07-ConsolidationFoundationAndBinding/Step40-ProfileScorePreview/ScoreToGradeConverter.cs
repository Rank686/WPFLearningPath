using System.Globalization;
using System.Windows.Data;

namespace WpfLearning.Step40;

public sealed class ScoreToGradeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
        value is double score
            ? score >= 90 ? "优秀" : score >= 80 ? "良好" : score >= 60 ? "及格" : "继续练习"
            : "继续练习";

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
        throw new NotSupportedException();
}
