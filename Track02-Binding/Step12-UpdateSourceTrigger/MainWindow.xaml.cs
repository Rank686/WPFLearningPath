using System.Windows;
using System.Windows.Controls;

namespace WpfLearning.Step12;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ShowSourceValues();
    }

    private void Inspect_Click(object sender, RoutedEventArgs e)
    {
        ShowSourceValues();
    }

    private void ApplyExplicit_Click(object sender, RoutedEventArgs e)
    {
        ExplicitInput.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
        ShowSourceValues();
    }

    private void ShowSourceValues()
    {
        var values = (InputValues)RootPanel.DataContext;
        ResultText.Text = $"LostFocus: {values.LostFocusValue}\nPropertyChanged: {values.ImmediateValue}\nExplicit: {values.ExplicitValue}";
    }
}
