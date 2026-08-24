# Step 36：Application 作用域与生命周期

## 先懂再跑

WPF 程序不只是一扇 `Window`，外面还有一层 **`Application`** 管全局：谁启动、共享什么资源、关哪扇窗时进程退出。

### 这个项目想让你明白什么

**1. Application 管整个程序，不只是一扇窗**

本步不用 `StartupUri`，而是在 `App.xaml.cs` 的 `OnStartup` 里手写：

```csharp
var window = new MainWindow();
MainWindow = window;
window.Show();
```

意思是：程序入口在 `Application`，由它决定先开哪扇窗、哪扇是主窗口。

**2. Application 级资源，所有窗口都能用**

`AppAccentBrush` 写在 `Application.Resources` 里。主窗口按钮和工具窗口边框都用 `{StaticResource AppAccentBrush}`，两扇窗共享同一个蓝色，不必各自再定义一遍。这比单窗 `Window.Resources` 更高一层，适合放全局主题色、转换器、样式等。

**3. 关主窗口 = 整个程序退出**

`ShutdownMode="OnMainWindowClose"`。打开 Tool window 后，再关 Main window，两扇窗会一起消失。说明生命周期由 Application 管：主窗口关了，进程就结束，工具窗还开着也保不住程序。

### 和 `StartupUri="MainWindow.xaml"` 有什么区别

两种写法都能启动主窗口，用户第一眼差不多；差别在**谁创建主窗口、启动前能不能插手**。

| | `StartupUri="MainWindow.xaml"` | 本步：`OnStartup` 手写 |
|---|---|---|
| 写法 | XAML 一行声明 | `OnStartup` 里 `new` + `Show` |
| 谁创建主窗口 | 框架自动 | 你自己 |
| `MainWindow` 属性 | 框架自动设置 | 需要 `MainWindow = window` |
| 启动前插逻辑 | 很难（传参、登录、读配置等） | 可以，在 `Show()` 之前写 |
| 适合 | 小 demo、最简起步 | 真实项目、需要启动流程时 |

```xml
<!-- StartupUri：框架替你做完 -->
<Application StartupUri="MainWindow.xaml" />
```

```csharp
// OnStartup：你自己控制创建过程
protected override void OnStartup(StartupEventArgs e)
{
    base.OnStartup(e);
    var window = new MainWindow();
    MainWindow = window;
    window.Show();
}
```

本步故意不用 `StartupUri`，是为了把「App 创建主窗 → 指定 MainWindow → Show」这条链路写清楚。小项目用 `StartupUri` 完全没问题；需要启动前逻辑时，就换成这种写法。

## 本步唯一新增

`Application` 明确创建主窗口，保存两个窗口都能访问的资源，并决定关闭哪个窗口时退出进程。

## 运行后观察

1. 点 Open tool window：弹出第二扇窗，边框也是蓝色（同一 `AppAccentBrush`）
2. 不关工具窗，直接关主窗口：两扇窗一起消失，程序退出

## 相比同轨上一步的改动

这是新轨起点，从空白最小外壳重建，没有复制 Step 35 的模板、校验或依赖属性演示。

## 已学并复用

XAML 外壳、StackPanel、StaticResource 与普通 Click 事件。

## 固定脚手架

`InitializeComponent` 和 Window 的 code-behind 仍是项目启动所需的固定结构。

## 源码中保证不存在

数据绑定、数据上下文、属性变化通知、视图模型、命令、依赖注入与导航。

## 完成后的综合练习

ApplicationShutdown 与 ApplicationResources 原版示例会在完成本轨后解锁。
