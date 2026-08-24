using System.Windows;
namespace WpfLearning.Step29;
public partial class MainWindow : Window
{
    public MainWindow() { InitializeComponent(); DataContext = new AgeEntry(); }
}
