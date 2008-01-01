<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditFTB.aspx.cs" Inherits="HSMS.EditFTB" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <FTB:FreeTextBox id="FreeTextBox1" runat="server" />
   <br />
   <asp:Button runat="server" id="find" Text="find" OnClick="find_Click"  />

    </div>
    </form>
</body>
</html>
