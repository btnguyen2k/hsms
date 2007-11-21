<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="change_pass_admin.aspx.cs" Inherits="HSMS.Admin.change_pass_admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Mật mã cũ :" Width="117px"></asp:Label>&nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:TextBox ID="OldPass" runat="server" TextMode="Password"></asp:TextBox><br />
        &nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Mật mã mới :" Width="117px"></asp:Label>
        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
        <asp:TextBox ID="NewPass" runat="server" OnTextChanged="TextBox2_TextChanged"
            TextMode="Password"></asp:TextBox><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label3" runat="server" Text="Xác nhận lại :" Width="117px"></asp:Label>
        &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<asp:TextBox ID="NewPass_Confirm" runat="server" TextMode="Password"></asp:TextBox>&nbsp;<br />
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;
        <asp:Button ID="ChangePass" runat="server" OnClick="ChangePass_Click" Text="Lưu thay đổi"
            Width="127px"  /><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="lbOldPass" runat="server" ForeColor="Red" Width="409px"></asp:Label><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="lbNewPass" runat="server" ForeColor="Red" Width="407px"></asp:Label></div>
    </form>
</body>
</html>
