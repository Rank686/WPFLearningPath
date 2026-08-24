# Step 44：可校验工作项编辑器

## 本项目巩固

在集合视图中组合 AddNew 事务、行级 BindingGroup、显式源更新、字段规则与进度跨字段规则。

## 运行后观察

非法临时行无法提交，修正后可进入集合，取消会删除临时行。

## 相比同轨上一步的改动

保留集合视图，再把 AddNew 事务、显式源更新、字段校验和跨字段 BindingGroup 校验合并到行内编辑。

## 已学并复用

ObservableCollection、ICollectionView、当前项、视图整形、IEditableCollectionView、Explicit Binding、ValidationRule、ItemBindingGroup 与 Validation ErrorTemplate。

## 固定脚手架

App 只指定启动窗口；窗口保存默认可编辑视图，每个 ListBoxItem 独立拥有 BindingGroup 和行内编辑器。

## 源码中保证不存在

RelativeSource、ItemContainerStyle、DataTemplateSelector、ObjectDataProvider 与 MultiBinding。

## 完成后的综合练习

新建一行，依次尝试空标题、负数估算和超出估算的完成量，修正后保存，再新建并取消一行。
