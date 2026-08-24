# Step 31：MouseDown 路由事件冒泡

## 先懂再跑

### 路由事件是什么

普通事件：`TextBox` 的 `TextChanged` 只在这个控件自己身上触发。

**路由事件（Routed Event）**：事件会沿可视化树**向上或向下传递**。本步只学**冒泡（Bubble）**：从里往外传。

界面结构：

```text
Outer Border  (挂了 Outer_MouseDown)
  └─ Inner Border  (挂了 Inner_MouseDown)
       └─ TextBlock  (没挂处理器，但能被点到)
```

你点中间的文字时，WPF 不是只通知 `TextBlock`，而是让 `MouseDown` **从命中元素开始往外冒**：

```text
TextBlock → Inner Border → Outer Border → … → Window
```

所以即使 `TextBlock` 没写 `MouseDown`，**内外两层 Border 的处理器都会有机会执行**。

### 三个名字别搞混

日志里会出现 `sender`、`Source`、`OriginalSource`：

| 名字 | 含义 | 本步点击文字时 |
|---|---|---|
| **sender** | 当前正在执行的这个处理器挂在谁身上 | inner 行是 `InnerArea`，outer 行是 `OuterArea` |
| **Source** | 这次路由的**逻辑起点**（谁开始冒泡） | 通常是内层 `InnerArea` |
| **OriginalSource** | 鼠标**真正点到的最底层元素** | `TextBlock(LeafText)` |

记法：**OriginalSource = 鼠标点到谁；Source = 路由从哪开始往上冒；sender = 现在轮到谁在处理。**

### Handled 是干什么的

内层处理器里可以写：

```csharp
e.Handled = true;
```

意思是：**这个事件我处理完了，别再往上传了。**

- **不勾选** Stop at inner：inner 跑完 → outer 也跑 → 日志两行  
- **勾选** Stop at inner：inner 设 `Handled=true` → outer **不再执行** → 日志只有 inner

这和后面 Step 32 命令里的 `e.Handled = true` 是同一套「路由能不能继续」的心智模型。

### 本步没讲什么

- **隧道（Tunnel）**：从外往里的预览阶段（如 `PreviewMouseDown`），本步故意不讲  
- **命令**：Step 32 才学  
- 自定义路由事件注册：更后面的内容

## 本步唯一新增

观察 `MouseDown` 从内层 `Border` 冒泡到外层 `Border`，以及 `Handled` 如何停止普通外层处理器。

## 运行后观察

1. 点中间文字，看日志  
2. **不勾选** Stop at inner：先 `inner`，再 `outer`  
3. **勾选** Stop at inner：只有 `inner`，并出现 `inner set Handled=true`  
4. 注意 `OriginalSource` 始终是 `TextBlock`，`sender` 在 inner/outer 行里不同

## 相比同轨上一步的改动

移除 Style 与 Trigger，换成嵌套元素和两个事件处理器。

## 已学并复用

XAML 事件连接、x:Name、code-behind 与普通嵌套布局。

## 固定脚手架

本步只讲冒泡 `MouseDown`；不讲预览隧道阶段。

## 源码中保证不存在

`MouseLeftButtonDown`、`RegisterRoutedEvent`、class handler、`handledEventsToo` 与命令。

## 完成后的综合练习

两个原版 RoutedEvent 示例在完成第 35 步后解锁。
