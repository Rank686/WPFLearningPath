# Step 25：BindingGroup

## 本步唯一新增

让一个面板拥有 BindingGroup，并用 `PriceOrderRule` 在 ConvertedProposedValue 阶段同时比较 StartPrice 与 BuyNowPrice。

## 运行后观察

Start 50、Buy now 40 时 CommitEdit 失败并显示明确的价格顺序消息；改为 60 后再次保存，两个值一起写入 Offer。

## 相比同轨上一步的改动

单个 Price 变成 Offer 的两个价格；保留每个字段的 PriceRule，再增加只负责跨字段关系的组规则与 Save。

## 已学并复用

ValidationRule、RawProposedValue、TwoWay Binding、DataContext、x:Name 与 Click。

## 固定脚手架

PriceOrderRule 把 Validate 的 value 转成 BindingGroup，再对 group.Items[0] 调用 TryGetValue 取得两份已转换但尚未提交的 decimal。

## 源码中保证不存在

ItemsControl、ItemBindingGroup、IEditableObject、ControlTemplate 与 Validation.ErrorTemplate。

## 完成后的综合练习

原版 `Data Binding/ValidateItemSample/ValidateItemSample.csproj` 会在完成第 26 步后解锁。
