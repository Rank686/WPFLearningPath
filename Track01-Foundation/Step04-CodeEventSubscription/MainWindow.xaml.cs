using System.Windows;
using System.Windows.Controls;

namespace WpfLearning.Step04;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        CodeButton.Click += CodeButton_Click;
    }

    private void ChangeText_Click(object sender, RoutedEventArgs e)
    {
        ((Button)sender).Content = "XAML handler ran";
    }

    private void CodeButton_Click(object sender, RoutedEventArgs e)
    {
        ((Button)sender).Content = "C# handler ran";
    }
}
