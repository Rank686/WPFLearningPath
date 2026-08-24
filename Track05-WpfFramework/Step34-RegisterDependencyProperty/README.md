# Step 34：注册自定义 DependencyProperty

## 先懂再跑

Step 33 用的是框架自带的 `BackgroundProperty`。本步自己造一个：在 `RatingBadge` 上注册 `Rating`。

注册依赖属性通常三件套：

1. **静态令牌** `RatingProperty`：`DependencyProperty.Register(名字, 类型, 所有者类型)`
2. **CLR 包装** `Rating`：`get`/`set` 只转发 `GetValue` / `SetValue`，不自己存字段
3. **所有者** 必须是 `DependencyObject` 子类（这里 `RatingBadge : Border`）

为什么要 DP，而不是普通 `int Rating { get; set; }`？  
因为 WPF 的 Binding、Style、动画等认的是依赖属性值系统。本步用 ElementName Binding 绑到 `Rating`：点击后 `Rating++` 走 `SetValue`，界面立刻更新——**没有**实现 `INotifyPropertyChanged`。变化通知来自 DP 本身。

本步用最简三参数 `Register`，不带默认值元数据、不带 PropertyChanged 回调（那是下一步）。

## 本步唯一新增

`RatingBadge` 用三参数 `DependencyProperty.Register` 注册 `int RatingProperty`，CLR 属性只转发 `GetValue`/`SetValue`。

## 运行后观察

初始 Rating 为 3；点 Increase rating，徽章内 Binding 文本立刻变成新数字；`RatingBadge` 没有 INPC。

## 相比同轨上一步的改动

从读取已有 DP 值来源，推进到声明一个最小自定义 DP。

## 已学并复用

DependencyObject 值系统、ElementName Binding、x:Name 与 Click。

## 固定脚手架

`RatingBadge` 继承 `Border` 只为直接显示内容；它不是带主题文件的完整自定义控件。

## 源码中保证不存在

`PropertyMetadata`、`PropertyChangedCallback`、`CoerceValueCallback`、`AddOwner`、`OverrideMetadata` 与 `Generic.xaml`。

## 完成后的综合练习

CustomClassesWithDP 原版项目在完成第 35 步后解锁。
