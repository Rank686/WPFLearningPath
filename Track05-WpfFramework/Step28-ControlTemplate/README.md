# Step 28：ControlTemplate

## 本步唯一新增

用 ControlTemplate 的 Border 与 ContentPresenter 重写 Button 的视觉结构，并用 TemplateBinding 传递已有属性。

## 运行后观察

自定义结构仍显示复合 Content，点击后普通 Click 处理器照常更新状态。

## 相比同轨上一步的改动

保留 BasedOn 继承，在派生 Style 中新增唯一一个 Template Setter。

## 已学并复用

Style、Setter、BasedOn、StaticResource、Button.Content、Click 与 x:Name。

## 固定脚手架

模板只含 Border 与 ContentPresenter；没有状态切换机制。

## 源码中保证不存在

Trigger、VisualStateManager、Validation.ErrorTemplate 与自定义控件。

## 完成后的综合练习

原版 ContentControlStyle 项目包含更多模板结构；完成第 35 步后再打开。
