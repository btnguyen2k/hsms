<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Searching.aspx.cs" Inherits="HSMS.Searching" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
        <asp:Label ID="Label1" runat="server" ForeColor="Blue" Text="TÌM KIẾM THÔNG TIN"
            Width="169px"></asp:Label><br />
        <br />       
        <asp:Label ID="Label2" runat="server" Text="Thông tin cần tìm:" Width="106px"></asp:Label><br />        
        <asp:TextBox ID="InputText" runat="server" Width="189px"></asp:TextBox>        <br />
        <asp:Label ID="Label3" runat="server"
            ForeColor="#80FF80" Text="(vd: Nguyễn Bá Tân)" Width="127px"></asp:Label></center>
        <center>
        <asp:Button ID="StartSearch" runat="server" OnClick="StartSearch_Click" Text="Tìm"
            Width="90px" /><br />
        
        <br />        
        <asp:Label ID="Label4" runat="server" ForeColor="Blue" Text="KẾT QUẢ TÌM KIẾM" Visible="False"></asp:Label>        
        <br />        
        <asp:Label ID="Result" runat="server" Width="497px"></asp:Label><br />        
        </center>
        </div>
    </form>
</body>
</html>
