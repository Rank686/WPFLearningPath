using System.Windows;
namespace WpfLearning.Step34Compare;
public partial class MainWindow : Window
{
    public MainWindow() { InitializeComponent(); }
    private void IncreaseRating_Click(object sender, RoutedEventArgs e) { RatingBadge.Rating++; }
}
