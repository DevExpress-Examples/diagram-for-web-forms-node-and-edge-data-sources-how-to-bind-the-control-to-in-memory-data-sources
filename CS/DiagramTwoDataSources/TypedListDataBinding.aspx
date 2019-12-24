<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypedListDataBinding.aspx.cs" Inherits="DiagramTwoDataSources.TypedListDataBinding" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxDiagram ID="Diagram" runat="server" Width="100%" Height="600px"
            NodeDataSourceID="NodeDataSource" EdgeDataSourceID="EdgeDataSource" Units="Px">
            <SettingsAutoLayout Type="Layered" Orientation="Vertical" />
            <Mappings>
                <Node Key="ID" Type="Type" Width="Width" Height="Height" />
                <Edge Key="ID" FromKey="FromID" ToKey="ToID" Text="Text" />
            </Mappings>
        </dx:ASPxDiagram>

        <dx:ASPxButton ID="ResetButton" runat="server" Text="Reset" OnClick="ResetButton_Click"></dx:ASPxButton>

        <asp:ObjectDataSource ID="NodeDataSource" runat="server" 
            TypeName="DiagramTwoDataSources.NodesTypedListDataProvider" 
            DataObjectTypeName="DiagramTwoDataSources.Node"
            SelectMethod="GetNodes" 
            InsertMethod="InsertNode"
            UpdateMethod="UpdateNode"
            DeleteMethod="DeleteNode">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="EdgeDataSource" runat="server" 
            TypeName="DiagramTwoDataSources.EdgesTypedListDataProvider" 
            DataObjectTypeName="DiagramTwoDataSources.Edge"
            SelectMethod="GetEdges"
            InsertMethod="InsertEdge"
            UpdateMethod="UpdateEdge"
            DeleteMethod="DeleteEdge">
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
