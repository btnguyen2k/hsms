<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Function.aspx.cs" Inherits="HSMS.Function" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="MainPage" runat="server" Font-Italic="True" Font-Names="Verdana"
            Width="154px" Target="content" NavigateUrl="content.aspx">Trang Chủ</asp:HyperLink><br />
      
        <asp:HyperLink ID="Notice" runat="server" Font-Italic="True" Font-Names="Verdana"
            Width="154px" Target="content" NavigateUrl="http://www.google.com">Thông Báo</asp:HyperLink><br />
      
        <asp:HyperLink ID="Enroll" runat="server" Font-Italic="True" Font-Names="Verdana"
            Width="154px" Target="content" NavigateUrl="file_docs/Nhap_hoc.html">Thủ Tục Nhập Học</asp:HyperLink><br />
      
        <asp:HyperLink ID="CSVC" runat="server" Font-Italic="True" Font-Names="Verdana"
            Width="154px" Target="content" NavigateUrl="http://www.google.com">Cở Sở Vật Chất</asp:HyperLink><br />
      
        <asp:HyperLink ID="BGH" runat="server" Font-Italic="True" Font-Names="Verdana"
            Width="154px" Target="content" NavigateUrl="http://www.google.com">Ban Giám Hiệu</asp:HyperLink><br />
      
        <asp:HyperLink ID="News" runat="server" Font-Italic="True" Font-Names="Verdana"
            Width="154px" Target="content" NavigateUrl="http://www.cand.com.vn">Tin Tức</asp:HyperLink><br />
        
    </form>
</body>
</html>
