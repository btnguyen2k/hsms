<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScoreTable.aspx.cs" Inherits="HSMS.Pupil.ScoreTable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Năm học:" Width="80px"></asp:Label>
        <asp:TextBox ID="ClassYear" runat="server" Width="94px"></asp:TextBox><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="ConfirmYear" runat="server" OnClick="ConfirmYear_Click" Text="Xác nhận" />
        <br />
        <br />
        <asp:Label ID="ResultContent" runat="server" ForeColor="Red" Width="509px"></asp:Label><br />
        <br />
        <asp:Label ID="ResultFinal" runat="server" ForeColor="Red" Width="575px"></asp:Label></div>
    </form>
</body>
</html>
