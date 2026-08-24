# Step 03：XAML Click 与 code-behind

## 本步唯一新增

在 XAML 的 Button 上写 `Click="ChangeText_Click"`，由同名 C# 方法处理点击。

## 运行后观察

点击按钮后，它自己的 Content 从“Click me”变为“Clicked”。处理器通过 sender 找到被点击按钮。

## 相比同轨上一步的改动

`MainWindow.xaml` 的 Button 新增 Click；`MainWindow.xaml.cs` 新增一个最小事件处理器。

## 已学并复用

Window、StackPanel 自动排列与基本布局属性。

## 固定脚手架

App、StartupUri、Window、x:Class、必要 xmlns、partial 与 InitializeComponent。

## 源码中保证不存在

C# `+=`、x:Name、事件路由理论、Command、Binding。

## 完成后的综合练习

完成 Step07 后再打开 `Getting Started/DynamicLayout/DynamicLayout.csproj`；它是原版综合项目，不保证单概念纯度。
