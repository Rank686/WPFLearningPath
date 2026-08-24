# Step 15：ItemsControl 与 ItemsSource

## 本步唯一新增

把普通 `List<string>` 通过 `ItemsControl.ItemsSource` 交给界面，让一个控件依次显示集合里的每个元素。

## 运行后观察

窗口显示三个名字。`ItemsControl` 负责重复显示数据，但它本身不提供“当前选中了谁”的交互。

## 相比同轨上一步的改动

这是集合轨的重置步骤，不复制绑定轨的转换器界面；只保留已经学过的窗口、布局、DataContext 与 Binding。

## 已学并复用

Window、StackPanel、DataContext，以及只写 Path 的 Binding。

## 固定脚手架

App、StartupUri、Window、x:Class、必要 xmlns、partial 与 InitializeComponent。

## 源码中保证不存在

集合变化通知、DataTemplate、列表选择、ICollectionView 与校验。

## 完成后的综合练习

本步没有原版综合项目；先把“集合对象”和“显示集合的控件”分清，再进入下一步。
