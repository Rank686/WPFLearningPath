using System.Diagnostics;
using System.Windows;

namespace WpfLearning.Step40;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var window = new MainWindow();
        MainWindow = window;
        window.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        Debug.WriteLine("Application exited");
        base.OnExit(e);
    }
}
