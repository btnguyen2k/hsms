<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="HSMS.Admin.AddNews" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Create News</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label" runat="server" Text="Tiêu đề: "
            Width="102px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="NewTitle" runat="server" Width="229px" ></asp:TextBox><br />
        <br />
        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label1" runat="server" Text="Hình đính kèm:"
            Width="102px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <asp:FileUpLoad id="ImageUpLoad" runat="server" />
        <br />
        <br />
        <br />
        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label2" runat="server" Text="Nội dung: "
            Width="102px"></asp:Label> <br />
        <FTB:FreeTextBox id="FreeTextBox1" runat="server" />
        <br />
        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label3" runat="server" Text="File đính kèm: "
            Width="102px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:FileUpLoad id="FileUpLoad1" runat="server" />
        <br />
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button runat="server" id="NewSave" Text="Lưu" OnClick="NewSave_Click" Width="141px" />
        <br />
        <asp:Label ID="ResultAction" runat="server" ForeColor="Red" Width="602px"></asp:Label></div>
    </form>
</body>
</html>
