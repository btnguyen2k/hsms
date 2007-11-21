<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tittle.aspx.cs" Inherits="HSMS.Tittle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="title" runat="server" BackColor="Blue" BorderColor="Yellow" BorderStyle="Dotted"
            Caption="WEBSITE TRƯỜNG PTTH" Font-Names="Verdana" Font-Size="XX-Large" ForeColor="#FF8000"
            HorizontalAlign="Center" Width="554px">
        </asp:Table>
        <br />
        <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Text="Tên đăng nhập:"></asp:Label>
        <asp:TextBox ID="LoginName" runat="server" BorderColor="White" Columns="4" ForeColor="Black"
            Height="15px" OnTextChanged="TextBox1_TextChanged" Width="212px"></asp:TextBox><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Font-Names="Verdana" Text="Mật mã:" Width="69px"></asp:Label>
        <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="211px"></asp:TextBox><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;
        <asp:Button ID="LoginProcess" runat="server" OnClick="LoginProcess_Click" Text="Đăng nhập"
            Width="110px" /><br />
        <asp:RadioButtonList ID="RadioButton_Choice" runat="server" BackColor="SpringGreen"
            BorderColor="Blue" Font-Names="Verdana" Height="26px" RepeatDirection="Horizontal"
            Width="529px">
            <asp:ListItem Selected="True">Admin</asp:ListItem>
            <asp:ListItem>Gi&#225;o vi&#234;n</asp:ListItem>
            <asp:ListItem>Học Sinh</asp:ListItem>
            <asp:ListItem>Phụ huynh</asp:ListItem>
        </asp:RadioButtonList></div>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    </form>
</body>
</html>
