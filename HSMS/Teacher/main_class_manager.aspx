<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main_class_manager.aspx.cs" Inherits="HSMS.Teacher.main_class_manager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Lớp:" Width="45px"></asp:Label>
        &nbsp; &nbsp; &nbsp;<asp:TextBox ID="ClassName" runat="server" OnTextChanged="ClassName_TextChanged"
            Width="95px"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Năm:" Width="60px"></asp:Label>&nbsp;
        <asp:TextBox ID="ClassYear" runat="server" Width="56px"></asp:TextBox><br />
        <br />
        <asp:Button ID="ConfirmClassList" runat="server" OnClick="ConfirmClassList_Click"
            Text="Xác nhận" Width="121px" />
        &nbsp; &nbsp;
        <asp:Button ID="ViewClassList" runat="server" OnClick="ViewClassList_Click" Text="Danh sách các lớp chủ nhiệm"
            Width="223px" /><br />
        <asp:Label ID="ResultContent" runat="server" ForeColor="Red" Width="522px"></asp:Label>
        <br />
        <br />
        <asp:Table ID="ClassListTable" runat="server" BorderStyle="Solid" GridLines="Both" Visible="False"
            Width="783px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Center">STT</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">Họ và Tên</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">MSHS</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">TB HKI</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">Đạo đức</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">Xếp loại</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">TBHK II</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">Đạo đức</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">Xếp loại</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">TB cả năm</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">Đạo đức</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center">Xếp loại cả năm</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
