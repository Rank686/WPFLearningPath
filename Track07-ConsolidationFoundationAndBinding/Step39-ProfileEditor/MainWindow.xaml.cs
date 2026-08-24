using System.Windows;

namespace WpfLearning.Step39;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new ProfileViewModel();
    }
}
