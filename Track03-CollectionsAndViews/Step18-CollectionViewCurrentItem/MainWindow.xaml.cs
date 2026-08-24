using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace WpfLearning.Step18;

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
        ShowCurrentItem();
    }

    private void Previous_Click(object sender, RoutedEventArgs e)
    {
        if (!ItemsView.MoveCurrentToPrevious())
        {
            ItemsView.MoveCurrentToLast();
        }

        ShowCurrentItem();
    }

    private void Next_Click(object sender, RoutedEventArgs e)
    {
        if (!ItemsView.MoveCurrentToNext())
        {
            ItemsView.MoveCurrentToFirst();
        }

        ShowCurrentItem();
    }

    private void ShowCurrentItem()
    {
        CurrentItemText.Text = ItemsView.CurrentItem is WorkItem item
            ? $"Current item: {item.Title}"
            : "Current item: none yet; press Next";
    }
}
