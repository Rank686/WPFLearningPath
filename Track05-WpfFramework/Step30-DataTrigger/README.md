# Step 30：DataTrigger

## 本步唯一新增

一个命名 Border Style 用 DataTrigger 监听命名 CheckBox.IsChecked，并切换两个 Setter。

## 运行后观察

勾选时预览背景和边框一起变色，取消后恢复 Style 的默认 Setter。

## 相比同轨上一步的改动

移除校验与模板实验，只保留 Style、ElementName Binding 与一个数据条件。

## 已学并复用

命名 Style、Setter、StaticResource、x:Name、ElementName 与 Binding.Path。

## 固定脚手架

HighlightStyle 必须显式应用；本步没有隐式 Style。

## 源码中保证不存在

ControlTemplate、MultiDataTrigger、EventTrigger、动画、选择器与 VisualStateManager。

## 完成后的综合练习

DataTemplatingIntro 原版触发器部分在完成第 35 步后解锁。
