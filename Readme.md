<!-- default file list -->
*Files to look at*:

* [TypedListDataBinding.aspx](./CS/DiagramTwoDataSources/TypedListDataBinding.aspx) (VB: [TypedListDataBinding.aspx](./VB/DiagramTwoDataSources/TypedListDataBinding.aspx))
* [NodesTypedListDataProvider.cs](./CS/DiagramTwoDataSources/NodesTypedListDataProvider.cs) (VB: [NodesTypedListDataProvider.vb](./VB/DiagramTwoDataSources/NodesTypedListDataProvider.vb))
* [EdgesTypedListDataProvider.cs](./CS/DiagramTwoDataSources/EdgesTypedListDataProvider.cs) (VB: [EdgesTypedListDataProvider.vb](./VB/DiagramTwoDataSources/EdgesTypedListDataProvider.vb))
* [DataTableDataBinding.aspx](./CS/DiagramTwoDataSources/DataTableDataBinding.aspx) (VB: [DataTableDataBinding.aspx](./VB/DiagramTwoDataSources/DataTableDataBinding.aspx))
* [NodesDataTableDataProvider.cs](./CS/DiagramTwoDataSources/NodesDataTableDataProvider.cs) (VB: [NodesDataTableDataProvider.vb](./VB/DiagramTwoDataSources/NodesDataTableDataProvider.vb))
* [EdgesDataTableDataProvider.cs](./CS/DiagramTwoDataSources/EdgesDataTableDataProvider.cs) (VB: [EdgesDataTableDataProvider.vb](./VB/DiagramTwoDataSources/EdgesDataTableDataProvider.vb))
<!-- default file list end -->

# Diagram for Web Forms - Node and Edge data sources - How to bind the control to in-memory data sources
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/229963825/)**
<!-- run online end -->

Unlike declarative *DataSource controls (such as AccessDataSource, SqlDataSource, LinqDataSource, EntityDataSource, and so on), custom in-memory data sources (such as List\<T>, DataTable and so on) do not allow you to automatically perform CRUD operations. These custom CRUD operations' logic can be implemented with the help of ObjectDataSource. This example demonstrates how to bind the Diagram control to ObjectDataSource and implement custom CRUD operations at the data source level. 

In this example, the Diagram control loads a graph structure from two data sources: one for shapes ([NodeDataSourceID](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.ASPxDiagram.NodeDataSourceID)) and the other for shape connectors ([EdgeDataSourceID](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.ASPxDiagram.EdgeDataSourceID)). You need to add mapping information for a shape [Key](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.DiagramMappingInfo.Key) and a connector [Key](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.DiagramMappingInfo.Key), [FromKey](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.DiagramEdgeMappingInfo.FromKey) and [ToKey](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxDiagram.DiagramEdgeMappingInfo.ToKey) properties.

***See also:***  
[Diagram for Web Forms - Tree from Linear Data Structure - How to bind the control to in-memory data sources](https://github.com/DevExpress-Examples/diagram-for-web-forms-linear-data-structure-how-to-bind-the-control-to-in-memory-data-sources)  
[Diagram for Web Forms - How to bind containers to an in-memory data source](https://github.com/DevExpress-Examples/diagram-for-web-forms-how-to-bind-containers-to-an-in-memory-data-source)
