using System.Windows;

namespace WpfLearning.Step41;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ClearStatusButton.Click += ClearStatus_Click;
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        var profile = (ProfileViewModel)Resources["Profile"];
        SaveStatus.Text = $"已保存：{profile.Summary}，分数 {profile.Score:0}";
    }

    private void ClearStatus_Click(object? sender, RoutedEventArgs e)
    {
        SaveStatus.Text = "";
    }
}
