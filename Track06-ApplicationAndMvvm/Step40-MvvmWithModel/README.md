# Step 40：带 Model 的完整 MVVM（手写）

## 先懂再跑

Step 37–39 只有 **View + ViewModel**：姓名、问候语、Save 都堆在 ViewModel 里。本步补上 **Model**，三层各管一件事。

| 层 | 管什么 | 本步例子 |
|---|---|---|
| **View** | 界面怎么摆 | `MainWindow.xaml` 的文本框、按钮、两块标题 |
| **ViewModel** | 编辑草稿、命令、给界面看的文案 | `Name` / `Score` 草稿、`Save` / `Reset`、`PassingPreview`、`StatusMessage` |
| **Model** | 已提交的业务数据 + 核心规则 | `Learner` 的姓名、分数、及格线、分数范围 |

界面故意分成两块，方便看见差别：

- **Draft (ViewModel)**：正在改、还没提交的值
- **Committed record (Model)**：上次 Save 写进去的 `Learner`

窗口 **只绑 ViewModel**。`MainWindow` 不 `new Learner()`，XAML 也不绑 `Learner`。

### Model 为什么单独存在

`Learner` 回答的是业务问题，不是界面问题：

- 分数只能在 0–100（`ClampScore`）
- 60 分及格（`IsPassingScore`）
- `Summary` 是这条记录自己的描述

这些规则就算换掉 WPF（改成控制台、测试、另一套 UI）也还成立。所以它们 **不该** 写在按钮旁边，也 **不该** 只活在 ViewModel 里。

ViewModel 做的是翻译：

1. 把 Model 的当前值拷成可编辑草稿
2. 输入时复用 Model 的规则做预览（`PassingPreview` 调用 `Learner.IsPassingScore`）
3. **Save**：草稿写入 `Learner`，Committed 那一行才变
4. **Reset**：用 `Learner` 覆盖草稿，丢掉未保存修改

判断心法（接 Step 37）：

1. 这是**显示/交互状态**吗？（草稿、状态消息、按钮能不能点）→ ViewModel
2. 这是**界面怎么画**吗？→ View
3. 这是**业务真相**吗？（已保存的学员、及格规则）→ Model

### Save / Reset 何时能点

| 命令 | CanExecute |
|---|---|
| Save | 姓名非空 **并且** 草稿和 Model 不一致 |
| Reset | 草稿和 Model 不一致 |

一打开窗口两者相同，两个按钮都禁用；改一个字后都启用；清空姓名后 Save 禁用、Reset 仍可用。

## 本步唯一新增

独立的 `Learner` Model：ViewModel 持有它，Save/Reset 在草稿和记录之间拷贝。

## 运行后观察

1. 启动时 Committed 为 `WPF learner · 75 · passing`，Save / Reset 禁用。
2. 把 Score 改成 `50`：预览变成 not passing，Committed **不变**；Save / Reset 启用。
3. 点 Save：Committed 才变成 `… · 50 · not passing`，按钮再次禁用。
4. 再改 Name，点 Reset：草稿回到上次保存的 Model，Committed 仍不动。

## 相比同轨上一步的改动

保留 ViewModel、INPC、RelayCommand 与 `DataContext` 接线；去掉工具窗口演示，换成「草稿 vs 已提交记录」。

## 已学并复用

ViewModel、DataContext、Binding、`UpdateSourceTrigger=PropertyChanged`、手写 `RelayCommand` 与 `CanExecute` 刷新。

## 固定脚手架

Application 仍负责启动、共享资源和退出。窗口只 `new MainWindowViewModel()`。

## 源码中保证不存在

第三方 MVVM 包、仓储/服务、依赖注入、集合编辑、异步命令与导航。

## 对照阅读

同一界面的 Toolkit 写法：`Step40-Compare-CommunityToolkitMvvm`。`Learner.cs` 几乎相同，变薄的是 ViewModel 样板。
