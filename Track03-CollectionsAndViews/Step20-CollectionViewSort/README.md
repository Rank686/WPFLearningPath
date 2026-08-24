# Step 20：CollectionView 排序

## 本步唯一新增

通过 `ItemsView.SortDescriptions` 添加或清除一个按 Title 升序的 SortDescription。

## 运行后观察

点击 Sort by title，ListBox 显示顺序改变；点击 Clear sort，又回到 ObservableCollection 原来的 Write、Review、Run 顺序。

## 相比同轨上一步的改动

主从界面和 CurrentItem 同步保持不变，只增加排序与清除排序两个按钮。

## 已学并复用

ICollectionView、ListBox 主从同步、DataTemplate、ObservableCollection 与 Click 处理器。

## 固定脚手架

SortDescription 描述视图需要怎样比较某个属性；它不会移动源集合里的对象。

## 源码中保证不存在

CustomSort、Filter、GroupDescriptions、集合编辑与校验。

## 完成后的综合练习

原版 `Data Binding/SortFilter/SortFilter.csproj` 同时包含筛选；完成第 23 步后再打开。
