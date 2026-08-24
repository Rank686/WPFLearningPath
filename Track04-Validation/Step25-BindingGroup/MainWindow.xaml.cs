using System.Windows;

namespace WpfLearning.Step25;

public partial class MainWindow : Window
{
    private readonly Offer _offer = new();

    public MainWindow()
    {
        InitializeComponent();
        DataContext = _offer;
    }

    private void SaveOffer_Click(object sender, RoutedEventArgs e)
    {
        var group = OfferEditor.BindingGroup;
        if (group.CommitEdit())
        {
            StatusText.Text = $"Offer saved: {_offer.StartPrice} to {_offer.BuyNowPrice}";
            return;
        }

        var errors = group.ValidationErrors;
        StatusText.Text = errors.Count > 0
            ? errors[0].ErrorContent?.ToString() ?? "Fix the offer."
            : "Fix the offer.";
    }
}
