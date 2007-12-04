<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuickInstaller.aspx.cs" Inherits="HSMS.Installer.QuickInstaller" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HSMS - Quick Installer</title>
</head>
<body>
    <h1 style="text-align: center">HSMS - Chương Trình Cài Đặt</h1>
    <form id="FormQuickInstaller" runat="server">
    <div>
        <asp:Label ID="MsgPreInstall" runat="server" Text="Chương trình cài đặt sẽ tự động tạo tài khoản quản trị hệ thống với tên đăng nhập là admin và mật mã là password."></asp:Label><br />
        <asp:Label ID="MsgSchoolName" runat="server" Text="Tên Trường:"></asp:Label>
        <asp:TextBox ID="InputSchoolName" runat="server" Width="256"></asp:TextBox><br />
        <asp:Button ID="BtnInstall" runat="server" Text="Bắt Đầu Cài Đặt" OnClick="BtnInstall_Click" /><br />
        <asp:Label ID="MsgInstall" runat="server" Text="" Visible="false"></asp:Label></div>
    </form>
</body>
</html>
