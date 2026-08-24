using System.ComponentModel;
using System.Windows.Input;

namespace WpfLearning.Step40;

public sealed class MainWindowViewModel : INotifyPropertyChanged
{
    private readonly Learner _learner;
    private readonly RelayCommand _saveCommand;
    private readonly RelayCommand _resetCommand;
    private string _name;
    private int _score;
    private string _statusMessage = "Edit the draft, then Save to write the Model.";

    public MainWindowViewModel()
    {
        _learner = new Learner
        {
            Name = "WPF learner",
            Score = 75
        };
        _name = _learner.Name;
        _score = _learner.Score;

        _saveCommand = new RelayCommand(_ => Save(), _ => CanSave());
        _resetCommand = new RelayCommand(_ => Reset(), _ => CanReset());
        SaveCommand = _saveCommand;
        ResetCommand = _resetCommand;
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
            OnPropertyChanged(nameof(PassingPreview));
            RaiseCommandsChanged();
        }
    }

    public int Score
    {
        get => _score;
        set
        {
            var score = Learner.ClampScore(value);
            if (_score == score)
            {
                return;
            }

            _score = score;
            OnPropertyChanged(nameof(Score));
            OnPropertyChanged(nameof(PassingPreview));
            RaiseCommandsChanged();
        }
    }

    public string PassingPreview => Learner.IsPassingScore(Score)
        ? $"Passing preview (score >= {Learner.PassingScore})"
        : $"Not passing yet (need {Learner.PassingScore})";

    public string CommittedSummary => _learner.Summary;

    public string StatusMessage
    {
        get => _statusMessage;
        private set
        {
            if (_statusMessage == value)
            {
                return;
            }

            _statusMessage = value;
            OnPropertyChanged(nameof(StatusMessage));
        }
    }

    public ICommand SaveCommand { get; }

    public ICommand ResetCommand { get; }

    public event PropertyChangedEventHandler? PropertyChanged;

    private bool CanSave() => !string.IsNullOrWhiteSpace(Name) && IsDirty();

    private bool CanReset() => IsDirty();

    private bool IsDirty()
    {
        return !string.Equals(Name.Trim(), _learner.Name, StringComparison.Ordinal)
            || Score != _learner.Score;
    }

    private void Save()
    {
        _learner.Name = Name.Trim();
        _learner.Score = Learner.ClampScore(Score);
        Name = _learner.Name;
        Score = _learner.Score;
        OnPropertyChanged(nameof(CommittedSummary));
        StatusMessage = $"Saved {_learner.Summary}";
        RaiseCommandsChanged();
    }

    private void Reset()
    {
        Name = _learner.Name;
        Score = _learner.Score;
        StatusMessage = "Draft restored from Model.";
        RaiseCommandsChanged();
    }

    private void RaiseCommandsChanged()
    {
        _saveCommand.RaiseCanExecuteChanged();
        _resetCommand.RaiseCanExecuteChanged();
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
