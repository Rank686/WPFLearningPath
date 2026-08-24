using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfLearning.Step38Toolkit;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Greeting))]
    private string _name = "WPF learner";

    public string Greeting => string.IsNullOrWhiteSpace(Name)
        ? "Type your name above."
        : $"Hello, {Name}!";

    [ObservableProperty]
    private string _savedMessage = "Nothing saved yet.";

    [RelayCommand(CanExecute = nameof(CanSave))]
    private void Save()
    {
        SavedMessage = $"Saved: {Name}";
    }

    private bool CanSave() => !string.IsNullOrWhiteSpace(Name);
}
