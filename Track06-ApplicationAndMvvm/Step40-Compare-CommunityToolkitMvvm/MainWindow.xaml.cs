using System.Windows;

namespace WpfLearning.Step40Toolkit;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}
