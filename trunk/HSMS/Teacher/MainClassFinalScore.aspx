<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainClassFinalScore.aspx.cs" Inherits="HSMS.Teacher.MainClassFinalScore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Lớp:" Width="79px"></asp:Label>&nbsp;
        <asp:TextBox ID="ClassName" runat="server" OnTextChanged="TextBox1_TextChanged" Width="100px"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Năm" Width="76px"></asp:Label>
        &nbsp;
        <asp:TextBox ID="ClassYear" runat="server" OnTextChanged="TextBox1_TextChanged1"
            Width="103px"></asp:TextBox><br />
        <br />
        <asp:Button ID="ViewClassList" runat="server" OnClick="ViewClassList_Click" Text="Xác nhận"
            Width="110px" />
        <asp:Button ID="MainClassList" runat="server" OnClick="MainClassList_Click" Text="Danh sách các lớp chủ nhiệm"
            Width="235px" /><br />
        <br />
        <asp:RadioButtonList ID="HK_Select" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True">HK I</asp:ListItem>
            <asp:ListItem>HK II</asp:ListItem>
        </asp:RadioButtonList><br />
        <asp:Label ID="ResultContent" runat="server" ForeColor="Red" Width="655px"></asp:Label><br />
        <br />
        <asp:Button ID="SaveResult" runat="server" Text="Lưu" Visible="False" Width="168px" OnClick="SaveResult_Click" /></div>
    </form>
</body>
</html>
