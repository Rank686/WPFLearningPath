# Step 47：MVVM 评分工作区

## 本项目巩固

用显式 INotifyPropertyChanged 和 RelayCommand 统一评分状态、保存状态与界面反馈，同时保留可双向绑定的 RatingBadge 依赖属性。

## 运行后观察

评分为 0 时保存禁用；评分变化同时到达 ViewModel 和 RatingBadge；保存信息由命令更新。

## 相比同轨上一步的改动

保留多窗口与自定义依赖属性，再用 ViewModel、INPC 和 RelayCommand 收束数据与操作。

## 已学并复用

Application 作用域、RatingBadge、双向 Binding、属性变化通知、DataContext、RoutedCommand、显式 RelayCommand 与 CanExecute 状态刷新。

## 固定脚手架

App 继续显式创建 MainWindow；窗口创建 ViewModel；Slider 与 RatingBadge 都显式 TwoWay 绑定 Rating；保存按钮绑定 ViewModel 命令。

## 源码中保证不存在

RelativeSource、隐式 Style、CallerMemberName、第三方 MVVM 包、异步命令与线程操作。

## 完成后的综合练习

用 Slider 和 Increase 改变评分，重置后确认保存禁用，再设置评分并保存，观察命令消息更新到界面。
