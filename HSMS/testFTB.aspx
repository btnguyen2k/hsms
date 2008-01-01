<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testFTB.aspx.cs" Inherits="HSMS.testFTB" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label" runat="server" Text="Tiêu đề: "
            Width="102px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="title" runat="server" Width="229px" ></asp:TextBox><br />
        <br />
    <FTB:FreeTextBox id="FreeTextBox1" runat="server" />
   <br />
   <asp:FileUpLoad id="FileUpLoad1" runat="server" />
   <br />
   <asp:Button runat="server" id="btnSave" Text="Save" OnClick="btnSave_Click" />

    </div>
    </form>
</body>
</html>
