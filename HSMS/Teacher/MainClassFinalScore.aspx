<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainClassFinalScore.aspx.cs" Inherits="HSMS.Teacher.MainClassFinalScore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
        <asp:Label ID="Begin" runat="server" Width="678px" Font-Size="X-Large" ForeColor="Blue">BẢNG ĐIỂM CHI TIẾT CỦA LỚP</asp:Label><br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Lớp:" Width="79px"></asp:Label>&nbsp;
        <asp:DropDownList ID="ClassName" runat="server">
        </asp:DropDownList>&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Năm" Width="76px"></asp:Label>
        &nbsp;
        <asp:TextBox ID="ClassYear" runat="server" 
            Width="57px"></asp:TextBox><br />
        <asp:RadioButtonList ID="HK_Select" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True">HK I</asp:ListItem>
            <asp:ListItem>HK II</asp:ListItem>
        </asp:RadioButtonList></center>
        <center>
            &nbsp;</center>
        <center>
        <asp:Button ID="ViewClassList" runat="server" OnClick="ViewClassList_Click" Text="Xác nhận"
            Width="110px" /><br />
        <br />
        <asp:Label ID="ResultContent" runat="server" ForeColor="Red" Width="655px"></asp:Label><br />
        <br />
        <asp:Button ID="SaveResult" runat="server" Text="Lưu" Visible="False" Width="168px" OnClick="SaveResult_Click" /><br />
        <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" NavigateUrl="~/Teacher/MainClassFinalScore.aspx"
            Target="content_teacher" Width="59px">Quay lại</asp:HyperLink>
        </center>
    </div>
    </form>
</body>
</html>
