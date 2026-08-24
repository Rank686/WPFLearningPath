using System.Windows;

namespace WpfLearning.Step36;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OpenToolWindow_Click(object sender, RoutedEventArgs e)
    {
        new ToolWindow().Show();
    }
}
