using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WpfLearning.Step26;

public partial class MainWindow : Window
{
    public ObservableCollection<Offer> Offers { get; } = new()
    {
        new Offer { StartPrice = 20m, BuyNowPrice = 30m },
        new Offer { StartPrice = 40m, BuyNowPrice = 60m }
    };

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

    private void SaveRow_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var container = (FrameworkElement)OfferItems.ContainerFromElement(button);
        StatusText.Text = container.BindingGroup.CommitEdit()
            ? "Row saved"
            : "Fix this row";
    }
}
