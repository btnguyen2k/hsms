<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="HSMS.Admin.Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
        <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="Crimson" Text="THỐNG KÊ"
            Width="348px"></asp:Label>&nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" Target="content_admin"
                Width="122px" NavigateUrl="~/PupilInformation.aspx">- Thông tin chung</asp:HyperLink>&nbsp;</center>
        <center>
            <asp:HyperLink ID="HyperLink2" runat="server" ForeColor="Blue" NavigateUrl="~/Admin/detalclassscore.aspx"
                Target="content_admin" Width="117px">- Bảng điểm chi tiết</asp:HyperLink>&nbsp;</center>
            </div>
    </form>
</body>
</html>
