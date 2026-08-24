using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfLearning.Step40Toolkit;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly Learner _learner;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PassingPreview))]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    [NotifyCanExecuteChangedFor(nameof(ResetCommand))]
    private string _name = "";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PassingPreview))]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    [NotifyCanExecuteChangedFor(nameof(ResetCommand))]
    private int _score;

    [ObservableProperty]
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
    }

    public string PassingPreview => Learner.IsPassingScore(Score)
        ? $"Passing preview (score >= {Learner.PassingScore})"
        : $"Not passing yet (need {Learner.PassingScore})";

    public string CommittedSummary => _learner.Summary;

    partial void OnScoreChanged(int value)
    {
        var clamped = Learner.ClampScore(value);
        if (clamped != value)
        {
            Score = clamped;
        }
    }

    [RelayCommand(CanExecute = nameof(CanSave))]
    private void Save()
    {
        _learner.Name = Name.Trim();
        _learner.Score = Learner.ClampScore(Score);
        Name = _learner.Name;
        Score = _learner.Score;
        OnPropertyChanged(nameof(CommittedSummary));
        StatusMessage = $"Saved {_learner.Summary}";
        SaveCommand.NotifyCanExecuteChanged();
        ResetCommand.NotifyCanExecuteChanged();
    }

    [RelayCommand(CanExecute = nameof(CanReset))]
    private void Reset()
    {
        Name = _learner.Name;
        Score = _learner.Score;
        StatusMessage = "Draft restored from Model.";
        SaveCommand.NotifyCanExecuteChanged();
        ResetCommand.NotifyCanExecuteChanged();
    }

    private bool CanSave() => !string.IsNullOrWhiteSpace(Name) && IsDirty();

    private bool CanReset() => IsDirty();

    private bool IsDirty()
    {
        return !string.Equals(Name.Trim(), _learner.Name, StringComparison.Ordinal)
            || Score != _learner.Score;
    }
}
