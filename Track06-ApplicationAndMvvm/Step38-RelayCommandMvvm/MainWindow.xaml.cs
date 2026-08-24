using System.Windows;

namespace WpfLearning.Step38;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    private void OpenToolWindow_Click(object sender, RoutedEventArgs e)
    {
        new ToolWindow().Show();
    }
}
