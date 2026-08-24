using System.Windows;
namespace WpfLearning.Step28;
public partial class MainWindow : Window
{
    public MainWindow() { InitializeComponent(); }
    private void TemplateButton_Click(object sender, RoutedEventArgs e) { StatusText.Text = "Template button clicked"; }
}
