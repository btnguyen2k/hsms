<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="HSMS.MyProfile.ChangePassword" Title="Untitled Page" %>
<asp:Content ID="ContentLeftMenu" ContentPlaceHolderID="CONTENT_LEFT_MENU" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="CONTENT_MAIN" runat="server">
    <center><h2>Đổi Mật Mã</h2></center>
    <center><asp:Label runat="server" ID="Message" /></center>
    <table align="center" border="0" cellpadding="4" cellspacing="0">
        <tr>
            <td>Mật mã cũ:</td>
            <td><input runat="server" type="password" id="InputOldPassword" style="width: 200px" /></td>
        </tr>
        <tr>
            <td>Mật mã mới:</td>
            <td><input runat="server" type="password" id="InputNewPassword" style="width: 200px" /></td>
        </tr>
        <tr>
            <td>Xác nhận mật mã mới:</td>
            <td><input runat="server" type="password" id="InputNewPassword2" style="width: 200px" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button runat="server" ID="BtnChangePassword" Text="Đổi Mật Mã" OnClick="BtnChangePassword_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
