using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfLearning.Step44;

public partial class MainWindow : Window
{
    private readonly IEditableCollectionView _editableView;

    public ObservableCollection<WorkItem> Items { get; } =
    [
        new WorkItem { Title = "Write tests", IsDone = false, Category = "Engineering", Estimate = 5, Completed = 2 },
        new WorkItem { Title = "Review notes", IsDone = true, Category = "Documentation", Estimate = 3, Completed = 3 },
        new WorkItem { Title = "Build demo", IsDone = false, Category = "Engineering", Estimate = 8, Completed = 4 }
    ];

    public ICollectionView ItemsView { get; }

    public MainWindow()
    {
        InitializeComponent();
        ItemsView = CollectionViewSource.GetDefaultView(Items);
        _editableView = (IEditableCollectionView)ItemsView;
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

    private void BeginNew_Click(object sender, RoutedEventArgs e)
    {
        OpenOnlyCheckBox.IsChecked = false;
        ItemsView.Filter = null;
        ItemsView.SortDescriptions.Clear();
        ItemsView.GroupDescriptions.Clear();
        if (!_editableView.CanAddNew)
        {
            return;
        }

        var newItem = _editableView.AddNew();
        ItemsView.MoveCurrentTo(newItem);
        WorkItemList.SelectedItem = newItem;
    }

    private void SaveRow_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var container = (ListBoxItem)WorkItemList.ContainerFromElement(button);
        if (!container.BindingGroup.CommitEdit())
        {
            var error = container.BindingGroup.ValidationErrors.FirstOrDefault();
            EditStatus.Text = error?.ErrorContent?.ToString() ?? "Validation failed.";
            return;
        }

        EditStatus.Text = string.Empty;
        if (_editableView.IsAddingNew && ReferenceEquals(_editableView.CurrentAddItem, container.DataContext))
            _editableView.CommitNew();
    }

    private void CancelRow_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var container = (ListBoxItem)WorkItemList.ContainerFromElement(button);
        if (_editableView.IsAddingNew && ReferenceEquals(_editableView.CurrentAddItem, container.DataContext))
        {
            _editableView.CancelNew();
        }

        EditStatus.Text = string.Empty;
    }
}
