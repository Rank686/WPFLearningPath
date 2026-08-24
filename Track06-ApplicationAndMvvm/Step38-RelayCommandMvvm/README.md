# Step 38：ICommand 与 RelayCommand

## 先懂再跑

Step 37 说了：**跟状态/规则有关的点击进 ViewModel，纯 UI 动作留 View。** 本步把这句话落地到 Save 按钮。

### Save 为什么用 Command，不用 Click

Save 会改 `SavedMessage`，还要根据 `Name` 决定能不能点——都是 ViewModel 职责。所以：

```xml
<Button Content="Save" Command="{Binding SaveCommand}" />
```

逻辑在 ViewModel 的 `RelayCommand` 里：

- **Execute**：`SavedMessage = $"Saved: {Name}"`
- **CanExecute**：`Name` 非空才能点

`Name` 变化时调用 `RaiseCanExecuteChanged()`，按钮自动启用/禁用，不必在 Window 里写 `Save_Click`。

### Open tool window 为什么仍是 Click

和 Step 37 一样：`new ToolWindow().Show()` 是开窗口的 UI 动作，不改 ViewModel 状态，所以继续留在 `MainWindow` 的 code-behind。课程故意把两种按钮并排放着，方便对照边界。

| 按钮 | 写法 | 原因 |
|---|---|---|
| Save | `Command="{Binding SaveCommand}"` | 改 ViewModel 状态 + 可用性规则 |
| Open tool window | `Click="OpenToolWindow_Click"` | 纯 UI / 框架动作 |

## 本步唯一新增

`RelayCommand` 把 `CanExecute` 和 `Execute` 暴露给 `Button.Command`，保存动作留在 ViewModel。

## 运行后观察

清空 `Name` 后 Save 立即禁用；重新输入后启用；点击 Save 后 `SavedMessage` 立即变化。

## 相比同轨上一步的改动

保留同一个 ViewModel、即时文本更新与应用作用域，只增加一个最小命令类和保存状态。

## 已学并复用

ViewModel、DataContext、Binding、`UpdateSourceTrigger=PropertyChanged` 与属性变化通知。

## 固定脚手架

打开工具窗口仍用普通 `Click`，以免把上一课的 Application 演示混入保存命令。

## 源码中保证不存在

RoutedCommand、CommandBinding、CommandParameter、异步命令、依赖注入、导航和第三方 MVVM 框架。

## 完成后的综合练习

现在可以打开仓库内的 CustomComboBox 综合示例，并回看本轨列出的 Application 原版综合示例。

对照阅读：`Step39-CommunityToolkitMvvm`（同一界面，用 CommunityToolkit.Mvvm 写薄的 ViewModel 样板）。下一步 `Step40-MvvmWithModel` 会补上独立的 Model 层。
