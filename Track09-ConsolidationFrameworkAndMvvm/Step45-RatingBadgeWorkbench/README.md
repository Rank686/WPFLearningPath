# Step 45：RatingBadge 框架工作台

## 本项目巩固

在一个可交互的 RatingBadge 中组合显式 BasedOn Style、ControlTemplate、DataTrigger、RoutedCommand 和带回调的自定义依赖属性。

## 运行后观察

Increase 命令在 5 分时禁用，越界值被压回范围，模板外观随勾选状态变化。

## 相比同轨上一步的改动

从空白巩固轨起步，把显式 Style、模板、DataTrigger、RoutedCommand 和自定义依赖属性放进一个控件工作台。

## 已学并复用

StackPanel、XAML Click、具名元素代码事件订阅、StaticResource、BasedOn Style、ControlTemplate、TemplateBinding、DataTrigger、RoutedCommand 与依赖属性回调。

## 固定脚手架

App 使用 StartupUri；窗口资源只保存显式键控样式；RatingBadge 继承 ContentControl，并通过 CLR wrapper 暴露 Rating。

## 源码中保证不存在

Application 级资源、ViewModel、RelayCommand、RelativeSource 与隐式 Style。

## 完成后的综合练习

连续提高评分直到按钮禁用，重置评分，再勾选和取消高亮，观察模板边框、背景与状态文字变化。
