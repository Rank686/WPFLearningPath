using System.Collections.ObjectModel;
using System.Windows;

namespace WpfLearning.Step42;

public partial class MainWindow : Window
{
    private readonly ObservableCollection<WorkItem> _items =
    [
        new WorkItem { Title = "Write tests", IsDone = false },
        new WorkItem { Title = "Review notes", IsDone = true },
        new WorkItem { Title = "Build demo", IsDone = false }
    ];

    public MainWindow()
    {
        InitializeComponent();
        DataContext = _items;
        DeleteButton.Click += Delete_Click;
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        _items.Add(new WorkItem { Title = "New work item", IsDone = false });
    }

    private void Update_Click(object sender, RoutedEventArgs e)
    {
        if (WorkItemList.SelectedItem is WorkItem selected)
        {
            selected.Title += " *";
        }
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        if (WorkItemList.SelectedItem is WorkItem selected)
        {
            _items.Remove(selected);
        }
    }
}
