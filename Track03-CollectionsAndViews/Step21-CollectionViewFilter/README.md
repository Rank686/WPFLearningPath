# Step 21：CollectionView 筛选

## 本步唯一新增

把一个稳定的 `FilterItem` 谓词赋给 `ItemsView.Filter`，再让谓词根据 `_onlyActive` 决定每个对象是否可见。

## 运行后观察

点击 Attach predicate 时，给 Filter 赋值本身就会刷新。之后勾选 Only active 只改变谓词捕获的条件，委托没有变化，所以处理器调用 Refresh；可见行数从 4 变 2。

## 相比同轨上一步的改动

保留排序按钮和主从区域，增加谓词、OnlyActive 条件、清除筛选动作与可见行计数。

## 已学并复用

ICollectionView、SortDescriptions、CurrentItem、DataTemplate、x:Name 与 Click 处理器。

## 固定脚手架

Clear filter 只把 Filter 设为 null；这次赋值同样会让视图更新，因此没有多余的 Refresh 调用。可见数通过普通 foreach 统计。

## 源码中保证不存在

GroupDescriptions、LINQ 计数、实时整形、集合编辑与校验。

## 完成后的综合练习

原版 `Data Binding/SortFilter/SortFilter.csproj` 同时组合多种视图操作；完成第 23 步后再打开。
