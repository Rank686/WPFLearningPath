using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace WpfLearning.Step43;

public partial class MainWindow : Window
{
    public ObservableCollection<WorkItem> Items { get; } =
    [
        new WorkItem { Title = "Write tests", IsDone = false, Category = "Engineering" },
        new WorkItem { Title = "Review notes", IsDone = true, Category = "Documentation" },
        new WorkItem { Title = "Build demo", IsDone = false, Category = "Engineering" }
    ];

    public ICollectionView ItemsView { get; }

    public MainWindow()
    {
        InitializeComponent();
        ItemsView = CollectionViewSource.GetDefaultView(Items);
        DataContext = this;
        DeleteButton.Click += Delete_Click;
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        Items.Add(new WorkItem { Title = "New work item", IsDone = false, Category = "Engineering" });
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
            Items.Remove(selected);
        }
    }

    private void Sort_Click(object sender, RoutedEventArgs e)
    {
        ItemsView.SortDescriptions.Clear();
        ItemsView.SortDescriptions.Add(new SortDescription(nameof(WorkItem.Title), ListSortDirection.Ascending));
    }

    private void Group_Click(object sender, RoutedEventArgs e)
    {
        ItemsView.GroupDescriptions.Clear();
        ItemsView.GroupDescriptions.Add(new PropertyGroupDescription(nameof(WorkItem.Category)));
    }

    private void Filter_Click(object sender, RoutedEventArgs e)
    {
        ItemsView.Filter = OpenOnlyCheckBox.IsChecked == true
            ? item => item is WorkItem workItem && !workItem.IsDone
            : null;
    }
}
