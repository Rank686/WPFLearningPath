# Step 08：Binding、ElementName 与 Path

## 本步唯一新增

使用 Binding 的 ElementName 找到另一个界面元素，再用 Path=Text 读取它的属性。

## 运行后观察

在 InputBox 中输入时，下方 TextBlock 立即显示相同文字；这里的数据源就是另一个控件。

## 相比同轨上一步的改动

这是 Binding 轨道的全新最小基线，不携带上一轨的事件、资源和 Style 演示。

## 已学并复用

Window、StackPanel、基本布局属性与 x:Name。

## 固定脚手架

App、StartupUri、Window、x:Class、必要 xmlns、partial 与 InitializeComponent。

## 源码中保证不存在

显式 Source、DataContext、Mode、UpdateSourceTrigger、INotifyPropertyChanged、converter。

## 完成后的综合练习

完成 Step14 后再打开 `Data Binding/BindingDPToDP/BindingDPToDP.csproj`；它是原版综合项目，不保证单概念纯度。
