<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Track_learning.aspx.cs" Inherits="HSMS.Teacher.Track_learning" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Notice" runat="server" Width="674px"></asp:Label><br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Lớp :" Width="55px"></asp:Label>&nbsp;
        <asp:DropDownList ID="ClassName" runat="server">
        </asp:DropDownList><br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Năm" Width="51px"></asp:Label>&nbsp;
        &nbsp;<asp:TextBox ID="ClassYear" runat="server" Width="99px"></asp:TextBox><br />
        <br />
        <asp:Button ID="Check_Class" runat="server" OnClick="Check_Class_Click" Text="Xác nhận" />&nbsp;
        <asp:Button ID="ViewClassList" runat="server" OnClick="ViewClassList_Click" Text="Danh Sách Lớp"
            Width="131px" /><br />
        <asp:Label ID="ResultContent" runat="server" ForeColor="Red" Width="425px"></asp:Label><br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="MSHS" Visible="False" Width="79px"></asp:Label>
        <asp:TextBox ID="mshs" runat="server" Visible="False" Width="84px"></asp:TextBox><br />
        <br />
        <asp:RadioButtonList ID="HK_Select" runat="server" RepeatDirection="Horizontal" Visible="False">
            <asp:ListItem Selected="True">HK I</asp:ListItem>
            <asp:ListItem>HK II </asp:ListItem>
        </asp:RadioButtonList><br />
        <br />
        <asp:Button ID="Check_id" runat="server" OnClick="Check_id_Click" Text="Xác nhận"
            Visible="False" />&nbsp;<asp:Button ID="ViewPupilList" runat="server" OnClick="ViewPupilList_Click"
                Text="Danh sách học sinh" Visible="False" Width="137px" /><br />
        <br />
        <asp:Label ID="ResultTracking" runat="server" ForeColor="Red" Width="559px"></asp:Label><br />
        <br />
        <asp:TextBox ID="Content" runat="server" BorderColor="Black" BorderStyle="Double"
            Height="103px" TextMode="MultiLine" Visible="False" Width="566px"></asp:TextBox><br />
        <asp:Label ID="AddResult" runat="server" ForeColor="Red" Width="566px"></asp:Label><br />
        <br />
        <asp:Button ID="AddContent" runat="server" OnClick="AddContent_Click" Text="Thêm vào"
            Visible="False" Width="142px" />&nbsp;<br />
        <br />
        <asp:Button ID="ChangePupil" runat="server" OnClick="ChangePupil_Click" Text="Chọn học sinh khác"
            Visible="False" Width="233px" />&nbsp;<asp:Button ID="ChangeClass" runat="server"
                OnClick="ChangeClass_Click" Text="Chọn lớp khác" Visible="False" Width="232px" /></div>
    </form>
</body>
</html>
