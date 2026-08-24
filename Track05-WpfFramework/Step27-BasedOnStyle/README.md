# Step 27：Style.BasedOn

## 本步唯一新增

两个命名 Button Style 通过 `BasedOn` 继承同一个命名基础 Style。

## 运行后观察

两个按钮共享基础 Padding、Margin、FontSize，但分别追加不同背景与前景色。

## 相比同轨上一步的改动

这是框架机制轨的重置步骤，只复用已学的资源、Style 与 Setter。

## 已学并复用

Window.Resources、x:Key、StaticResource、TargetType、Setter 与 StackPanel。

## 固定脚手架

所有 Button 都显式写 Style；本步没有隐式 Style。

## 源码中保证不存在

ControlTemplate、Trigger、Validation.ErrorTemplate、命令与依赖属性 API。

## 完成后的综合练习

原版 StylingAndTemplating 项目包含后续模板机制；完成第 35 步后再打开。
