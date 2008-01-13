<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="subject_manager.aspx.cs" Inherits="HSMS.Admin.class_manager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Font-Size="XX-Large" ForeColor="Red"
            Text="QUẢN LÝ MÔN HỌC"></asp:Label><br />
        &nbsp;<br />
        &nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Tên môn học:"></asp:Label>
        &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;<asp:DropDownList ID="SubjectName" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Button ID="Find_Subject" runat="server" OnClick="Find_Subject_Click" Text="Tìm"
            Width="78px" />
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<br />
        &nbsp; &nbsp; &nbsp;
        <br />
        &nbsp;&nbsp;
        <asp:Label ID="Find_Sub_Result" runat="server" ForeColor="Red" Width="212px"></asp:Label>
        &nbsp;<br />
        &nbsp;&nbsp;
        <asp:Button ID="Subject_del" runat="server" OnClick="Subject_del_Click" Text="Xoá môn học"
            Width="84px" /><br />
        <br />
        &nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Tên môn học : " Width="90px"></asp:Label>
        <asp:TextBox ID="Subject_addname" runat="server" Width="98px"></asp:TextBox>&nbsp;&nbsp;
        &nbsp; &nbsp;
        <asp:Label ID="Label4" runat="server" Text="hệ số" Width="39px"></asp:Label>
        &nbsp;
        <asp:TextBox ID="Subject_addhs" runat="server" Width="24px"></asp:TextBox>
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Thêm vào" Width="86px" /><br />
        &nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;
        <asp:Label ID="Add_sub_result" runat="server" ForeColor="Red" Width="278px"></asp:Label>
    </form>
</body>
</html>
