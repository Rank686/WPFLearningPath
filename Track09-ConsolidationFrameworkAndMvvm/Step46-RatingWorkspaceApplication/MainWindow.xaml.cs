using System.Windows;
using System.Windows.Input;

namespace WpfLearning.Step46;

public partial class MainWindow : Window
{
    public static readonly RoutedCommand IncreaseRatingCommand = new();

    public MainWindow()
    {
        InitializeComponent();
        CommandBindings.Add(new CommandBinding(IncreaseRatingCommand, IncreaseRating_Executed, IncreaseRating_CanExecute));
        IncreaseButton.Command = IncreaseRatingCommand;
        ResetButton.Click += ResetButton_Click;
    }

    private void IncreaseRating_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = RatingBadge.Rating < 5;
    }

    private void IncreaseRating_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        RatingBadge.Rating++;
    }

    private void ResetButton_Click(object sender, RoutedEventArgs e)
    {
        RatingBadge.Rating = 0;
    }

    private void HighlightCheckBox_Click(object sender, RoutedEventArgs e)
    {
        StatusText.Text = HighlightCheckBox.IsChecked == true ? "Highlight is on." : "Highlight is off.";
    }

    private void OpenToolWindow_Click(object sender, RoutedEventArgs e)
    {
        new ToolWindow().Show();
    }
}
