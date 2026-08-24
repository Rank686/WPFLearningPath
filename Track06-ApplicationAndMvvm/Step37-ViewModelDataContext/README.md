# Step 37：ViewModel 与 DataContext

## 先懂再跑

### ViewModel 是干什么的

ViewModel 是给界面用的 **「状态 + 展示规则 +（后面会学的）动作入口」**，不负责界面长什么样。

| 层 | 管什么 | 本步例子 |
|---|---|---|
| **View** | 界面怎么摆、什么样式 | `TextBox`、`TextBlock`、按钮布局 |
| **ViewModel** | 界面显示什么、怎么变 | `Name`、`Greeting`、属性变化通知 |
| **Model** | 业务数据与核心规则 | 本步还没有 |

`MainWindowViewModel` 在本步只做三件事：

1. **存展示状态**：`Name`（用户输入的名字）
2. **算展示文案**：`Greeting`（由 `Name` 推导，只读）
3. **通知 Binding 刷新**：实现 `INotifyPropertyChanged`，`Name` 一变就通知 `Name` 和 `Greeting`

它**不负责**：控件样式、窗口怎么开、按钮颜色——这些仍在 View / Application 资源里。

### DataContext 绑在哪

XAML 里没有写 `DataContext`，是在 **code-behind** 里接线的：

```csharp
DataContext = new MainWindowViewModel();
```

之后子控件里的 `{Binding Name}`、`{Binding Greeting}` 都会默认从窗口的 `DataContext` 上找属性。不是「在 XAML 里再绑一次 DataContext」，而是**先给 Window 挂上数据源，Binding 自动用它**。

### 为什么 ViewModel 用 INPC，不用 DP

同文件里还有一个对照类 `MainWindowViewModelDp`（继承 `DependencyObject`，用 `DependencyProperty` 通知 Binding）。把 `DataContext` 换成 `new MainWindowViewModelDp()` 时，界面效果一样。

但真实项目里 ViewModel 更常见 **INotifyPropertyChanged**，原因：

| | INPC（ViewModel 常见） | DP（控件常见） |
|---|---|---|
| 依赖 | `System.ComponentModel`，.NET 通用 | `System.Windows`，绑在 WPF 上 |
| 适用对象 | ViewModel、可绑定的 Model | `Button`、`Border`、自定义控件 |
| 代码量 | 少（尤其配合源生成器） | 多（Register + Get/Set 转发） |
| 单元测试 | 普通 C# 对象，好测 | `DependencyObject` 有 UI 线程亲和，别扭 |
| Style/动画/coercion | ViewModel 不需要 | 控件常常需要 |

核心原因：**ViewModel 理想上是「不依赖 WPF 的展示状态对象」**；DP 是为可视化树里的控件设计的。INPC 只解决 Binding 需要的一件事——属性变了请刷新；这就够了。

记法：

- **控件属性** → 往往用 DP（Step 34 的 `RatingBadge.Rating`）
- **ViewModel 属性** → 用 INPC（本步的 `MainWindowViewModel.Name`）

`MainWindowViewModelDp` 只是教学对照，说明 Binding 刷新不一定非要 INPC；日常写 ViewModel 仍优先 INPC。

### ViewModel 通常负责什么 / 不负责什么

**通常负责：**

- 界面要读写的数据（`Name`、是否加载中、错误提示……）
- 展示逻辑（问候语怎么拼、按钮能不能点——Step 38 的 Save 会学）
- 通过 `INotifyPropertyChanged` 告诉 Binding「我变了」

**通常不负责：**

- UI 细节（颜色、Margin、用什么控件）
- 直接操作控件（`textBox.Text = ...`、`FindName`）
- 纯视觉 / 框架动作（本步的「开工具窗」暂留 View）
- 核心业务规则（理想情况下放 Model，ViewModel 只翻译给 UI）

判断心法：问三句——

1. 这是**显示/交互状态**吗？→ 多半进 ViewModel  
2. 这是**界面怎么画**吗？→ 留 View  
3. 这是**业务真相**吗？→ 进 Model，ViewModel 引用它

### Click 事件放哪里

MVVM 不是禁止 `Click`，而是按职责分流：

| 点击在干什么 | 放哪里 | 本轨例子 |
|---|---|---|
| 改 ViewModel 状态 / 展示规则 | **ViewModel**（Step 38 用 `Command`） | Save → `SaveCommand` |
| 纯 UI / 框架动作 | **View**（code-behind 的 `Click`） | Open tool window |
| 改绑定属性 | **不用 Click** | 输入框改 `Name`，Binding 自己同步 |

本步的 `OpenToolWindow_Click` 故意留在 `MainWindow`：它只是 `new ToolWindow().Show()`，不改 `Name`/`Greeting`，属于开窗口这种 UI 动作。

实用判断：

- **「如果换种界面（菜单、快捷键），这个逻辑还要不要、变不变？」**  
  要且一样 → ViewModel（下一步用 Command）  
  强依赖 Window/控件 → 可以留 View

- **「Click 里是在改 Binding 的属性吗？」**  
  是 → 该进 ViewModel；否 → 可以留 View

记法：**跟状态/规则有关的点击 → Command 进 ViewModel；跟界面框架有关的 → Click 留 View。**

## 本步唯一新增

`MainWindowViewModel` 保存 `Name` 和 `Greeting`；窗口只负责把它放进 `DataContext`。

## 运行后观察

在文本框逐字输入时，`Greeting` 逐字更新，不需要窗口里的文本变化事件。

## 相比同轨上一步的改动

保留应用启动、退出和共享资源，只增加 ViewModel、一次 `DataContext` 连接与两个 Binding。

## 已学并复用

Binding、`UpdateSourceTrigger=PropertyChanged`、`INotifyPropertyChanged` 和 Application 作用域。

## 固定脚手架

窗口仍有打开工具窗口的普通 `Click`；它属于上一课的可见演示，不处理姓名状态。

## 源码中保证不存在

命令接口、RelayCommand、ViewModelLocator、服务、异步操作、依赖注入与导航。

## 完成后的综合练习

下一步只加入按钮命令，再统一打开原版 MVVM 示例。
