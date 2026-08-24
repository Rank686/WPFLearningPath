using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace WpfLearning.Step33;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent(); 
        ShowValueState();
    }

    private void SetLocal_Click(object sender, RoutedEventArgs e)
    {
        ValueButton.Background = Brushes.Orange; 
        ShowValueState();
    }

    private void ClearLocal_Click(object sender, RoutedEventArgs e)
    {
        ValueButton.ClearValue(Control.BackgroundProperty); 
        ShowValueState();
    }
    
    private void ShowValueState()
    {
        var local = ValueButton.ReadLocalValue(Control.BackgroundProperty);
        var localText = ReferenceEquals(local, DependencyProperty.UnsetValue) ? "none" : local.ToString();
        ValueStatus.Text = $"Effective Background: {ValueButton.Background}; local value: {localText}";
    }
}
