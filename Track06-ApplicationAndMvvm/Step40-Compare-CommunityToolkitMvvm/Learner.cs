namespace WpfLearning.Step40Toolkit;

/// <summary>
/// 业务记录（Model）：已提交的数据 + 领域规则。
/// 不含界面文案、不含 ICommand、不含 INotifyPropertyChanged。
/// Toolkit 只写薄 ViewModel，这一层与手写版相同。
/// </summary>
public sealed class Learner
{
    public const int MinScore = 0;
    public const int MaxScore = 100;
    public const int PassingScore = 60;

    public string Name { get; set; } = "";

    public int Score { get; set; }

    public bool IsPassing => IsPassingScore(Score);

    public string Summary => string.IsNullOrWhiteSpace(Name)
        ? "(unnamed)"
        : $"{Name} · {Score} · {(IsPassing ? "passing" : "not passing")}";

    public static int ClampScore(int score) => Math.Clamp(score, MinScore, MaxScore);

    public static bool IsPassingScore(int score) => score >= PassingScore;
}
