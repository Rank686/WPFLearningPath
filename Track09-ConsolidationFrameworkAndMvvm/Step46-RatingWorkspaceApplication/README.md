# Step 46：多窗口评分工作区

## 本项目巩固

把 RatingBadge 工作台放入显式 Application 启动流程，并让主窗口和无 Owner 的工具窗口共享应用级资源。

## 运行后观察

主窗口和工具窗口共享 Application 资源；关闭主窗口后整个应用退出。

## 相比同轨上一步的改动

保留 RatingBadge 工作台，加入显式启动、MainWindow、ShutdownMode 和跨窗口资源。

## 已学并复用

RatingBadge、BasedOn Style、ControlTemplate、DataTrigger、RoutedCommand、依赖属性回调、XAML Click、StaticResource 与 Application 作用域。

## 固定脚手架

App.xaml 不使用 StartupUri；OnStartup 设置 OnMainWindowClose、创建并指定 MainWindow；ToolWindow 保持无 Owner。

## 源码中保证不存在

ViewModel、RelayCommand、RelativeSource 与隐式 Style。

## 完成后的综合练习

打开工具窗口，确认两个窗口使用同一强调色，然后保持工具窗口打开并关闭主窗口，观察整个应用退出。
