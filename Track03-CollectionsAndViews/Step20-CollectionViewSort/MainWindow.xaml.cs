using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace WpfLearning.Step20;

public partial class MainWindow : Window
{
    public ObservableCollection<WorkItem> Items { get; } = new()
    {
        new WorkItem { Title = "Write outline", Category = "Writing", IsActive = true },
        new WorkItem { Title = "Review sample", Category = "Learning", IsActive = false },
        new WorkItem { Title = "Run the project", Category = "Learning", IsActive = true }
    };

    public ICollectionView ItemsView { get; }

    public MainWindow()
    {
        InitializeComponent();
        ItemsView = CollectionViewSource.GetDefaultView(Items);
        DataContext = this;
        ItemsView.MoveCurrentToFirst();
    }

    private void SortByTitle_Click(object sender, RoutedEventArgs e)
    {
        ItemsView.SortDescriptions.Clear();
        ItemsView.SortDescriptions.Add(
            new SortDescription(nameof(WorkItem.Title), ListSortDirection.Ascending));
    }

    private void ClearSort_Click(object sender, RoutedEventArgs e)
    {
        ItemsView.SortDescriptions.Clear();
    }
}
