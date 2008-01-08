<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tablescore_add.aspx.cs" Inherits="HSMS.Teacher.tablescore_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="NoticeView" runat="server" Width="666px"></asp:Label><br />
        <br />
        &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp; &nbsp;
        <asp:Label ID="Label1" runat="server" Text="Lớp:" Width="50px"></asp:Label>&nbsp;
        <asp:TextBox ID="ClassName" runat="server" Width="96px"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Label2" runat="server" Text="Năm:" Width="44px"></asp:Label>
        <asp:TextBox ID="ClassYear" runat="server" Width="80px"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Button ID="Confirm_ClassName_Year" runat="server" Text="Xác nhận" OnClick="Confirm_ClassName_Year_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="View_ClassTeaching" runat="server" Text="Danh sách lớp"
            Width="159px" OnClick="View_ClassTeaching_Click" /><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 
        <br />
        <br />
        &nbsp;<asp:Label ID="ResultContent" runat="server" ForeColor="Red" Width="512px"></asp:Label><br />
        <br />
        <br />
        &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;<asp:Label ID="Label3" runat="server" Text="Môn học:" Width="75px" Visible="False"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="SubjectName" runat="server" Width="85px" Visible="False"></asp:TextBox>
        &nbsp;
        <asp:Button ID="Confirm_ClassSubject" runat="server" Text="Xác nhận" Width="88px" OnClick="Confirm_ClassSubject_Click" Visible="False" />
        &nbsp; &nbsp;&nbsp;
        <asp:Button ID="SubjectList" runat="server" Text="Danh sách môn học" Width="121px" OnClick="SubjectList_Click" Visible="False" />&nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:RadioButtonList
            align="center" ID="HK_Select" runat="server" RepeatDirection="Horizontal" Visible="False">
            <asp:ListItem Selected="True">HK I</asp:ListItem>
            <asp:ListItem>HK II</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label ID="ResultAction" runat="server" ForeColor="Red" Width="628px"></asp:Label><br />
        <asp:Label ID="ResultScore" runat="server" Width="633px"></asp:Label></div>
        <asp:Label ID="ResultScoreText" runat="server" ForeColor="Red" Width="529px"></asp:Label><br />
        &nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;<asp:Button ID="Save_ScoreTable" runat="server" Text="Lưu" Width="102px" Visible="False" OnClick="Save_ScoreTable_Click" />
        &nbsp; &nbsp;&nbsp;
        <asp:Button ID="Calculate_TBM" runat="server" Text="Tính tổng kết TBM" Width="144px" Visible="False" OnClick="Calculate_TBM_Click" Enabled="False" />
        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
    </form>
</body>
</html>
