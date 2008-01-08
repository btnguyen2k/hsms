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
            Width="154px" Target="content" NavigateUrl="~/Notice.aspx">Thông Báo</asp:HyperLink><br />
      
        <asp:HyperLink ID="Enroll" runat="server" Font-Italic="True" Font-Names="Verdana"
            Width="154px" Target="content" NavigateUrl="file_docs/Nhap_hoc.html">Thủ Tục Nhập Học</asp:HyperLink><br />
      
        <asp:HyperLink ID="CSVC" runat="server" Font-Italic="True" Font-Names="Verdana"
            Width="154px" Target="content" NavigateUrl="file_docs/cosovatchat.html">Cở Sở Vật Chất</asp:HyperLink><br />
      
        <asp:HyperLink ID="BGH" runat="server" Font-Italic="True" Font-Names="Verdana"
            Width="154px" Target="content" NavigateUrl="~/file_docs/bangiamhieu.htm">Ban Giám Hiệu</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Italic="True" Font-Names="Verdana"
            ForeColor="Blue" NavigateUrl="~/file_docs/nhansu.htm" Target="content" Width="149px">Tổ chức nhân sự</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink2" runat="server" Font-Italic="True" Font-Names="Verdana"
            ForeColor="Blue" NavigateUrl="~/file_docs/lichsuphattrien.htm" Target="content"
            Width="147px">Lịch sử trường</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink3" runat="server" Font-Italic="True" Font-Names="Verdana"
            ForeColor="Blue" NavigateUrl="~/file_docs/thanhtich.htm" Target="content" Width="150px">Thành tích</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink4" runat="server" Font-Italic="True" Font-Names="Verdana"
            ForeColor="Blue" NavigateUrl="http://google.com.vn" Target="content" Width="150px">FQAs</asp:HyperLink><br />
      
        <asp:HyperLink ID="News" runat="server" Font-Italic="True" Font-Names="Verdana"
            Width="154px" Target="content" NavigateUrl="http://www.cand.com.vn">Tin Tức</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink5" runat="server" Font-Italic="True" Font-Names="Verdana"
            ForeColor="Blue" NavigateUrl="Mailto:webmaster@ptth.com" Target="content" Width="151px">Liên hệ</asp:HyperLink>
        &nbsp;
        
    </form>
</body>
</html>
