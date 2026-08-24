# Step 09：Source 与 CLR 对象

## 本步唯一新增

创建普通 Profile 对象，将它放入 Window.Resources，并在 Binding 中用 `Source={StaticResource profile}` 明确指定数据源。

## 运行后观察

TextBlock 读取 Profile.DisplayName 并显示“Ada Lovelace”。Profile 只是普通自动属性，没有变化通知。

## 相比同轨上一步的改动

移除控件到控件的输入实验；新增 `Profile.cs`、资源对象和显式 Source Binding，让问题集中在“数据源是谁”。

## 已学并复用

Binding、Path、StackPanel、x:Key 与 StaticResource。

## 固定脚手架

App、StartupUri、Window、x:Class、必要 xmlns、partial 与 InitializeComponent。

## 源码中保证不存在

DataContext、INotifyPropertyChanged、显式 Mode、ObjectDataProvider、集合。

## 完成后的综合练习

完成 Step14 后再打开 `Data Binding/SimpleBinding/SimpleBinding.csproj` 的只读部分；它是原版综合项目，不保证单概念纯度。
