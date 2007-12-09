<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddSubjectCat.aspx.cs" Inherits="HSMS.Admin.AddSubjectCat" Title="Untitled Page" %>
<asp:Content ID="ContentLeftMenu" ContentPlaceHolderID="CONTENT_LEFT_MENU" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="CONTENT_MAIN" runat="server">
    <center><h2>Thêm Bộ Môn</h2></center>
    <center>
        <asp:Label runat="server" ID="ErrorMessage" ForeColor="red" />
    </center>
    <table border="0" cellpadding="4" cellspacing="1" align="center" width="80%">
        <tr>
            <td>
                ID<br />
                <small>(Tối đa 10 ký tự, chỉ bao gồm chữ cái và chữ số, không bao gồm các ký tự đặc biệt và khoảng trắng)</small>
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox runat="server" ID="InputSubjectCatId" MaxLength="10" Width="256"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Tên Bộ Môn<br />
                <small>(Ví dụ: Toán - Tin, Văn - Sử - Địa, v.v...)</small>
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox runat="server" ID="InputSubjectCatName" MaxLength="64" Width="256"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Ghi Chú Thêm
            </td>
            <td>
                :
            </td>
            <td>
                <asp:TextBox runat="server" ID="InputSubjectCatDesc" MaxLength="255" Width="256"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button runat="server" ID="BtnCreateSubjectCat" Text="Tạo Bộ Môn Mới" OnClick="BtnCreateSubjectCat_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
