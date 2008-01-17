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
        <asp:Label ID="Label12" runat="server" Font-Names="Verdana" Text="NHÂN SỰ" Width="77px"></asp:Label><br />
        &nbsp;
        <asp:Label ID="Label4" runat="server" Text="GIÁO VIÊN" Width="174px"></asp:Label><br />
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
        <asp:Label ID="Label11" runat="server" Text="+"></asp:Label>
        <asp:HyperLink ID="HyperLink10" runat="server" Font-Names="Verdana" ForeColor="Blue"
            NavigateUrl="~/Admin/Teacher_List.aspx" Target="content_admin" Width="169px">Danh sách giáo viên</asp:HyperLink><br />
        &nbsp;
        <asp:Label ID="Label1" runat="server" Text="HỌC SINH" Width="162px" Font-Underline="True"></asp:Label><br />
        &nbsp;
        <asp:Label ID="Label2" runat="server" Text="+ "></asp:Label>
        <asp:HyperLink ID="AddPupil" runat="server" Font-Names="Verdana" Font-Size="Medium"
            ForeColor="#0000C0" Target="content_admin" NavigateUrl="add_pupil.aspx" Width="157px">Thêm học sinh mới</asp:HyperLink><br />
        &nbsp;
        <asp:Label ID="Label3" runat="server" Text="+" Width="1px"></asp:Label>&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Verdana" Font-Size="Medium"
            NavigateUrl="~/Admin/edit_del_pupil.aspx" Target="content_admin" Width="160px">Chỉnh sữa học sinh</asp:HyperLink><br />
        <asp:Label ID="Label13" runat="server" Font-Names="Verdana" Text="THỜI GIAN BIỂU"></asp:Label><br />
        &nbsp;
        <asp:Label ID="Label7" runat="server" Text="+"></asp:Label>
        <asp:HyperLink ID="HyperLink4" runat="server" Font-Names="Verdana" ForeColor="Blue"
            NavigateUrl="~/Admin/teacher_scheduling.aspx" Target="content_admin" Font-Italic="False">Lịch giáo viên</asp:HyperLink><br />
        &nbsp;
        <asp:Label ID="Label14" runat="server" Text="+"></asp:Label>
        <asp:HyperLink ID="HyperLink6" runat="server" Font-Names="Verdana" ForeColor="Blue"
            NavigateUrl="~/Admin/class_schedule.aspx" Target="content_admin" Font-Italic="False">Lịch lớp học</asp:HyperLink><br />
        <asp:Label ID="Label9" runat="server" Text="HỆ THỐNG THÔNG BÁO" Width="179px"></asp:Label><br />
        &nbsp; &nbsp;
        <asp:Label ID="Label8" runat="server" Text="+" Width="4px"></asp:Label>
        <asp:HyperLink
            ID="HyperLink8" runat="server" Font-Names="Verdana" NavigateUrl="~/Admin/AddNews.aspx"
            Target="content_admin" Width="140px">Thêm thông báo </asp:HyperLink><br />
        &nbsp;<asp:Label ID="Label10" runat="server" Text="+" Width="12px"></asp:Label>
        <asp:HyperLink ID="HyperLink9" runat="server" Font-Names="Verdana" ForeColor="Blue"
            NavigateUrl="~/Admin/EditNews.aspx" Target="content_admin" Width="135px">Sữa thông báo</asp:HyperLink><br />
        <asp:Label ID="Label15" runat="server" Text="CHƯƠNG TRÌNH ĐÀO TẠO" Width="197px"></asp:Label><br />
        &nbsp;
        <asp:Label ID="Label16" runat="server" Text="+"></asp:Label>
        <asp:HyperLink ID="HyperLink5" runat="server" Font-Names="Verdana" ForeColor="Blue"
            NavigateUrl="~/Admin/subject_manager.aspx" Target="content_admin">Môn học</asp:HyperLink><br />
        &nbsp;
        <asp:Label ID="Label17" runat="server" Text="+"></asp:Label>
        <asp:HyperLink ID="HyperLink7" runat="server" Font-Names="Verdana" NavigateUrl="~/Admin/class_manager.aspx"
            Target="content_admin">Lớp học</asp:HyperLink>&nbsp;
        <br />
        <asp:HyperLink ID="HyperLink11" runat="server" Font-Names="Verdana" ForeColor="Blue"
            NavigateUrl="~/Admin/Map.aspx" Target="content_admin">* Quản lý phòng ốc</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink13" runat="server" Font-Names="Verdana" ForeColor="Blue"
            NavigateUrl="~/Admin/FAQs_admin.aspx" Target="content_admin">FAQs</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink12" runat="server" Font-Names="Verdana" ForeColor="Blue"
            NavigateUrl="~/Admin/Report.aspx" Target="content_admin">Tổng kết</asp:HyperLink></div>      
    </form>
</body>
</html>
