<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="DataTableDataBinding.aspx.vb" Inherits="DiagramTwoDataSources.DataTableDataBinding" %>

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
                <Node Key="ID" Type="Type" Width="Width" Height="Height" Style="Style" TextStyle="TextStyle" />
                <Edge Key="ID" FromKey="FromID" ToKey="ToID" Text="Text" />
            </Mappings>
        </dx:ASPxDiagram>

        <dx:ASPxButton ID="ResetButton" runat="server" Text="Reset" OnClick="ResetButton_Click"></dx:ASPxButton>

        <asp:ObjectDataSource ID="NodeDataSource" runat="server" TypeName="DiagramTwoDataSources.NodesDataTableDataProvider"
            SelectMethod="GetNodes"
            InsertMethod="InsertNode"
            UpdateMethod="UpdateNode"
            DeleteMethod="DeleteNode">
        </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="EdgeDataSource" runat="server" TypeName="DiagramTwoDataSources.EdgesDataTableDataProvider"
            SelectMethod="GetEdges"
            InsertMethod="InsertEdge"
            UpdateMethod="UpdateEdge"
            DeleteMethod="DeleteEdge">
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>