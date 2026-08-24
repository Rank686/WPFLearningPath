# Step 40 Compare：带 Model 的完整 MVVM（CommunityToolkit）

## 先懂再跑

与 `Step40-MvvmWithModel` 并排对照。**界面、Binding、草稿/Model 职责完全相同**；ViewModel 改用 [CommunityToolkit.Mvvm](https://learn.microsoft.com/dotnet/communitytoolkit/mvvm/) 写薄 INPC / Command 样板。类必须声明为 **`partial`**。

### Model 没有变薄

`Learner.cs` 仍是普通 C# 类：数据 + 及格线 + 分数范围。Toolkit **不替代 Model**。它省的是 ViewModel 里一遍遍写的 `OnPropertyChanged` 和手写 `RelayCommand.cs`。

### 对照手写版多出来的属性

| 手写 Step 40 | Toolkit |
|---|---|
| 自己实现 `INotifyPropertyChanged` | `ObservableObject` |
| 手写 `Name` / `Score` / `StatusMessage` | `[ObservableProperty]` 私有字段 |
| `OnPropertyChanged(nameof(PassingPreview))` | `[NotifyPropertyChangedFor(nameof(PassingPreview))]` |
| `RelayCommand.cs` + `RaiseCanExecuteChanged()` | `[RelayCommand]` + `[NotifyCanExecuteChangedFor]` |
| `Score` setter 里 `Learner.ClampScore` | `OnScoreChanged` 里发现越界再写回钳制值 |

Save 之后草稿已经和 Model 一致，但 `Name`/`Score` 往往没变，生成器不会自动刷新 `CanExecute`。所以 Save / Reset 方法末尾仍要：

```csharp
SaveCommand.NotifyCanExecuteChanged();
ResetCommand.NotifyCanExecuteChanged();
```

这和手写版 `RaiseCommandsChanged()` 是同一件事。

## 运行后观察

与 Step 40 一样：

- 改 Score 只动 Draft 预览，Committed 不动
- Save 才写入 Model；Reset 用 Model 覆盖草稿
- 姓名清空后 Save 禁用，Reset 仍可用

## 改造对照

| | Step 40（手写） | 本样板（Toolkit） |
|---|---|---|
| Model | `Learner` 普通类 | 同一个 `Learner` |
| View | 绑 ViewModel | 相同 |
| 基类 | 自己实现 INPC | `ObservableObject` |
| 命令文件 | `RelayCommand.cs` | 不需要，已删除 |
| 分层 | View / ViewModel / Model | **不变** |

## ViewModel 核心

```csharp
public partial class MainWindowViewModel : ObservableObject
{
    private readonly Learner _learner;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PassingPreview))]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    [NotifyCanExecuteChangedFor(nameof(ResetCommand))]
    private string _name = "";

    [RelayCommand(CanExecute = nameof(CanSave))]
    private void Save() { /* 写入 _learner */ }
}
```

## 没变薄的部分

- `Learner` 的业务规则
- 草稿 vs 已提交记录
- View 只绑 ViewModel、Save/Reset 的职责划分

Toolkit 省的是样板代码，不是 MVVM 分层。

## 启动

```powershell
dotnet run --project "Track06-ApplicationAndMvvm/Step40-Compare-CommunityToolkitMvvm/Step40-Compare-CommunityToolkitMvvm.csproj"
```

建议与 `Step40-MvvmWithModel` 对照阅读 `Learner.cs` 和 `MainWindowViewModel.cs`。
