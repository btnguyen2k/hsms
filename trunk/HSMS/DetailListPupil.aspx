<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailListPupil.aspx.cs" Inherits="HSMS.DetailListPupil" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
        <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="Blue" Width="568px"></asp:Label>&nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            <asp:Label ID="ListPupil" runat="server" Width="295px"></asp:Label>&nbsp;</center>
        <center>
            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" NavigateUrl="javascript:history.go(-1);"
                Target="content">Quay lại trang trước</asp:HyperLink>&nbsp;</center>
    </div>
    </form>
</body>
</html>
