using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfLearning.Step45;

public sealed class RatingBadge : ContentControl
{
    public static readonly DependencyProperty RatingProperty = DependencyProperty.Register(
        nameof(Rating),
        typeof(int),
        typeof(RatingBadge),
        new FrameworkPropertyMetadata(0, OnRatingChanged, CoerceRating));

    public RatingBadge()
    {
        Content = "Rating: 0/5";
    }

    public int Rating
    {
        get => (int)GetValue(RatingProperty);
        set => SetValue(RatingProperty, value);
    }

    private static object CoerceRating(DependencyObject d, object value) => Math.Clamp((int)value, 0, 5);

    private static void OnRatingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((RatingBadge)d).Content = $"Rating: {e.NewValue}/5";
        CommandManager.InvalidateRequerySuggested();
    }
}
