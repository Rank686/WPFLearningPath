# Step 17：DataTemplate 与 ItemTemplate

## 本步唯一新增

用 `ItemsControl.ItemTemplate` 中的 `DataTemplate` 描述一个 WorkItem 应该由哪些界面元素组成。

## 运行后观察

集合中的每个 WorkItem 都得到相同结构：标题、分类和活动状态；增添新对象时也自动套用这份结构。

## 相比同轨上一步的改动

集合元素从 string 变成实现属性通知的 WorkItem；ItemsSource 仍指向同一个集合，只新增每项的显示模板。

## 已学并复用

ObservableCollection 负责行增删，INotifyPropertyChanged 负责单个对象属性变化，Binding 读取当前对象的三个属性。

## 固定脚手架

ItemsControl 还会在模板内容外为每一项准备一个外层承载对象；本步只需知道它存在，不学习其类型或 API。

## 源码中保证不存在

ICollectionView、模板选择器、Trigger、ContentControl 与选择同步。

## 完成后的综合练习

这个原版项目包含模板路线的扩展内容；完成第 23 步后再打开 `Data Binding/DataTemplatingIntro/DataTemplatingIntro.csproj`。
