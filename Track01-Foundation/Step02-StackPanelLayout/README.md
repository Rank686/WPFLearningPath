# Step 02：StackPanel 自动排列

## 本步唯一新增

使用 StackPanel 按声明顺序自动排列多个子元素，并观察 Orientation、Margin、Width 与对齐属性。

## 运行后观察

三个子元素从上到下排列；Margin 只负责元素之间的留白，Button 的 Width 固定为 180。

## 相比同轨上一步的改动

`MainWindow.xaml` 用 StackPanel 包住三个子元素；其余 App 与窗口外壳保持独立副本。

## 已学并复用

Window、XAML 嵌套、TextBlock 与固定脚手架。

## 固定脚手架

App、StartupUri、Window、x:Class、必要 xmlns、partial 与 InitializeComponent。

## 源码中保证不存在

事件、资源、Style、Binding。

## 完成后的综合练习

完成 Step07 后再打开 `Getting Started/SimpleLayout/SimpleLayout.csproj`；它是原版综合项目，不保证单概念纯度。
