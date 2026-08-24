# Step 04：命名元素与 C# 事件订阅

## 本步唯一新增

使用 x:Name 取得 XAML 元素生成的字段，并在 `InitializeComponent()` 之后用 `CodeButton.Click += CodeButton_Click` 订阅事件。

## 运行后观察

两个按钮都能响应点击：上方按钮在 XAML 中订阅，下方按钮在 C# 构造器中订阅。

## 相比同轨上一步的改动

`MainWindow.xaml` 新增命名的 CodeButton；`MainWindow.xaml.cs` 新增一条 `+=` 订阅与对应处理器。

## 已学并复用

Window、StackPanel、XAML Click 与 RoutedEventArgs 处理器签名。

## 固定脚手架

App、StartupUri、Window、x:Class、必要 xmlns、partial 与 InitializeComponent。

## 源码中保证不存在

动态创建控件、lambda、弱事件、Command、Binding。

## 完成后的综合练习

完成 Step07 后再打开 `Events/AddingEventHandler/AddingEventHandler.csproj`；它是原版综合项目，不保证单概念纯度。
