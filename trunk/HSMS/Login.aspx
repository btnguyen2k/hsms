<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Login.aspx.cs" Inherits="HSMS.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="FormLogin" runat="server">
        <table border="0" cellpadding="4" cellspacing="1" width="1024" align="center">
            <tr>
                <td align="center">
                    <h1>
                        <asp:Label ID="PageHeader" runat="server" /></h1>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label runat="server" ID="ErrorMessage" Visible="False" ForeColor="Red" />
                    <table border="0" cellpadding="4" cellspacing="1" align="center">
                        <tr>
                            <td>
                                Tên đăng nhập</td>
                            <td>
                                :</td>
                            <td>
                                <input runat="server" id="InputLoginName" type="text" /></td>
                        </tr>
                        <tr>
                            <td>
                                Mật mã</td>
                            <td>
                                :</td>
                            <td>
                                <input runat="server" id="InputPassword" type="password" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="ButtonLogin" runat="server" Text="Đăng Nhập" OnClick="ButtonLogin_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:HyperLink runat="server" NavigateUrl="~/Default.aspx">Trở Về Trang Chủ</asp:HyperLink>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
