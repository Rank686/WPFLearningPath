# Step 10：DataContext 与继承

## 本步唯一新增

把 Profile 放进 StackPanel.DataContext；后代控件的 Binding 不再重复写 Source，只写属性路径。

## 运行后观察

TextBlock 与 TextBox 都显示“Grace Hopper”，因为它们从同一个父 StackPanel 继承 DataContext。

## 相比同轨上一步的改动

移除 Window.Resources 中的显式资源对象和每条 Binding 的 Source；Profile 改放在 StackPanel.DataContext。

## 已学并复用

普通 CLR Profile、Binding、Path 与 StackPanel。

## 固定脚手架

App、StartupUri、Window、x:Class、必要 xmlns、partial 与 InitializeComponent。

## 源码中保证不存在

嵌套 DataContext 覆盖理论、RelativeSource、显式 Mode、INotifyPropertyChanged。

## 完成后的综合练习

完成 Step14 后再打开 `Data Binding/CodeOnlyBinding/CodeOnlyBinding.csproj` 的相关部分；它是原版综合项目，不保证单概念纯度。
