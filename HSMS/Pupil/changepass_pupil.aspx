<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changepass_pupil.aspx.cs" Inherits="HSMS.Pupil.changepass_pupil" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Mật khẩu cũ" Width="113px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="OldPass" runat="server" TextMode="Password"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Mật khẩu mới" Width="113px"></asp:Label>&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="NewPass" runat="server" TextMode="Password"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Xác nhận lại" Width="113px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="NewPassConfirm" runat="server" TextMode="Password"></asp:TextBox><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="ChangePass" runat="server" OnClick="ChangePass_Click" Text="Lưu thay đổi"
            Width="123px" /><br />
        <asp:Label ID="ResultOldPass" runat="server" ForeColor="Red" Width="391px"></asp:Label><br />
        <asp:Label ID="ResultNewPass" runat="server" ForeColor="Red" Width="389px"></asp:Label></div>
    </form>
</body>
</html>
