<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Searching.aspx.cs" Inherits="HSMS.Searching" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" ForeColor="Blue" Text="TÌM KIẾM THÔNG TIN"
            Width="169px"></asp:Label><br />
        <br />
        &nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="InputText" runat="server" Width="189px"></asp:TextBox>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Button ID="StartSearch" runat="server" OnClick="StartSearch_Click" Text="Tìm"
            Width="90px" /><br />
        &nbsp;
        <br />
        &nbsp;&nbsp;
        <asp:Label ID="Result" runat="server" Width="537px"></asp:Label><br />
        &nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" NavigateUrl="~/Searching.aspx"
            Target="content">Quay lại</asp:HyperLink></div>
    </form>
</body>
</html>
