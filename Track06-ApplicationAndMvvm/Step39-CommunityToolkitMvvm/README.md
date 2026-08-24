# Step 38 Toolkit：CommunityToolkit.Mvvm 改造样板

## 先懂再跑

与 `Step38-RelayCommandMvvm` 并排对照。**界面、Binding、行为完全相同**；ViewModel 改用 [CommunityToolkit.Mvvm](https://learn.microsoft.com/dotnet/communitytoolkit/mvvm/) 写薄 INPC / Command 样板代码。类必须声明为 **`partial`**，属性与命令由编译时源生成器生成。

### `[ObservableProperty]`：写字段，用属性

```csharp
[ObservableProperty]
private string _savedMessage = "Nothing saved yet.";
```

你写的是 **私有字段** `_savedMessage`；生成器会造出公开属性 **`SavedMessage`**（带 get/set 和 `PropertyChanged` 通知）。

代码和 XAML 里用的是 **`SavedMessage`**（无下划线），不是 `_savedMessage`：

```csharp
SavedMessage = $"Saved: {Name}";   // Save 里改的是生成属性
```

```xml
Text="{Binding SavedMessage}"
```

| 手写 Step 38 | Toolkit |
|---|---|
| `private string _savedMessage` + 手写 `SavedMessage` 属性 | 只写字段，属性自动生成 |

字段看起来「没用到」是正常的：IDE 有时不把生成代码算进去；真正用的是生成出来的 `SavedMessage`。

**字段必须是 `private`。** 约定是：字段只做后备存储，对外只暴露生成的属性。若写成 `public` 字段，会和生成属性重复，破坏封装，分析器也会提示。

### `[NotifyPropertyChangedFor(nameof(Greeting))]`

标在 `_name` 上，意思是：**`Name` 变化时，除了通知 `Name`，还要再通知 `Greeting`。**

`Greeting` 是只读计算属性，自己没有 setter，不会自动发 `PropertyChanged`。界面绑了 `{Binding Greeting}`，若只通知 `Name`，问候语不会刷新。

对应 Step 38 手写版里 `Name` setter 中的：

```csharp
OnPropertyChanged(nameof(Name));
OnPropertyChanged(nameof(Greeting));
```

记法：**A 变了，依赖 A 的只读属性 B 也要通知 UI** → 在 A 的字段上标 `[NotifyPropertyChangedFor(nameof(B))]`。

### `[RelayCommand]`

```csharp
[RelayCommand(CanExecute = nameof(CanSave))]
private void Save() => SavedMessage = $"Saved: {Name}";
```

生成公开属性 **`SaveCommand`**（`ICommand`），XAML 仍写 `Command="{Binding SaveCommand}"`。`CanSave()` 为 false 时按钮自动禁用；`Name` 变化时 Toolkit 会自动刷新 `CanExecute`，不必手写 `RaiseCanExecuteChanged()`。

## 运行后观察

与 Step 38 一样：

- 输入 `Name` 时 `Greeting` 实时更新
- 清空 `Name` 后 Save 禁用；有内容后启用
- 点 Save 后 `SavedMessage` 变化
- Open tool window 仍是 View 层 `Click`

## 改造对照

| | Step 38（手写） | 本样板（Toolkit） |
|---|---|---|
| 基类 | 自己实现 `INotifyPropertyChanged` | `ObservableObject` |
| 属性 | 手写 get/set + `OnPropertyChanged` | `[ObservableProperty]` 私有字段 |
| 关联属性通知 | `OnPropertyChanged(nameof(Greeting))` | `[NotifyPropertyChangedFor(nameof(Greeting))]` |
| 命令 | 自建 `RelayCommand.cs` + 构造函数里 `new` | `[RelayCommand]` 方法，生成 `SaveCommand` |
| `CanExecute` 刷新 | `Name` setter 里 `RaiseCanExecuteChanged()` | Toolkit 根据 `CanSave()` 自动挂钩 |
| 删除的文件 | — | 不需要 `RelayCommand.cs` |

## ViewModel 核心（完整）

```csharp
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
    private void Save() => SavedMessage = $"Saved: {Name}";

    private bool CanSave() => !string.IsNullOrWhiteSpace(Name);
}
```

## 没变薄的部分

- XAML、`DataContext` 接线、Application 启动与资源
- ViewModel 职责边界（Save → Command，开窗 → Click）
- MVVM 分层本身

Toolkit 省的是 INPC / Command 重复代码，不是架构设计。

## 启动

```powershell
dotnet run --project "LearningPath/Track06-ApplicationAndMvvm/Step38-CommunityToolkitMvvm/Step38-CommunityToolkitMvvm.csproj"
```

建议与 `Step38-RelayCommandMvvm` 对照阅读 `MainWindowViewModel.cs`。
