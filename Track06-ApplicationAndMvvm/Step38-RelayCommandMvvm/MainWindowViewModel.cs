using System.ComponentModel;
using System.Windows.Input;

namespace WpfLearning.Step38;

public sealed class MainWindowViewModel : INotifyPropertyChanged
{
    private readonly RelayCommand _saveCommand;
    private string _name = "WPF learner";
    private string _savedMessage = "Nothing saved yet.";

    public MainWindowViewModel()
    {
        _saveCommand = new RelayCommand(
            _ => SavedMessage = $"Saved: {Name}",
            _ => !string.IsNullOrWhiteSpace(Name));
        SaveCommand = _saveCommand;
    }

    public string Name
    {
        get => _name;
        set
        {
            if (_name == value)
            {
                return;
            }

            _name = value;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Greeting));
            _saveCommand.RaiseCanExecuteChanged();
        }
    }

    public string Greeting => string.IsNullOrWhiteSpace(Name)
        ? "Type your name above."
        : $"Hello, {Name}!";

    public ICommand SaveCommand { get; }

    public string SavedMessage
    {
        get => _savedMessage;
        private set
        {
            if (_savedMessage == value)
            {
                return;
            }

            _savedMessage = value;
            OnPropertyChanged(nameof(SavedMessage));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
