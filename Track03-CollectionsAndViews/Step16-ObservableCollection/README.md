# Step 16：ObservableCollection

## 本步唯一新增

把普通 List 换成 `ObservableCollection<string>`。它在增加或删除元素时发送集合变化通知。

## 运行后观察

点击 Add name 或 Remove last，ItemsControl 的行数立即变化；代码从未重新设置 ItemsSource。

## 相比同轨上一步的改动

ItemsControl 与 Binding 保持不变，只替换集合类型并增加两个已经学过的 Click 处理器。

## 已学并复用

DataContext、ItemsControl、ItemsSource、XAML Click 与 code-behind 事件处理器。

## 固定脚手架

App、StartupUri、Window、x:Class、必要 xmlns、partial 与 InitializeComponent。

## 源码中保证不存在

DataTemplate、ICollectionView、当前项、排序、筛选与分组。

## 完成后的综合练习

这个原版项目还混有本轨后续语法；完成第 23 步后再打开 `Data Binding/CompositeCollections/CompositeCollections.csproj`。
