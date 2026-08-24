using System.Windows;

namespace WpfLearning.Step11;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Inspect_Click(object sender, RoutedEventArgs e)
    {
        var oneWaySource = (Profile)OneWayPanel.DataContext;
        var twoWaySource = (Profile)TwoWayPanel.DataContext;
        ResultText.Text = $"OneWay source: {oneWaySource.IsSubscribed}; TwoWay source: {twoWaySource.IsSubscribed}";
    }
}
