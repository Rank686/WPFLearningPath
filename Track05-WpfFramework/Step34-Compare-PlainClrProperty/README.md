# Step 34 Compare：INotifyPropertyChanged 对照

## 用途

与 `Step34-RegisterDependencyProperty` 并排对照。**界面和操作完全相同**，点 Increase rating 后 Binding 都会立刻刷新；差别只在 `Rating` 的实现方式。

## 运行后观察

与 Step 34 一样：初始 Rating 为 3，点击后徽章内数字立刻变成 4、5……

## 实现对比

| | Step 34 | 本对照项目 |
|---|---|---|
| 通知机制 | `DependencyProperty.Register` + `SetValue` | `INotifyPropertyChanged` + `PropertyChanged` |
| 属性写法 | 静态 `RatingProperty` + Get/Set 转发 | 私有字段 + CLR 属性 setter 里 `OnPropertyChanged()` |
| Binding 刷新 | DP 值系统自带 | 靠 `PropertyChanged` 事件 |
| WPF 生态 | 还能被 Style/动画等 DP 机制使用 | 主要服务 Binding，不是完整 DP 替代品 |

## 结论

要达到同样的 Binding 刷新效果，可以走 DP，也可以走 INPC。WPF 自定义控件更常见的是注册 DP，因为那是框架原生值系统；ViewModel 层则更常见 INPC（Step 37 会专门学）。
