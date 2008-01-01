<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SubjectCatList.aspx.cs" Inherits="HSMS.Admin.SubjectCatList" Title="Untitled Page" %>
<asp:Content ID="ContentLeftMenu" ContentPlaceHolderID="CONTENT_LEFT_MENU" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="CONTENT_MAIN" runat="server">
    <center><h2>Danh Sách Bộ Môn</h2></center>
    <center><asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl="AddSubjectCat.aspx">Thêm Bộ Môn Mới</asp:HyperLink></center>
    <br />
    <asp:Repeater runat="server" ID="RepSubjectCats">
        <HeaderTemplate>
            <table border="0" cellpadding="4" cellspacing="1" align="center" width="80%">
                <tr>
                    <td colspan="2" style="border: solid 1px #000000; font-weight: bold; background-color: #E0E0E0">
                        &nbsp;
                    </td>
                    <td align="center" style="border: solid 1px #000000; font-weight: bold; background-color: #E0E0E0">ID</td>
                    <td align="center" style="border: solid 1px #000000; font-weight: bold; background-color: #E0E0E0">Tên</td>
                    <td align="center" style="border: solid 1px #000000; font-weight: bold; background-color: #E0E0E0">Ghi Chú</td>
                    <td align="center" style="border: solid 1px #000000; font-weight: bold; background-color: #E0E0E0">Trưởng Bộ Môn</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center" style="border: solid 1px #000000"><a href="<%# DataBinder.Eval(Container.DataItem, "UrlEdit") %>">Sửa</a></td>
                <td align="center" style="border: solid 1px #000000"><a href="<%# DataBinder.Eval(Container.DataItem, "UrlDelete") %>">Xóa</a></td>
                <td align="center" style="border: solid 1px #000000"><%# DataBinder.Eval(Container.DataItem, "Id") %></td>
                <td align="center" style="border: solid 1px #000000"><%# DataBinder.Eval(Container.DataItem, "Name") %></td>
                <td align="center" style="border: solid 1px #000000"><%# DataBinder.Eval(Container.DataItem, "Description") %></td>
                <td align="center" style="border: solid 1px #000000"><%# DataBinder.Eval(Container.DataItem, "HeadTeacherLink")%></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    <center><asp:HyperLink runat="server" ID="HyperLink2" NavigateUrl="AddSubjectCat.aspx">Thêm Bộ Môn Mới</asp:HyperLink></center>
</asp:Content>
