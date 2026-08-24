using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
namespace WpfLearning.Step34Compare;
public sealed class RatingBadge : Border, INotifyPropertyChanged
{
    private int _rating;
    public int Rating
    {
        get => _rating;
        set
        {
            if (_rating == value) return;
            _rating = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
