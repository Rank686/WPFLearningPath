using System.ComponentModel;
using System.Windows.Input;

namespace WpfLearning.Step47;

public sealed class MainWindowViewModel : INotifyPropertyChanged
{
    private readonly RelayCommand _saveCommand;
    private int _rating;
    private string _savedMessage = "Nothing saved yet.";

    public MainWindowViewModel()
    {
        _saveCommand = new RelayCommand(
            _ => SavedMessage = $"Saved rating: {Rating}/5",
            _ => Rating > 0);
        SaveCommand = _saveCommand;
    }

    public int Rating
    {
        get => _rating;
        set
        {
            var rating = Math.Clamp(value, 0, 5);
            if (_rating == rating)
            {
                return;
            }

            _rating = rating;
            OnPropertyChanged(nameof(Rating));
            OnPropertyChanged(nameof(CanSave));
            _saveCommand.RaiseCanExecuteChanged();
        }
    }

    public bool CanSave => Rating > 0;

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

    public ICommand SaveCommand { get; }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
