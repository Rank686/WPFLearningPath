using System.ComponentModel;

namespace WpfLearning.Step40;

public sealed class ProfileViewModel : INotifyPropertyChanged
{
    private string _name = "Ada";
    private string _city = "London";
    private double _score = 72d;

    public event PropertyChangedEventHandler? PropertyChanged;

    public string Name
    {
        get => _name;
        set
        {
            if (string.Equals(_name, value, StringComparison.Ordinal)) return;
            _name = value;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Summary));
        }
    }

    public string City
    {
        get => _city;
        set
        {
            if (string.Equals(_city, value, StringComparison.Ordinal)) return;
            _city = value;
            OnPropertyChanged(nameof(City));
            OnPropertyChanged(nameof(Summary));
        }
    }

    public double Score
    {
        get => _score;
        set
        {
            if (_score.Equals(value)) return;
            _score = value;
            OnPropertyChanged(nameof(Score));
        }
    }

    public string Summary => $"{Name} · {City}";

    private void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
