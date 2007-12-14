<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="function_pupil.aspx.cs" Inherits="HSMS.Pupil.function_pupil" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" NavigateUrl="~/Pupil/changepass_pupil.aspx"
            Target="content_pupil" Width="131px">* Thay đổi mật khẩu</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink2" runat="server" ForeColor="Blue" NavigateUrl="~/Pupil/schedule.aspx"
            Target="content_pupil">* Thời khoá biểu</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink3" runat="server" ForeColor="Blue" NavigateUrl="~/Pupil/ScoreTable.aspx"
            Target="content_pupil" Width="129px">* Xem bảng điểm</asp:HyperLink>&nbsp;</div>
    </form>
</body>
</html>
