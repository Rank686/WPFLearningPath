# Step 39：个人资料 Binding 闭环

## 本项目巩固

把 DataContext、双向 Binding、即时源更新与属性变化通知组合为可观察的资料编辑闭环。

## 运行后观察

输入姓名或城市时，摘要无需失焦就同步变化。

## 相比同轨上一步的改动

从空白巩固轨起步，把 DataContext、TwoWay、PropertyChanged 触发和 INPC 串成闭环。

## 已学并复用

XAML 外壳、StackPanel、Binding、DataContext、TwoWay、UpdateSourceTrigger、INotifyPropertyChanged 与 ViewModel。

## 固定脚手架

App 只指定启动窗口；窗口构造后创建资料 ViewModel。

## 源码中保证不存在

具名资源、转换器、集合控件、命令与第三方 MVVM 框架。

## 完成后的综合练习

把姓名或城市改成自己的资料，观察摘要在每次输入后更新。
