# WPF 严格顺序学习路径

这里包含 42 个独立可运行的 WPF 小项目。每个 Step 只首次引入一个知识节点，同一轨道内以累计式快照演进，跨轨重新建立最小外壳。

## 学习方式

1. 从 Step01 开始，运行项目并完成 README 中的观察。
2. 只在完成当前 Step 后进入下一步。
3. 原版 Microsoft sample 是轨道结束后的综合练习，不保证单概念纯度。

## 验证与生成

在仓库根目录运行：

```powershell
powershell.exe -NoProfile -ExecutionPolicy Bypass -File .\LearningPath\tools\Test-LearningPath.ps1
powershell.exe -NoProfile -ExecutionPolicy Bypass -File .\LearningPath\tools\Build-LearningManifest.ps1
dotnet build .\LearningPath\WpfLearningPath.sln -c Release
```

校验器会检查步骤连续性、真实依赖、概念首次出现、每课明确禁止项、项目隔离、solution 成员、独立构建以及生成清单漂移。
