using System.Windows;
using System.Windows.Controls;

namespace WpfLearning.Step03;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ChangeText_Click(object sender, RoutedEventArgs e)
    {
        ((Button)sender).Content = "Clicked";
    }
}
