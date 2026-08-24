using System.ComponentModel;
using System.Windows;

namespace WpfLearning.Step37;

public sealed class MainWindowViewModel : INotifyPropertyChanged
{
    private string _name = "WPF learner";

    public string Name
    {
        get => _name;
        set
        {
            if (_name == value)
            {
                return;
            }

            _name = value;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Greeting));
        }
    }

    public string Greeting => string.IsNullOrWhiteSpace(Name)
        ? "Type your name above."
        : $"Hello, {Name}!";

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

/// <summary>
/// 与 <see cref="MainWindowViewModel"/> 效果相同，改用 DependencyProperty 通知 Binding。
/// 试用：MainWindow 里把 DataContext 换成 new MainWindowViewModelDp()。
/// </summary>
public sealed class MainWindowViewModelDp : DependencyObject
{
    public static readonly DependencyProperty NameProperty =
        DependencyProperty.Register(
            nameof(Name),
            typeof(string),
            typeof(MainWindowViewModelDp),
            new PropertyMetadata("WPF learner", OnNameChanged));

    public static readonly DependencyProperty GreetingProperty =
        DependencyProperty.Register(nameof(Greeting), typeof(string), typeof(MainWindowViewModelDp));

    public MainWindowViewModelDp()
    {
        UpdateGreeting();
    }

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public string Greeting
    {
        get => (string)GetValue(GreetingProperty);
        private set => SetValue(GreetingProperty, value);
    }

    private static void OnNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((MainWindowViewModelDp)d).UpdateGreeting();
    }

    private void UpdateGreeting()
    {
        Greeting = string.IsNullOrWhiteSpace(Name)
            ? "Type your name above."
            : $"Hello, {Name}!";
    }
}
