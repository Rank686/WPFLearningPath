using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace WpfLearning.Step21;

public partial class MainWindow : Window
{
    private bool _onlyActive;

    public ObservableCollection<WorkItem> Items { get; } = new()
    {
        new WorkItem { Title = "Write outline", Category = "Writing", IsActive = true },
        new WorkItem { Title = "Review sample", Category = "Learning", IsActive = false },
        new WorkItem { Title = "Run the project", Category = "Learning", IsActive = true },
        new WorkItem { Title = "Archive notes", Category = "Writing", IsActive = false }
    };

    public ICollectionView ItemsView { get; }

    public MainWindow()
    {
        InitializeComponent();
        ItemsView = CollectionViewSource.GetDefaultView(Items);
        DataContext = this;
        ItemsView.MoveCurrentToFirst();
        ShowVisibleCount();
    }

    private void AttachFilter_Click(object sender, RoutedEventArgs e)
    {
        ItemsView.Filter = FilterItem;
        AttachFilterButton.IsEnabled = false;
        OnlyActiveCheckBox.IsEnabled = true;
        ShowVisibleCount();
    }

    private bool FilterItem(object item)
    {
        var workItem = (WorkItem)item;
        return !_onlyActive || workItem.IsActive;
    }

    private void OnlyActiveChanged_Click(object sender, RoutedEventArgs e)
    {
        _onlyActive = OnlyActiveCheckBox.IsChecked == true;
        ItemsView.Refresh();
        ShowVisibleCount();
    }

    private void ClearFilter_Click(object sender, RoutedEventArgs e)
    {
        ItemsView.Filter = null;
        _onlyActive = false;
        OnlyActiveCheckBox.IsChecked = false;
        OnlyActiveCheckBox.IsEnabled = false;
        AttachFilterButton.IsEnabled = true;
        ShowVisibleCount();
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

    private void ShowVisibleCount()
    {
        var count = 0;
        foreach (var item in ItemsView)
        {
            count++;
        }

        VisibleCountText.Text = $"Visible rows: {count}";
    }
}
