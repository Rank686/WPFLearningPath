# Step 22：CollectionView 分组

## 本步唯一新增

向 `ItemsView.GroupDescriptions` 添加一个按 WorkItem.Category 分组的 PropertyGroupDescription，并用已学 DataTemplate 显示组名。

## 运行后观察

点击 Group by category，列表出现 Learning 与 Writing 两个组标题；对象仍是原集合中的对象。

## 相比同轨上一步的改动

保留筛选、排序和主从界面，新增分组/清除分组按钮以及 ListBox.GroupStyle 的组标题模板。

## 已学并复用

ICollectionView、Filter、SortDescriptions、DataTemplate、ItemsSource、CurrentItem 与 Click 处理器。

## 固定脚手架

分组动作按顺序清除 Filter、SortDescriptions 和旧 GroupDescriptions，再添加唯一一层 Category 分组，避免结果相互干扰。

## 源码中保证不存在

多级分组、GroupStyleSelector、集合编辑与校验。

## 完成后的综合练习

原版 `Data Binding/Grouping/Grouping.csproj` 含更多组合写法；完成第 23 步后再打开。
