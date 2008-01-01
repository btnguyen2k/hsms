<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_pupil.aspx.cs" Inherits="HSMS.Admin.add_pupil" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Font-Size="XX-Large" ForeColor="Red"
            Height="26px" Text="THÊM HỌC SINH MỚI" Width="370px"></asp:Label><br />
        <br />
        <br />
        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label2" runat="server" Text="Họ và Tên : "
            Width="102px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="Name" runat="server" Width="229px" OnTextChanged="Name_TextChanged"></asp:TextBox><br />
        <br />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Ngày tháng năm sinh :" Width="141px"></asp:Label>&nbsp;
        <asp:TextBox ID="Day" runat="server" Width="32px"></asp:TextBox>&nbsp; &nbsp;<asp:TextBox
            ID="Month" runat="server" Width="32px"></asp:TextBox>&nbsp; &nbsp;<asp:TextBox ID="Year"
                runat="server" Width="80px"></asp:TextBox>
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="(ngày/tháng/năm)" Width="113px"></asp:Label><br />
        <br />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Năm nhập học :" Width="106px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="Year_Enroll" runat="server" Width="80px"></asp:TextBox><br />
        <br />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="Theo học lớp :" Width="92px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
        <asp:TextBox ID="Class" runat="server" Width="81px"></asp:TextBox><br />
        <br />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label7" runat="server" Text="Mã số học sinh :" Width="122px"></asp:Label>
        &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="Pupil_id" runat="server" Width="90px"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Label ID="Label8" runat="server" Text="(mặc định là username và pass cho học sinh đó)"
            Width="300px"></asp:Label><br />
        <br />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label9" runat="server" Text="Email :" Width="65px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="Email" runat="server" Width="178px"></asp:TextBox><br />
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; 
        <asp:Button ID="AddPupil" runat="server" Text="Thêm học sinh" Width="184px" OnClick="AddPupil_Click" />
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="ViewClassList" runat="server" OnClick="ViewClassList_Click" Text="Danh sách lớp"
            Width="103px" /><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Add_Result" runat="server" ForeColor="Red" Width="445px"></asp:Label></div>
    </form>
</body>
</html>
