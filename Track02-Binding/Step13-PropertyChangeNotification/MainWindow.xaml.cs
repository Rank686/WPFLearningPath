using System.Windows;

namespace WpfLearning.Step13;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ChangeSource_Click(object sender, RoutedEventArgs e)
    {
        var profile = (Profile)RootPanel.DataContext;
        profile.DisplayName = profile.DisplayName == "Ada Lovelace"
            ? "Grace Hopper"
            : "Ada Lovelace";
    }
}
