<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main_admin.aspx.cs" Inherits="HSMS.Admin.main_admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Admin Site</title>
    <script language="javascript" type="text/javascript">
    if ( top != self ) {
        top.location.href = self.location.href;
    }
    </script>
</head>
<frameset rows="17%, *">    
    <frame frameborder = "0" noresize name = "title_admin" src = "title_admin.aspx">     
    <frameset cols="20%, *">
     <frame frameborder = "0" noresize name = "function_admin" src = "function_admin.aspx">
     <frame frameborder = "0" noresize name = "content_admin" src = "content_admin.aspx">
    </frameset>
</frameset>
</html>
