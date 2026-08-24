# Step 29：Validation.ErrorTemplate

## 本步唯一新增

为 TextBox 指定错误 ControlTemplate，并从命名 AdornedElementPlaceholder 读取第一条 Validation.Errors。

## 运行后观察

字母或 10 会在输入框旁显示具体错误，30 会同时移除装饰与消息。

## 相比同轨上一步的改动

复用 ControlTemplate 结构与已学 ValidationRule，当前焦点改为错误呈现。

## 已学并复用

ControlTemplate、ElementName Binding、ValidationRule、DataContext、StaticResource 与 UpdateSourceTrigger。

## 固定脚手架

AdornedElementPlaceholder 把原 TextBox 放回错误模板；没有改变校验规则本身。

## 源码中保证不存在

DataTrigger、Validation.Error 路由事件、BindingGroup 与 RelativeSource。

## 完成后的综合练习

BindValidation 原版自定义错误部分在完成第 35 步后解锁。
