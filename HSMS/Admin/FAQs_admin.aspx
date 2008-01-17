<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FAQs_admin.aspx.cs" Inherits="HSMS.Admin.FAQs_admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
        <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="Red" Text="DANH SÁCH CÁC CÂU HỎI CHƯA TRẢ LỜI"
            Width="471px"></asp:Label><br />
        <br />
        <br />
        <asp:Label ID="ListTable" runat="server" Width="642px"></asp:Label>&nbsp;
        </center>
        <center>
            &nbsp;</center>
        <center>
            <asp:Label ID="Label2" runat="server" Font-Size="X-Large" ForeColor="Red" Text="DANH SÁCH CÂU HỎI ĐÃ TRẢ LỜI"
                Width="409px"></asp:Label>&nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            <asp:Label ID="ListTable1" runat="server" Width="643px"></asp:Label>&nbsp;</center>
    </div>
    </form>
</body>
</html>
