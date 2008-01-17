<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FAQs.aspx.cs" Inherits="HSMS.FAQs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
        <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="Red" Text="CÁC CÂU HỎI THƯỜNG GẶP"
            Width="321px"></asp:Label>&nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            <asp:Label ID="ContentQA" runat="server" Width="546px" BackColor="Blue" ForeColor="Yellow"></asp:Label>&nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            <asp:Label ID="Label2" runat="server" Text="Nội dung câu hỏi:" Width="176px"></asp:Label>&nbsp;</center>
        <center>
            <asp:TextBox ID="ContentFAQ" runat="server" Height="210px" TextMode="MultiLine" Width="440px"></asp:TextBox>&nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            <asp:Label ID="Label3" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="EmailFAQ" runat="server" Width="229px"></asp:TextBox></center>
        <center>
            &nbsp;</center>
        <center>
            <asp:Button ID="SubmitFAQ" runat="server" OnClick="SubmitFAQ_Click" Text="Gởi câu hỏi"
                Width="122px" />&nbsp;</center>
        <center>
            <asp:Label ID="Result" runat="server" Width="402px" ForeColor="Red"></asp:Label>&nbsp;</center>
    </div>
    </form>
</body>
</html>
