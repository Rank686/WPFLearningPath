using System.ComponentModel;

namespace WpfLearning.Step44;

public class WorkItem : INotifyPropertyChanged
{
    private string _title = string.Empty;
    private bool _isDone;
    private string _category = string.Empty;
    private int _estimate;
    private int _completed;

    public WorkItem()
    {
    }

    public string Title
    {
        get => _title;
        set
        {
            if (_title == value)
            {
                return;
            }

            _title = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
        }
    }

    public bool IsDone
    {
        get => _isDone;
        set
        {
            if (_isDone == value)
            {
                return;
            }

            _isDone = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsDone)));
        }
    }

    public string Category
    {
        get => _category;
        set
        {
            if (_category == value)
            {
                return;
            }

            _category = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Category)));
        }
    }

    public int Estimate
    {
        get => _estimate;
        set
        {
            if (_estimate == value)
            {
                return;
            }

            _estimate = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Estimate)));
        }
    }

    public int Completed
    {
        get => _completed;
        set
        {
            if (_completed == value)
            {
                return;
            }

            _completed = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Completed)));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
