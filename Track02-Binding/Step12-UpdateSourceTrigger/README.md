# Step 12：UpdateSourceTrigger

## 本步唯一新增

比较 LostFocus、PropertyChanged 与 Explicit 三种源更新时机，并用 BindingExpression.UpdateSource 手动提交 Explicit 输入。

## 运行后观察

输入后立即点 Inspect：LostFocus 与 Explicit 源仍是旧值，PropertyChanged 源已更新；Tab 离开 LostFocus 输入后它才更新；Apply 才提交 Explicit。

## 相比同轨上一步的改动

Profile 换成三个普通字符串属性；界面改为三种 UpdateSourceTrigger 输入和两个已学过的 Click 按钮。

## 已学并复用

DataContext、TwoWay Binding、x:Name、StackPanel 与 XAML Click。

## 固定脚手架

App、StartupUri、Window、x:Class、必要 xmlns、partial 与 InitializeComponent。

## 源码中保证不存在

INotifyPropertyChanged、Validation、BindingGroup、Dispatcher、Timer。

## 完成后的综合练习

完成 Step14 后再打开 `Data Binding/UpdateSource/UpdateSource.csproj`；它是原版综合项目，不保证单概念纯度。
