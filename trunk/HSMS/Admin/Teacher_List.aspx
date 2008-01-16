<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher_List.aspx.cs" Inherits="HSMS.Admin.Teacher_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
        <asp:Label ID="Label1" runat="server" ForeColor="Blue" Text="DANH SÁCH GIÁO VIÊN CỦA TRƯỜNG"
            Width="297px"></asp:Label><br />
        <asp:Label ID="TeacherTable" runat="server" Width="638px"></asp:Label>&nbsp;</center>
        <center>
            <br />        
        <asp:Label ID="Label2" runat="server" ForeColor="Blue" Text="CHI TIẾT" Width="83px"></asp:Label><br />
        <asp:Label ID="SubjectDetail" runat="server" Width="335px"></asp:Label>
        </center>
    </div>
    </form>
</body>
</html>
