using System.Windows;

namespace WpfLearning.Step15;

public partial class MainWindow : Window
{
    public List<string> Names { get; } = new() { "Ada", "Grace", "Linus" };

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }
}
