using System.Windows;
using System.Windows.Input;

namespace WpfLearning.Step47;

public partial class MainWindow : Window
{
    public static readonly RoutedCommand IncreaseRatingCommand = new();

    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
        CommandBindings.Add(new CommandBinding(IncreaseRatingCommand, IncreaseRating_Executed, IncreaseRating_CanExecute));
        IncreaseButton.Command = IncreaseRatingCommand;
        ResetButton.Click += ResetButton_Click;
    }

    private void IncreaseRating_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = ((MainWindowViewModel)DataContext).Rating < 5;
    }

    private void IncreaseRating_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        var viewModel = (MainWindowViewModel)DataContext;
        viewModel.Rating++;
    }

    private void ResetButton_Click(object sender, RoutedEventArgs e)
    {
        ((MainWindowViewModel)DataContext).Rating = 0;
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
