using System.Windows;
using System.Windows.Input;
namespace WpfLearning.Step31;
public partial class MainWindow : Window
{
    public MainWindow() { InitializeComponent(); }
    private void Inner_MouseDown(object sender, MouseButtonEventArgs e)
    {
        RouteLog.Text = $"inner: sender={Describe(sender)}, Source={Describe(e.Source)}, OriginalSource={Describe(e.OriginalSource)}";
        if (StopAtInnerCheckBox.IsChecked == true) { e.Handled = true; RouteLog.AppendText("\ninner set Handled=true"); }
    }
    private void Outer_MouseDown(object sender, MouseButtonEventArgs e)
    {
        RouteLog.AppendText($"\nouter: sender={Describe(sender)}, Source={Describe(e.Source)}, OriginalSource={Describe(e.OriginalSource)}");
    }
    private static string Describe(object? value) => value is FrameworkElement element
        ? $"{element.GetType().Name}({element.Name})"
        : value?.GetType().Name ?? "null";
}
