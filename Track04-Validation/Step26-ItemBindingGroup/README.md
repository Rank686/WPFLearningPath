# Step 26：ItemBindingGroup

## 本步唯一新增

在 ItemsControl.ItemBindingGroup 中定义 BindingGroup，让每个生成的行容器各自拥有一组价格提议值和联合规则。

## 运行后观察

把第一行改成 Start 50、Buy now 40，它保存失败；第二行保持 40、60，点击自己的 Save Row 仍会成功。

## 相比同轨上一步的改动

单个 Offer 面板变成 ObservableCollection 与 ItemsControl；同一组规则由每个行容器独立持有。

## 已学并复用

ObservableCollection、ItemsSource、DataTemplate、ValidationRule、BindingGroup、TwoWay Binding、x:Name 与 Click。

## 固定脚手架

Save Row 将 sender 转成 Button，用 OfferItems.ContainerFromElement 找到所属 FrameworkElement，再只调用该容器 BindingGroup 的 CommitEdit。

## 源码中保证不存在

ObjectDataProvider、ValidationAdornerSite、ItemContainerStyle、RelativeSource 错误路径与 Validation.ErrorTemplate。

## 完成后的综合练习

现在可以打开 `Data Binding/ValidateItemsInItemsControl/ValidateItemsInItemsControl.csproj`，以及前两步列出的校验综合项目。
