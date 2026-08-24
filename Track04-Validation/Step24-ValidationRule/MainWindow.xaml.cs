using System.Windows;

namespace WpfLearning.Step24;

public partial class MainWindow : Window
{
    private readonly PriceEntry _entry = new();

    public MainWindow()
    {
        InitializeComponent();
        DataContext = _entry;
    }

    private void ReadSource_Click(object sender, RoutedEventArgs e)
    {
        StatusText.Text = $"Source Price: {_entry.Price}";
    }
}
