using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace WpfLearning.Step35;
public sealed class RatingBadge : Border
{
    private readonly List<string> _log = new();
    private int _maximum = 5;
    public static readonly DependencyProperty RatingProperty = DependencyProperty.Register(
        nameof(Rating), typeof(int), typeof(RatingBadge),
        new FrameworkPropertyMetadata(0, OnRatingChanged, CoerceRating));
    public int Rating
    {
        get => (int)GetValue(RatingProperty);
        set => SetValue(RatingProperty, value);
    }
    public int Maximum
    {
        get => _maximum;
        set
        {
            _maximum = Math.Max(0, value);
            _log.Add($"Maximum became {_maximum}; call CoerceValue");
            CoerceValue(RatingProperty);
        }
    }
    public string LogText => string.Join(Environment.NewLine, _log);
    public void ClearLog() => _log.Clear();
    private static object CoerceRating(DependencyObject d, object baseValue)
    {
        var badge = (RatingBadge)d;
        var requested = (int)baseValue;
        var effective = Math.Clamp(requested, 0, badge.Maximum);
        badge._log.Add($"1. coerce: requested {requested}, return {effective}");
        return effective;
    }
    private static void OnRatingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var badge = (RatingBadge)d;
        badge._log.Add($"2. changed: {e.OldValue} -> {e.NewValue}");
        badge.Background = (int)e.NewValue >= 4 ? Brushes.LightGreen : Brushes.LightSkyBlue;
    }
}
