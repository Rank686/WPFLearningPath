# Step 14：IValueConverter

## 本步唯一新增

实现 NumberToTextConverter，在资源中注册实例，并让 OneWay Binding 通过 Converter 把数字变成说明文字。

## 运行后观察

拖动 Slider 时，TextBlock 立即显示“Current number: N”；源仍是 Slider.Value，转换器只改变送到目标的值形状。

## 相比同轨上一步的改动

移除 Profile 与属性通知面板；新增 `NumberToTextConverter.cs`，主界面改成 Slider 和单个转换结果。

## 已学并复用

ElementName、Path、OneWay Binding、x:Key 与 StaticResource。

## 固定脚手架

App、StartupUri、Window、x:Class、必要 xmlns、partial 与 InitializeComponent；IValueConverter 要求存在 ConvertBack 方法，但本步绑定不会调用它。

## 源码中保证不存在

ConvertBack 交互、MultiBinding、ItemsSource、ObservableCollection、DataTemplate。

## 完成后的综合练习

现在可以打开 `Data Binding/BindConversion/BindConversion.csproj`；它是原版综合项目，不保证单概念纯度。
