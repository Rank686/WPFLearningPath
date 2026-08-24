using System.Windows;
namespace WpfLearning.Step35;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent(); 
        ShowLog();
    }
    private void SetFour_Click(object sender, RoutedEventArgs e)
    {
        RatingBadge.ClearLog(); 
        RatingBadge.Rating = 4; 
        ShowLog();
    }
    private void RequestNine_Click(object sender, RoutedEventArgs e)
    {
        RatingBadge.ClearLog(); 
        RatingBadge.Rating = 9; 
        ShowLog();
    }
    private void LowerMaximum_Click(object sender, RoutedEventArgs e)
    {
        RatingBadge.Maximum = 5;
        RatingBadge.Rating = 5;
        RatingBadge.ClearLog();
        RatingBadge.Maximum = 3;
        ShowLog();
    }
    private void ShowLog()
    {
        StateText.Text = $"Effective Rating={RatingBadge.Rating}; Maximum={RatingBadge.Maximum}";
        CallbackLog.Text = RatingBadge.LogText;
    }
}
