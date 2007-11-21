<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="function_admin.aspx.cs" Inherits="HSMS.Admin.function_admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="ChangePass" runat="server" Font-Underline="true" Font-Names="Verdana"
            Width="180px" Target="content_admin" NavigateUrl="change_pass_admin.aspx">Thay đổi mật khẩu</asp:HyperLink><br />
            
    </div>      
    </form>
</body>
</html>
