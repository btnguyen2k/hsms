<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="HSMS.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>

<frameset rows="30%, *">    
    <frame frameborder = "0" noresize name = "tittle" src = "Tittle.aspx">
     </body>
    <frameset cols="15%, *">
     <frame frameborder = "0" noresize name = "function" src = "function.aspx">
     <frame frameborder = "0" noresize name = "content" src = "content.aspx">
    </frameset>
</frameset>
</html>
