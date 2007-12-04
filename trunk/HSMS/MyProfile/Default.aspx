<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HSMS.MyProfile.Default" %>
<asp:Content ID="ContentLeftMenu" ContentPlaceHolderID="CONTENT_LEFT_MENU" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="CONTENT_MAIN" runat="server">
    <b>Hướng Dẫn</b><br />
    - Sử dụng đường dẫn <asp:HyperLink ID="HyperLink1" runat="Server" NavigateUrl="ChangePassword.aspx">Đổi Mật Mã</asp:HyperLink> để thay đổi mật mã đăng nhập của bạn.
</asp:Content>