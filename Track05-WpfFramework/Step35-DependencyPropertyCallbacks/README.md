# Step 35：依赖属性回调与 coercion

## 先懂再跑

Step 34 只注册了 `Rating`，谁设值就存什么。本步给同一个 `RatingProperty` 加 **metadata（元数据）**，挂两个回调，让 WPF 在存值前后自动介入。

### 这个项目在干什么

`RatingBadge` 有一个分数 `Rating`，还有一个上限 `Maximum`（默认 5）。  
规则：**Rating 必须落在 0 到 Maximum 之间**。

当你写 `RatingBadge.Rating = 9` 时，并不是真的存 9，而是：

1. **coerce（强制修正）** 先把 9 改成 5（因为 Maximum=5）
2. **changed（值已变化）** 发现有效值从 3 变成了 5，才改背景色、写日志

界面下方日志框就是用来**看这两步谁先谁后、什么时候会跳过 changed**。

### 两个回调分别干什么

| 回调 | 注册名 | 什么时候跑 | 干什么 |
|---|---|---|---|
| **coerce** | `CoerceValueCallback` | 每次有人给 `Rating` 赋值时，**最先**跑 | 把请求值修正成合法值，例如 9→5、-1→0 |
| **changed** | `PropertyChangedCallback` | coerce 之后，**只有有效值真的变了**才跑 | 响应新值，例如 Rating≥4 时背景变绿 |

它们放一起说，是因为这是 **同一条赋值流水线**：

```text
Rating = 9
  → 1. coerce：requested 9, return 5
  → 2. changed：3 -> 5
```

如果当前已经是 5，再请求 9：

```text
Rating = 9
  → 1. coerce：requested 9, return 5   （还是 5）
  → （没有 changed，因为有效值没变）
```

### 三个按钮分别试什么

1. **Set Rating 4**  
   coerce 4→4，changed 3→4，背景变绿。

2. **Request Rating 9**  
   coerce 9→5，changed 到 5。再点一次：只有 coerce，没有 changed（说明 changed 不是“每次赋值都跑”，而是“有效值变了才跑”）。

3. **Prepare 5, lower Maximum to 3**  
   先把 Rating 设成 5，再把 Maximum 从 5 降到 3。  
   `Maximum` 是普通 CLR 属性，改它不会自动重算 Rating，所以代码里手动调了 `CoerceValue(RatingProperty)`，coerce 把 5 压成 3。

### 和 Step 34 的差别

Step 34：`Register` 三参数，改 Rating 就原样存。  
Step 35：同样还是 `RatingProperty` + Get/Set，只是 Register 时多传了 `FrameworkPropertyMetadata`，里面带上 **changed + coerce** 两个回调。

## 本步唯一新增

为 `RatingProperty` 添加 `FrameworkPropertyMetadata`：coerce 限制有效值范围，changed 在有效值变化时更新背景并写日志。

## 运行后观察

- Set 4：日志两行，`1. coerce` 在前，`2. changed` 在后  
- 连续 Request 9：第一次两行；第二次只有 `1. coerce`  
- Lower Maximum：Rating 从 5 被 coerce 成 3

## 相比同轨上一步的改动

保留相同 DP 与 CLR wrapper，只给 Register 添加 metadata，并用日志暴露真实执行顺序。

## 已学并复用

`DependencyProperty.Register`、GetValue/SetValue、ElementName Binding、x:Name 与 Click。

## 固定脚手架

`Maximum` 是普通属性；它变化后必须显式调用 `CoerceValue(RatingProperty)`，才会重新裁剪 Rating。

## 源码中保证不存在

AddOwner、OverrideMetadata、附加属性、DefaultStyleKey、Generic.xaml 与复杂控件主题。

## 完成后的综合练习

现在可以打开 Properties/Callbacks，以及本轨前面列出的所有原版综合示例。
