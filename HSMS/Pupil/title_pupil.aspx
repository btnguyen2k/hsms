<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="title_pupil.aspx.cs" Inherits="HSMS.Pupil.title_pupil" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
        <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Font-Size="XX-Large" ForeColor="Red"
            Text="TRANG HỌC SINH" Width="294px"></asp:Label>
            </center>
        <center>
        <asp:Button ID="LogOut" runat="server" BorderColor="White" BorderStyle="None" Font-Italic="True"
            OnClick="LogOut_Click" Text="(thoát)" /><br />
            &nbsp;</center>
        <asp:Label ID="Welcome" runat="server" ForeColor="Red" Width="605px"></asp:Label></div>
    </form>
</body>
</html>
