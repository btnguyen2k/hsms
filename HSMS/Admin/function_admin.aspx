<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="function_admin.aspx.cs" Inherits="HSMS.Admin.function_admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="ChangePass" runat="server" Font-Underline="True" Font-Names="Verdana"
            Width="180px" Target="content_admin" NavigateUrl="change_pass_admin.aspx">*Thay đổi mật khẩu</asp:HyperLink><br />
        <asp:Label ID="Label1" runat="server" Text="* QUẢN LÝ HỌC SINH" Width="177px" Font-Underline="True"></asp:Label>
        <br />
        &nbsp;
        <asp:Label ID="Label2" runat="server" Text="+ "></asp:Label>
        <asp:HyperLink ID="AddPupil" runat="server" Font-Names="Verdana" Font-Size="Medium"
            ForeColor="#0000C0" Target="content_admin" NavigateUrl="add_pupil.aspx" Width="167px">Thêm học sinh mới</asp:HyperLink></div>      
    </form>
</body>
</html>
