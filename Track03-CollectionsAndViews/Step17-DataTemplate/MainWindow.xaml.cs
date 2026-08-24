using System.Collections.ObjectModel;
using System.Windows;

namespace WpfLearning.Step17;

public partial class MainWindow : Window
{
    private int _nextNumber = 3;

    public ObservableCollection<WorkItem> Items { get; } = new()
    {
        new WorkItem { Title = "Write outline", Category = "Writing", IsActive = true },
        new WorkItem { Title = "Review sample", Category = "Learning", IsActive = false }
    };

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

    private void AddItem_Click(object sender, RoutedEventArgs e)
    {
        Items.Add(new WorkItem
        {
            Title = $"New item {_nextNumber++}",
            Category = "Inbox",
            IsActive = true
        });
    }

    private void ToggleFirst_Click(object sender, RoutedEventArgs e)
    {
        if (Items.Count > 0)
        {
            Items[0].IsActive = !Items[0].IsActive;
        }
    }
}
