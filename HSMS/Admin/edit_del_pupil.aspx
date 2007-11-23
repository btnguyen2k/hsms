<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_del_pupil.aspx.cs" Inherits="HSMS.Admin.del_pupil" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Font-Size="XX-Large" ForeColor="Red"
            Text="THÔNG TIN HỌC SINH" Width="379px"></asp:Label><br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Mã số học sinh : " Width="107px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Width="130px"></asp:TextBox>
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="FinPupil" runat="server" Text="Tìm kiếm" Width="116px" /><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Find_Result" runat="server" Font-Names="Verdana" ForeColor="Red" Width="329px"></asp:Label><br />
        <br />
    
    </div>
    </form>
</body>
</html>
