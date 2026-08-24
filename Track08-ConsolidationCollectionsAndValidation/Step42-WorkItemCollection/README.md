# Step 42：工作项集合

## 本项目巩固

把 ObservableCollection 的结构通知、工作项的属性通知和行内 DataTemplate 组合成可增删改的列表。

## 运行后观察

添加或删除会改变列表数量；更新选中项只改变对应行的文字。

## 相比同轨上一步的改动

从空白巩固轨起步，同时演示集合结构通知和集合项属性通知。

## 已学并复用

XAML 外壳、StackPanel、两种事件连接方式、DataContext、ItemsSource、ObservableCollection、INotifyPropertyChanged 与 DataTemplate。

## 固定脚手架

App 只指定启动窗口；窗口拥有集合并把集合设为 DataContext，工作项负责发出属性变化通知。

## 源码中保证不存在

集合视图、当前项、集合编辑事务、ValidationRule 与 BindingGroup。

## 完成后的综合练习

添加两个工作项，分别更新其中一项并删除另一项，观察列表行与集合数量如何独立响应。
