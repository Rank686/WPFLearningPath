# Step 33：依赖属性有效值与本地值

## 先懂再跑

WPF 控件上的许多属性其实是**依赖属性**（Dependency Property）。每个 DP 有两面：

- 平时用的 CLR 包装：`ValueButton.Background`
- 身份令牌：`Control.BackgroundProperty`（给 `ReadLocalValue` / `ClearValue` 用）

同一属性可以有多层来源。本步只区分两层：

| 说法 | 看什么 | 含义 |
|---|---|---|
| **有效值** | `ValueButton.Background` | 最终真正用来绘制的值 |
| **本地值** | `ReadLocalValue(BackgroundProperty)` | 是否在元素自己身上直接赋过值 |

按钮的浅蓝来自 Style 的 `Setter`，**不是**本地值。所以初始时有效值是 `LightSkyBlue`，本地值却是 `none`（内部为 `DependencyProperty.UnsetValue`）。本地值优先级更高：设成橙色后会盖住 Style；`ClearValue` 删掉本地值后，Style 又重新成为有效值。

## 本步唯一新增

用 `ReadLocalValue` 查看本地 Background，并用 `ClearValue` 删除它，让 Style 值重新成为有效值。

## 运行后观察

初始：有效值浅蓝、本地值 `none` → 点 Set local orange：两边都是橙色 → 点 Clear local value：有效值回到浅蓝、本地值再变 `none`。

## 相比同轨上一步的改动

移除命令，回到已学 BasedOn Style，并只观察一个现有依赖属性的值来源。

## 已学并复用

命名 Style、BasedOn、StaticResource、x:Name 与 Click。

## 固定脚手架

`DependencyProperty.UnsetValue` 表示「没有本地值」，不是 Background 的实际显示色；显示色看有效值。

## 源码中保证不存在

`DependencyProperty.Register`、GetValue/SetValue 包装、metadata 与 coercion。

## 完成后的综合练习

RestoringDefaultValues 原版项目在完成第 35 步后解锁。
