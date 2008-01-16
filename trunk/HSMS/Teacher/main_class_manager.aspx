<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main_class_manager.aspx.cs" Inherits="HSMS.Teacher.main_class_manager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
        <asp:Label ID="Label3" runat="server" Font-Size="X-Large" ForeColor="Blue" Text="TỞNG KẾT LỚP"></asp:Label>&nbsp;</center>
        <center>
            <br />
        <asp:Label ID="Label1" runat="server" Text="Lớp:" Width="45px"></asp:Label>
        &nbsp; &nbsp;&nbsp;<asp:DropDownList ID="ClassName" runat="server">
        </asp:DropDownList>
            &nbsp;
        <asp:Label ID="Label2" runat="server" Text="Năm:" Width="60px"></asp:Label><asp:TextBox ID="ClassYear" runat="server" Width="44px"></asp:TextBox><br />
        <br />
        <asp:Button ID="ConfirmClassList" runat="server" OnClick="ConfirmClassList_Click"
            Text="Xác nhận" Width="121px" /><br />
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
        <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" NavigateUrl="~/Teacher/main_class_manager.aspx"
            Target="content_teacher" Width="56px">Quay lại</asp:HyperLink>
        </center>
    </div>
    </form>
</body>
</html>
