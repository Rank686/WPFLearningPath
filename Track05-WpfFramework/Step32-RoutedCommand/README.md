# Step 32：RoutedCommand

## 先懂再跑

### 为什么要有 RoutedCommand

Step 31 学了：**事件会沿树路由，可以用 `Handled` 截断。**

普通 `Click` 的问题：「能不能点」和「点了干什么」容易揉在一个处理器里，还要自己写 `button.IsEnabled = ...`。

**RoutedCommand** 把两件事拆开：

| | 普通 Click | RoutedCommand |
|---|---|---|
| 点了干什么 | `Click` 处理里写死 | `Executed` |
| 能不能点 | 自己设 `IsEnabled` | `CanExecute`，Button 自动灰/亮 |
| 谁响应 | 绑在哪个控件上 | 沿树找 `CommandBinding`（常挂在 Window） |

### 本项目的四件套

**1. 声明命令（只有名字，没有逻辑）**

```csharp
public static RoutedCommand SaveCommand { get; } = new();
```

这是**静态**的：命令对象全程序一份。  
`CommandBindings` 不是静态类，是 Window 上的实例集合（`this.CommandBindings`）。

**2. 注册：告诉 Window「这个命令归我管」**

```csharp
CommandBindings.Add(new CommandBinding(SaveCommand, Save_Executed, Save_CanExecute));
```

等于注册表：

- 命令叫 `SaveCommand`
- 能不能执行 → 问 `Save_CanExecute`
- 真执行 → 走 `Save_Executed`

**3. 按钮接线：只负责触发**

```csharp
SaveButton.Command = SaveCommand;
```

按钮**没有**写 `Click`。点 Save 时，Button 内部会执行绑定的 `Command`，再走上面的 `CommandBinding`。

**4. 勾选变化后，强迫重新问「能不能点」**

```csharp
CommandManager.InvalidateRequerySuggested();
```

改 `CheckBox` 不会自动再调 `CanExecute`，所以要手动通知命令系统重新查询，Save 按钮才会启用/禁用。

### 一次点击时发生了什么

```text
1. 构造时：CommandBinding 注册 + SaveButton.Command 接线（只是准备，还没发命令）
2. 运行中：WPF 不时问 Save_CanExecute（勾选后靠 InvalidateRequerySuggested 触发）
3. 用户点已启用的 Save：
   → Button 执行 SaveCommand
   → 路由找到 Window 上的 CommandBinding
   → Save_Executed 运行，状态变成 "Save command executed"
```

不是「Click 事件去找命令」，而是 **Button 设了 Command 后，点击走命令这条路**。

### 和 Step 31 / 后面课程的关系

- Step 31：路由事件 + `Handled`  
- Step 32：同一套路由思想，换成**命令**  
- Step 38：MVVM 里用 `RelayCommand`（`ICommand`），思路类似，但不再走 WPF 的 `RoutedCommand` 路由

## 本步唯一新增

创建静态 `RoutedCommand`，并通过窗口 `CommandBinding` 提供 `CanExecute` 与 `Executed`。

## 运行后观察

1. 初始未勾选 Allow save：Save 按钮灰色（`CanExecute` 为 false）  
2. 勾选后：Save 启用  
3. 点 Save：`CommandStatus` 变成 `Save command executed`  
4. 取消勾选：Save 再次变灰

## 相比同轨上一步的改动

从普通 `MouseDown` 冒泡切换到命令路由，保留已学的 `Handled` 心智模型。

## 已学并复用

路由机制、x:Name、Click 与 code-behind。

## 固定脚手架

构造器先添加 `CommandBinding`，再给 `Button.Command` 赋值；`CheckBox` 点击后让 `CommandManager` 重新查询。

## 源码中保证不存在

`ICommand`/`RelayCommand`、MVVM、`CommandParameter` 与输入手势。

## 完成后的综合练习

CustomRoutedCommand 原版项目在完成第 35 步后解锁。
