<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxHyperLink runat="server" NavigateUrl="TypedListDataBinding.aspx" Text="Typed List Data Binding"></dx:ASPxHyperLink>
        <br />
        <dx:ASPxHyperLink runat="server" NavigateUrl="DataTableDataBinding.aspx" Text="DataTable Data Binding"></dx:ASPxHyperLink>
    </div>
    </form>
</body>
</html>