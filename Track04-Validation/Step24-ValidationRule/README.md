# Step 24：ValidationRule

## 本步唯一新增

实现 `PriceRule : ValidationRule`，在 RawProposedValue 阶段检查 TextBox 原始文本能否解析为非负 decimal。

## 运行后观察

输入字母或负数时出现 WPF 默认红色错误边框，源 Price 保留上一次有效值；输入 25 后红框消失并可读到新值。

## 相比同轨上一步的改动

这是校验轨的重置步骤，不复制集合视图与编辑事务；只保留单对象、单属性和一个 TwoWay Binding。

## 已学并复用

DataContext、TwoWay、UpdateSourceTrigger=PropertyChanged、属性元素式 Binding、x:Name 与 Click。

## 固定脚手架

ValidationRule 必须返回 ValidationResult；本步完全使用 WPF 默认错误外观，不读取错误集合。

## 源码中保证不存在

BindingGroup、ItemBindingGroup、ControlTemplate、Validation.ErrorTemplate、Trigger 与 IDataErrorInfo。

## 完成后的综合练习

原版 `Data Binding/BindValidation/BindValidation.csproj` 包含更多错误展示方式；完成第 26 步后再打开。
