<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailFAQ.aspx.cs" Inherits="HSMS.Admin.DetailFAQ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
        <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" ForeColor="Blue" Text="CÂU HỎI"></asp:Label>&nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            <asp:Label ID="Label2" runat="server" Text="CÂU HỎI" Width="79px"></asp:Label>&nbsp;</center>
        <center>
            <asp:TextBox ID="FAQQues" runat="server" Height="164px" TextMode="MultiLine" Width="465px"></asp:TextBox>&nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            <asp:Label ID="Email" runat="server" Width="227px"></asp:Label>&nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            <asp:Label ID="Label3" runat="server" Text="TRẢ LỜI" Width="95px"></asp:Label>&nbsp;</center>
        <center>
            <asp:TextBox ID="FAQAns" runat="server" Height="166px" TextMode="MultiLine" Width="461px"></asp:TextBox>&nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Gởi trả lời"
                Width="113px" />&nbsp;</center>
        <center>
            <asp:Label ID="Result" runat="server" ForeColor="Red" Width="460px"></asp:Label>&nbsp;</center>
        <center>
            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" NavigateUrl="~/Admin/FAQs_admin.aspx"
                Target="content_admin" Width="120px">Quay lại</asp:HyperLink>&nbsp;</center>
    </div>
    </form>
</body>
</html>
