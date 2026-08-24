using System.Collections.ObjectModel;
using System.Windows;

namespace WpfLearning.Step16;

public partial class MainWindow : Window
{
    private int _nextNumber = 4;

    public ObservableCollection<string> Names { get; } = new() { "Ada", "Grace", "Linus" };

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

    private void AddName_Click(object sender, RoutedEventArgs e)
    {
        Names.Add($"Name {_nextNumber++}");
    }

    private void RemoveLast_Click(object sender, RoutedEventArgs e)
    {
        if (Names.Count > 0)
        {
            Names.RemoveAt(Names.Count - 1);
        }
    }
}
