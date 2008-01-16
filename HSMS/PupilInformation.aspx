<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PupilInformation.aspx.cs" Inherits="HSMS.PupilInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
        <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="Blue"></asp:Label>&nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            <asp:Label ID="Label3" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>&nbsp;</center>
        <center>
            <asp:Label ID="Label2" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>&nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            <asp:Label ID="Label4" runat="server" ForeColor="Blue" Text="Trong đó"></asp:Label>&nbsp;</center>
        <center>
            <asp:Label ID="DetailK" runat="server" Width="396px"></asp:Label>&nbsp;</center>
        <center>
            &nbsp;</center>
        <a NAME="K10"></a>
        <center>
            <asp:Label ID="K10" runat="server" ForeColor="Blue" Text="Khối 10" Width="68px"></asp:Label>&nbsp;</center>
        <center>
            <asp:Label ID="DetailK10" runat="server" Width="393px"></asp:Label>&nbsp;</center>
        <center>
            &nbsp;</center>
         <a NAME="K11"></a>
        <center>
            <asp:Label ID="K11" runat="server" ForeColor="Blue" Text="Khối 11" Width="68px"></asp:Label>&nbsp;</center>
        <center>
            <asp:Label ID="DetailK11" runat="server" Width="393px"></asp:Label>&nbsp;</center>
        <center>
            &nbsp;</center>
        <a NAME="K12"></a>
        <center>
            <asp:Label ID="K12" runat="server" ForeColor="Blue" Text="Khối 12" Width="68px"></asp:Label>&nbsp;</center>
        <center>
            &nbsp;<asp:Label ID="DetailK12" runat="server" Width="393px"></asp:Label></center>
        <center>
            &nbsp;</center>        
        <center>
            &nbsp;</center>
        <center>
            <asp:Label ID="Label5" runat="server" Text="Chọn năm để xem" Width="125px"></asp:Label>
            <asp:DropDownList ID="YearList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="YearList_SelectedIndexChanged">
            </asp:DropDownList></center>
        <center>
            &nbsp;</center>
        <center>
            &nbsp;</center>
    </div>
    </form>
</body>
</html>
