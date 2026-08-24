# Step 19：ListBox 与 ContentControl 主从联动

## 本步唯一新增

让 ListBox 通过 `IsSynchronizedWithCurrentItem="True"` 把选中项同步为 ItemsView.CurrentItem，再让 ContentControl 用 `ItemsView/` 读取该项。

## 运行后观察

切换左侧 ListBox 选中行，右侧详情立即换成同一个 WorkItem；两个控件没有互相调用。

## 相比同轨上一步的改动

移除 Previous/Next 按钮；把 ItemsControl 换成可选择的 ListBox，并增加读取视图当前项的 ContentControl。

## 已学并复用

ICollectionView.CurrentItem、ItemsSource、DataTemplate、StaticResource、Binding 与属性变化通知。

## 固定脚手架

ListBox 继承自 ItemsControl 并额外提供选择；两个控件之所以联动，是因为它们共享同一个 ItemsView。

## 源码中保证不存在

排序、筛选、分组、集合编辑与 DataTemplateSelector。

## 完成后的综合练习

原版 `CollectionBinding` 与 `MasterDetail` 项目还混有本轨后续语法；完成第 23 步后再打开。
