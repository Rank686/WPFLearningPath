using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace WpfLearning.Step23;

public partial class MainWindow : Window
{
    private bool _onlyActive;
    private WorkItem? _pendingItem;

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
        Editor.DataContext = null;
        EditorStatusText.Text = "No pending item";
    }

    private void BeginNew_Click(object sender, RoutedEventArgs e)
    {
        if (_pendingItem is not null)
        {
            return;
        }

        ItemsView.Filter = null;
        ItemsView.SortDescriptions.Clear();
        ItemsView.GroupDescriptions.Clear();
        ResetFilterControls();

        var editableView = (IEditableCollectionView)ItemsView;
        if (!editableView.CanAddNew)
        {
            throw new InvalidOperationException("The view cannot add items.");
        }

        _pendingItem = (WorkItem)editableView.AddNew();
        Editor.DataContext = _pendingItem;
        EditorStatusText.Text = "Editing a provisional item";
    }

    private void CommitNew_Click(object sender, RoutedEventArgs e)
    {
        if (_pendingItem is null)
        {
            return;
        }

        ((IEditableCollectionView)ItemsView).CommitNew();
        _pendingItem = null;
        Editor.DataContext = null;
        EditorStatusText.Text = "Committed";
    }

    private void CancelNew_Click(object sender, RoutedEventArgs e)
    {
        if (_pendingItem is null)
        {
            return;
        }

        ((IEditableCollectionView)ItemsView).CancelNew();
        _pendingItem = null;
        Editor.DataContext = null;
        EditorStatusText.Text = "Canceled and removed";
    }

    private void AttachFilter_Click(object sender, RoutedEventArgs e)
    {
        ItemsView.Filter = FilterItem;
        AttachFilterButton.IsEnabled = false;
        OnlyActiveCheckBox.IsEnabled = true;
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
    }

    private void SortByTitle_Click(object sender, RoutedEventArgs e)
    {
        ItemsView.SortDescriptions.Clear();
        ItemsView.SortDescriptions.Add(
            new SortDescription(nameof(WorkItem.Title), ListSortDirection.Ascending));
    }

    private void GroupByCategory_Click(object sender, RoutedEventArgs e)
    {
        ItemsView.Filter = null;
        ItemsView.SortDescriptions.Clear();
        ItemsView.GroupDescriptions.Clear();
        ItemsView.GroupDescriptions.Add(
            new PropertyGroupDescription(nameof(WorkItem.Category)));
        ResetFilterControls();
    }

    private void ClearViewShaping_Click(object sender, RoutedEventArgs e)
    {
        ItemsView.Filter = null;
        ItemsView.SortDescriptions.Clear();
        ItemsView.GroupDescriptions.Clear();
        ResetFilterControls();
    }

    private void ResetFilterControls()
    {
        _onlyActive = false;
        OnlyActiveCheckBox.IsChecked = false;
        OnlyActiveCheckBox.IsEnabled = false;
        AttachFilterButton.IsEnabled = true;
    }
}
