<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="class_manager.aspx.cs" Inherits="HSMS.Admin.class_manager2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Tên lớp:" Width="58px"></asp:Label>
        &nbsp;
        <asp:TextBox ID="ClassName" runat="server" Width="88px"></asp:TextBox>
        &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Năm học:" Width="65px"></asp:Label>
        &nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="ClassYear" runat="server" Width="78px"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Label9" runat="server" Text="Danh sách lớp:"></asp:Label>&nbsp;<asp:DropDownList
            ID="ClassValue" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ClassValue_SelectedIndexChanged">
        </asp:DropDownList><br />
        <asp:Label ID="Label10" runat="server" Text="Danh sách giáo  viên" Width="132px"></asp:Label>
        <asp:DropDownList ID="TeacherValue" runat="server" AutoPostBack="True" OnSelectedIndexChanged="TeacherValue_SelectedIndexChanged">
        </asp:DropDownList><br />
        <br />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="CreateNewClass" runat="server" OnClick="CreateNewClass_Click" Text="Thêm lớp mới"
            Width="96px" />
        &nbsp; &nbsp;<asp:Button ID="ChangeTeacher" runat="server" OnClick="ChangeTeacher_Click"
            Text="Đổi GVCN" Width="104px" />
        &nbsp;&nbsp;
        <asp:Button ID="EndYear" runat="server" Text="Kết thúc năm học" OnClick="EndYear_Click" />
        &nbsp; &nbsp;
        <asp:Button ID="ClassList" runat="server" OnClick="ClassList_Click" Text="Danh sách lớp"
            Width="125px" />&nbsp;
        <br />
        <asp:Label ID="ResultContent" runat="server" ForeColor="Red" Width="447px"></asp:Label><br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Mã số GVCN"></asp:Label>&nbsp;
        <asp:TextBox ID="MainTeacherID" runat="server" Width="111px"></asp:TextBox>
        &nbsp; &nbsp; &nbsp;
        <asp:Button ID="CreateNewClassFinal" runat="server" OnClick="CreateNewClassFinal_Click"
            Text="Xác nhận" Width="108px" /><br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Mã số GVCN cũ:"></asp:Label>
        &nbsp;<asp:TextBox ID="MainTeacherId_Old" runat="server" ReadOnly="True" Width="98px"></asp:TextBox>&nbsp;
        <asp:Label ID="Label5" runat="server" Text="MS GVCN mới:" Width="104px"></asp:Label>
        &nbsp;
        <asp:TextBox ID="MainTeacherId_New" runat="server" Width="101px"></asp:TextBox>
        &nbsp; &nbsp; &nbsp;<asp:Button ID="ChangeMainTeacher" runat="server" OnClick="ChangeMainTeacher_Click"
            Text="Xác nhận" />&nbsp;<br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Lớp mới:" Width="73px"></asp:Label>
        <asp:TextBox ID="NewClassName" runat="server" Width="100px"></asp:TextBox>&nbsp;
        <asp:Label ID="Label7" runat="server" Text="Năm học:" Width="75px"></asp:Label>
        <asp:TextBox ID="NewClassYear" runat="server" Width="92px"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Label8" runat="server" Text="GVCN:"></asp:Label>
        <asp:TextBox ID="NewClassMainTeacher" runat="server" Width="81px"></asp:TextBox>
        &nbsp; &nbsp;&nbsp; &nbsp;<asp:Button ID="NewUpClass" runat="server" Text="Xác nhận"
            Width="98px" OnClick="NewUpClass_Click" /><br />
        <br />
        <asp:Button ID="TeacherList" runat="server" OnClick="TeacherList_Click" Text="Danh sách giáo viên"
            Width="134px" />&nbsp;<br />
        <asp:Label ID="ResultAction" runat="server" ForeColor="Red" Width="438px"></asp:Label><br />
        <asp:Label ID="mode" runat="server"></asp:Label><br />
        <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" NavigateUrl="~/Admin/class_manager.aspx"
            Target="content_admin">Quay lại</asp:HyperLink></div>
    </form>
</body>
</html>
