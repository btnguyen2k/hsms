<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testdb.aspx.cs" Inherits="HSMS.testdb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <h1 style="text-align: center">Application Test Page</h1>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" Text="Test DB Connection" OnClick="Button1_Click" />
        <asp:Label ID="labelTestDb" runat="server"></asp:Label>
        <br />
        <br />
        User ID:
        <asp:TextBox ID="inputUserId" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button2" runat="server" Text="Test Get User" OnClick="Button2_Click" />
        <asp:Label ID="labelTestGetUserId" runat="server"></asp:Label><br />
        <br />
        Login Name:
        <asp:TextBox ID="inputLoginName" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button3" runat="server" Text="Test Get User" OnClick="Button3_Click" />
        <asp:Label ID="labelTestGetUserLoginName" runat="server"></asp:Label><br />
        <br />
        Login Name:
        <asp:TextBox ID="inputCreateLoginName" runat="server"></asp:TextBox><br />
        Password:
        <asp:TextBox ID="inputCreatePassword" runat="server"></asp:TextBox><br />
        Email:
        <asp:TextBox ID="inputCreateEmail" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Test Create User" />
        <asp:Label ID="labelTestCreateUser" runat="server"></asp:Label>
    </form>
</body>
</html>
