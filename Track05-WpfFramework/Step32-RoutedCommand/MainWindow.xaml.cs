using System.Windows;
using System.Windows.Input;
namespace WpfLearning.Step32;
public partial class MainWindow : Window
{
    public static RoutedCommand SaveCommand { get; } = new();
    public MainWindow()
    {
        InitializeComponent();
        this.CommandBindings.Add(new CommandBinding(SaveCommand, Save_Executed, Save_CanExecute));
        SaveButton.Command = SaveCommand;
    }
    private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = CanSaveCheckBox.IsChecked == true;
        e.Handled = true;
    }
    private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        CommandStatus.Text = "Save command executed";
        e.Handled = true;
    }
    private void CanSave_Click(object sender, RoutedEventArgs e) { CommandManager.InvalidateRequerySuggested(); }
}
