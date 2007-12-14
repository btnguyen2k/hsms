<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="function_teacher.aspx.cs" Inherits="HSMS.Teacher.function_teacher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" Target="content_teacher"
            Width="137px" NavigateUrl="~/Teacher/change_pass_teacher.aspx">* Thay đổi mật khẩu</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink2" runat="server" ForeColor="Blue" NavigateUrl="~/Teacher/scheduling.aspx"
            Target="content_teacher" Width="111px">* Lịch công tác</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink6" runat="server" ForeColor="Blue" NavigateUrl="~/Teacher/Track_learning.aspx"
            Target="content_teacher" Width="130px">* Theo dõi rèn luyện</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink3" runat="server" ForeColor="Blue" NavigateUrl="~/Teacher/tablescore_add.aspx"
            Target="content_teacher" Width="137px">* Bảng điểm môn học</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink5" runat="server" ForeColor="Blue" NavigateUrl="~/Teacher/MainClassFinalScore.aspx"
            Target="content_teacher" Width="129px">* Bảng điểm tổng kết</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink4" runat="server" ForeColor="Blue" NavigateUrl="~/Teacher/main_class_manager.aspx"
            Target="content_teacher">* Danh sách lớp</asp:HyperLink>&nbsp;</div>
    </form>
</body>
</html>
