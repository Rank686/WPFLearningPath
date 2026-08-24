# Step 07：MergedDictionaries

## 本步唯一新增

把已经学过的画刷和 Style 移到独立 ResourceDictionary，并通过 ResourceDictionary.MergedDictionaries 加载它。

## 运行后观察

界面与 Step06 保持一致；资源定义虽然移到了 `Themes/TrackTheme.xaml`，原来的 StaticResource 键仍能解析。

## 相比同轨上一步的改动

新增 `Themes/TrackTheme.xaml`；`MainWindow.xaml` 的 Window.Resources 改为合并这个文件，原画刷和 Style 从主窗口移除。

## 已学并复用

Window.Resources、x:Key、StaticResource、命名 Style、Setter、StackPanel 与事件订阅。

## 固定脚手架

App、StartupUri、Window、x:Class、必要 xmlns、partial 与 InitializeComponent。

## 源码中保证不存在

多个字典优先级、DynamicResource、运行时换肤、Application.Resources、BasedOn、Trigger。

## 完成后的综合练习

现在可以打开 `Resources/MergedResources/MergedResources.csproj`；它是原版综合项目，不保证单概念纯度。
