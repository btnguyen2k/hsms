<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="title_teacher.aspx.cs" Inherits="HSMS.Teacher.title_teacher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
        <asp:Label  ID="Label1" runat="server" Font-Names="Verdana"
            Font-Size="XX-Large" ForeColor="DarkViolet" Text="TRANG GI�O VI�N"></asp:Label>&nbsp;<br />
        </center>
        <center>
        <asp:Button ID="LogOut" runat="server" BorderColor="White" BorderStyle="None" Font-Italic="True"
            Font-Names="Verdana" Font-Underline="True" Text="(tho�t)" OnClick="LogOut_Click" /><br />
            </center>
        <asp:Label ID="Welcome" runat="server" ForeColor="Lime" Width="631px"></asp:Label></div>
    </form>
</body>
</html>
