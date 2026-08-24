# Step 05：x:Key 与 StaticResource

## 本步唯一新增

在 Window.Resources 中用 x:Key 保存一个 SolidColorBrush，并用 `{StaticResource AccentBrush}` 在两个元素上复用它。

## 运行后观察

标题和第一个按钮使用同一种深蓝色；修改资源中的 Color 会同时影响两个使用位置。

## 相比同轨上一步的改动

`MainWindow.xaml` 新增 Window.Resources、AccentBrush，以及两个 StaticResource 引用；事件代码未改变。

## 已学并复用

Window、StackPanel、XAML Click、x:Name 与 C# `+=` 事件订阅。

## 固定脚手架

App、StartupUri、Window、x:Class、必要 xmlns、partial 与 InitializeComponent。

## 源码中保证不存在

Style、DynamicResource、MergedDictionaries、Application.Resources。

## 完成后的综合练习

完成 Step07 后再打开 `Resources/DefiningResources/DefiningResources.csproj` 的资源部分；它是原版综合项目，不保证单概念纯度。
