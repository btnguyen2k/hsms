<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DeleteSubjectCat.aspx.cs" Inherits="HSMS.Admin.DeleteSubjectCat" Title="Untitled Page" %>
<asp:Content ID="ContentLeftMenu" ContentPlaceHolderID="CONTENT_LEFT_MENU" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="CONTENT_MAIN" runat="server">
    <center><h2>Xóa Bộ Môn</h2></center>
    <center><asp:Label runat="server" ID="Message"></asp:Label></center>
    <br />
    <center>
        <asp:Panel ID="PanelForm" runat="server">
            <asp:Button runat="server" ID="BtnYes" Text="Đồng Ý" OnClick="BtnYes_Click" />
            <asp:Button runat="server" ID="BtnNo" Text="Bỏ Chọn" OnClick="BtnNo_Click" />
    </asp:Panel>
    </center>
</asp:Content>
