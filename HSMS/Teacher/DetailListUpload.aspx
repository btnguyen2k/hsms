<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailListUpload.aspx.cs" Inherits="HSMS.Teacher.DetailListUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="ResultTable" runat="server" Width="663px"></asp:Label><br />
        <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" NavigateUrl="~/Teacher/ListUpload.aspx"
            Target="content_teacher" Width="62px">Quay lại</asp:HyperLink>&nbsp;</div>
    </form>
</body>
</html>
