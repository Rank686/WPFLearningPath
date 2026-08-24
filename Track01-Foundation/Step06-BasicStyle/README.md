# Step 06：Style 与 Setter

## 本步唯一新增

使用带 x:Key 的命名 Style，把 TextBlock 的 FontSize、Foreground 与 Margin 收进 Setter，并显式应用到两个元素。

## 运行后观察

两个 TextBlock 具有相同字体、颜色和下边距；只修改 Style 中的 Setter 即可同时改变两者。

## 相比同轨上一步的改动

`MainWindow.xaml` 新增 SectionTextStyle，并将两段标题改为显式引用该命名 Style。

## 已学并复用

Window.Resources、x:Key、StaticResource、StackPanel 与两种事件订阅方式。

## 固定脚手架

App、StartupUri、Window、x:Class、必要 xmlns、partial 与 InitializeComponent。

## 源码中保证不存在

隐式 Style、BasedOn、Trigger、ControlTemplate、DataTemplate。

## 完成后的综合练习

完成 Step07 后再打开 `Resources/DefiningResources/DefiningResources.csproj` 的 Style 部分；它是原版综合项目，不保证单概念纯度。
