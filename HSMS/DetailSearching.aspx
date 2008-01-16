<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailSearching.aspx.cs" Inherits="HSMS.DetailSearching" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="THÔNG TIN CHI TIẾT"></asp:Label>&nbsp;</center>
        <center>
            <asp:Label ID="Result" runat="server" Width="513px"></asp:Label>&nbsp;</center>
        <center>
            <asp:HyperLink ID="HyperLink2" runat="server" ForeColor="Blue" NavigateUrl="javascript:history.go(-1);"
                Target="content">Quay lại</asp:HyperLink>&nbsp;</center>
        <center>
        &nbsp;</center>
    </div>
    </form>
</body>
</html>
