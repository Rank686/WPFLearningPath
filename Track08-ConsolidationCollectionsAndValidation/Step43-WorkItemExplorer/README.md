# Step 43：工作项视图浏览器

## 本项目巩固

在工作项集合上保存默认 ICollectionView，并组合当前项、主从展示、排序、筛选与分组。

## 运行后观察

选择、排序、筛选和分组共享同一个 ICollectionView，详情始终跟随 CurrentItem。

## 相比同轨上一步的改动

保留原集合，加入默认集合视图、当前项与三种视图整形。

## 已学并复用

ObservableCollection、工作项属性通知、ItemsSource、DataTemplate、默认集合视图、CurrentItem、主从 Binding、SortDescription、Filter 与 GroupDescription。

## 固定脚手架

App 只指定启动窗口；窗口公开原集合和唯一默认视图，所有浏览与整形操作都作用于该视图。

## 源码中保证不存在

集合编辑事务、ValidationRule、BindingGroup 与 ItemBindingGroup。

## 完成后的综合练习

先排序，再只看未完成项，恢复全部项后分组，比较视图顺序与原集合顺序。
