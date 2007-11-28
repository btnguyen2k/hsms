<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="function_admin.aspx.cs" Inherits="HSMS.Admin.function_admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="ChangePass" runat="server" Font-Underline="True" Font-Names="Verdana"
            Width="180px" Target="content_admin" NavigateUrl="change_pass_admin.aspx">*Thay đổi mật khẩu</asp:HyperLink><br />
        <asp:Label ID="Label4" runat="server" Text="QUẢN LÝ GIÁO VIÊN" Width="174px"></asp:Label><br />
        &nbsp;
        <asp:Label ID="Label5" runat="server" Text="+"></asp:Label>
        <asp:HyperLink ID="HyperLink2" runat="server" Font-Names="Verdana" Font-Size="Medium"
            ForeColor="Blue" NavigateUrl="~/Admin/add_tearcher.aspx" Target="content_admin"
            Width="165px">Thêm giáo viên mới</asp:HyperLink><br />
        &nbsp;
        <asp:Label ID="Label6" runat="server" Text="+"></asp:Label>
        <asp:HyperLink ID="HyperLink3" runat="server" Font-Names="Verdana" Font-Size="Medium"
            ForeColor="Blue" NavigateUrl="~/Admin/edit_del_teacher.aspx" Target="content_admin">Chỉnh sữa giáo viên</asp:HyperLink><br />
        &nbsp;
        <asp:Label ID="Label7" runat="server" Text="+"></asp:Label>
        <asp:HyperLink ID="HyperLink4" runat="server" Font-Names="Verdana" ForeColor="Blue"
            NavigateUrl="~/Admin/teacher_scheduling.aspx" Target="content_admin">Lịch giảng dạy</asp:HyperLink><br />
        <asp:Label ID="Label1" runat="server" Text="* QUẢN LÝ HỌC SINH" Width="177px" Font-Underline="True"></asp:Label>
        <br />
        &nbsp;
        <asp:Label ID="Label2" runat="server" Text="+ "></asp:Label>
        <asp:HyperLink ID="AddPupil" runat="server" Font-Names="Verdana" Font-Size="Medium"
            ForeColor="#0000C0" Target="content_admin" NavigateUrl="add_pupil.aspx" Width="157px">Thêm học sinh mới</asp:HyperLink><br />
        &nbsp;
        <asp:Label ID="Label3" runat="server" Text="+" Width="1px"></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Verdana" Font-Size="Medium"
            NavigateUrl="~/Admin/edit_del_pupil.aspx" Target="content_admin" Width="160px">Chỉnh sữa học sinh</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink5" runat="server" Font-Names="Verdana" ForeColor="Blue"
            NavigateUrl="~/Admin/subject_manager.aspx" Target="content_admin">* Quản lý môn học</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink6" runat="server" Font-Names="Verdana" ForeColor="Blue"
            NavigateUrl="~/Admin/class_schedule.aspx" Target="content_admin">* Thời khoá biểu</asp:HyperLink></div>      
    </form>
</body>
</html>
