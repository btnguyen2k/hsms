<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tablescore_add.aspx.cs" Inherits="HSMS.Teacher.tablescore_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
        <asp:Label ID="NoticeView" runat="server" Width="666px" Font-Size="X-Large" ForeColor="Red">NHẬP ĐIỂM CHO MỘT LỚP HỌC</asp:Label><br />
        <br />       
        <asp:Label ID="Label1" runat="server" Text="Lớp:" Width="50px"></asp:Label>&nbsp;&nbsp;<asp:DropDownList
            ID="ClassName" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp;
        
        <asp:Label ID="Label2" runat="server" Text="Năm:" Width="44px"></asp:Label>
        <asp:TextBox ID="ClassYear" runat="server" Width="80px"></asp:TextBox>
        &nbsp;
        <asp:Button ID="Confirm_ClassName_Year" runat="server" Text="Xác nhận" OnClick="Confirm_ClassName_Year_Click" /></center>
        <center>
        <asp:RadioButtonList
            ID="HK_Select" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True">HK I</asp:ListItem>
            <asp:ListItem>HK II</asp:ListItem>
        </asp:RadioButtonList><br />        
        <asp:Label ID="ResultScore" runat="server"></asp:Label>
        </center>
        <asp:Label ID="ResultScoreText" runat="server" ForeColor="Red" Width="698px"></asp:Label><br />
        <center>
        
        <asp:Button ID="Save_ScoreTable" runat="server" Text="Lưu" Width="102px" Visible="False" OnClick="Save_ScoreTable_Click" />        
        <asp:Button ID="Calculate_TBM" runat="server" Text="Tính tổng kết TBM" Width="144px" Visible="False" OnClick="Calculate_TBM_Click" Enabled="False" /><br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" NavigateUrl="~/Teacher/tablescore_add.aspx"
            Target="content_teacher" Width="59px">Quay lại</asp:HyperLink></center>
    </div>
    </form>
</body>
</html>
