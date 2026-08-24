# Step 13：INotifyPropertyChanged

## 本步唯一新增

Profile 使用 backing field、INotifyPropertyChanged、PropertyChanged 事件和显式 OnPropertyChanged 通知属性变化。

## 运行后观察

点击按钮只修改 Profile.DisplayName；没有直接改 TextBlock，但绑定目标仍会在“Ada Lovelace”和“Grace Hopper”之间自动更新。

## 相比同轨上一步的改动

移除三种 UpdateSourceTrigger 输入；Profile 改为可通知属性，主界面只保留源属性、显示目标和 Change Source 按钮。

## 已学并复用

DataContext、OneWay Binding、x:Name 与 XAML Click。

## 固定脚手架

App、StartupUri、Window、x:Class、必要 xmlns、partial 与 InitializeComponent。

## 源码中保证不存在

CallerMemberName、ViewModel 基类、ObservableCollection、async、Dispatcher、Timer。

## 完成后的综合练习

完成 Step14 后再打开 `Data Binding/SimpleBinding/SimpleBinding.csproj` 的通知部分；它是原版综合项目，不保证单概念纯度。
