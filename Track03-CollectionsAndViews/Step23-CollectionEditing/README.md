# Step 23：IEditableCollectionView 新增事务

## 本步唯一新增

把 ItemsView 转成 `IEditableCollectionView`，用 AddNew、CommitNew、CancelNew 建立一个可提交或撤销的临时新增流程。

## 运行后观察

点击 Begin new 后列表出现临时项，右侧编辑器绑定 AddNew 返回的同一个对象。Commit 保留它；重新 Begin 后点 Cancel，则临时项从集合中消失。

## 相比同轨上一步的改动

保留筛选、排序、分组和主从界面，增加内嵌编辑器与 Begin/Commit/Cancel 三个动作。

## 已学并复用

ObservableCollection、ICollectionView、CurrentItem、视图整形、DataTemplate、DataContext、Binding 与属性通知。

## 固定脚手架

WorkItem 明确提供 public 无参构造函数，因此视图可以创建新实例。Begin 先清除 Filter、SortDescriptions 与 GroupDescriptions；Commit 和 Cancel 后都把 Editor.DataContext 清空。

## 源码中保证不存在

IEditableObject、EditItem、ValidationRule、BindingGroup、ObjectDataProvider 与模态对话框。

## 完成后的综合练习

现在可以打开 `Data Binding/EditingCollections/EditingCollections.csproj`，以及本轨前面列出的集合综合示例。
