# Step 18：ICollectionView 与 CurrentItem

## 本步唯一新增

用 `CollectionViewSource.GetDefaultView(Items)` 得到 ICollectionView，并通过它的 CurrentItem 与移动方法维护一个当前位置。

## 运行后观察

先观察 A：ItemsControl 绑定 ItemsView 后仍显示原集合的三项。再观察 B：点击 Previous/Next，下面的 Current item 文本沿视图移动。

## 相比同轨上一步的改动

WorkItem、ObservableCollection 与 DataTemplate 保持不变；ItemsSource 从 Items 改指 ItemsView，并增加当前位置按钮与文本。

## 已学并复用

集合变化通知、属性变化通知、DataTemplate、ItemsSource、x:Name 与 Click 处理器。

## 固定脚手架

默认视图由 WPF 为源集合建立；本步只操作它，不讨论选择控件、排序、筛选或分组。

## 源码中保证不存在

ListBox 选择、IsSynchronizedWithCurrentItem、ContentControl、排序、筛选、分组与编辑事务。

## 完成后的综合练习

本步是 API 聚焦项目，没有对应的原版综合示例。
