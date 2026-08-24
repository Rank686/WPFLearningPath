using System.Windows;
using System.Windows.Controls;
namespace WpfLearning.Step34;
public sealed class RatingBadge : Border
{
    public static readonly DependencyProperty RatingProperty =
        DependencyProperty.Register(nameof(Rating), typeof(int), typeof(RatingBadge));
    public int Rating
    {
        get => (int)GetValue(RatingProperty);
        set => SetValue(RatingProperty, value);
    }
}
