<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showthongtin.aspx.cs" Inherits="HSMS.TEST.showthongtin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Test_title" runat="server" ></asp:Label>
    <br />
    <br />
    <asp:Label ID="Test_content" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="File_Upload" runat="server"></asp:Label>
    <br />
    <asp:Image ID="image_upload" runat="server" />
        
    </div>
    </form>
</body>
</html>
