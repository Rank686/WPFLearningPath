# Step 11：Binding Mode

## 本步唯一新增

显式比较 Mode=OneWay 与 Mode=TwoWay，观察目标控件的修改是否写回普通源对象。

## 运行后观察

先勾选两个 CheckBox，再点 Inspect：OneWay 源仍为 False，TwoWay 源变为 True。

## 相比同轨上一步的改动

Profile 改为普通 bool 属性；主界面改成两个独立 DataContext 和一个已学过的 Click 检查按钮。

## 已学并复用

DataContext、Binding、StackPanel、x:Name 与 XAML Click 处理器。

## 固定脚手架

App、StartupUri、Window、x:Class、必要 xmlns、partial 与 InitializeComponent。

## 源码中保证不存在

UpdateSourceTrigger、INotifyPropertyChanged、Binding 事件、Validation。

## 完成后的综合练习

完成 Step14 后再打开 `Data Binding/DirectionalBinding/DirectionalBinding.csproj` 的 Mode 部分；它是原版综合项目，不保证单概念纯度。
