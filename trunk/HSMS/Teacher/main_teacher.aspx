<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main_teacher.aspx.cs" Inherits="HSMS.Teacher.main_teacher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Main Teacher</title>
    <script language="javascript" type="text/javascript">
    if ( top != self ) {
        top.location.href = self.location.href;
    }
    </script>
</head>
<frameset rows="20%, *">    
    <frame frameborder = "0" noresize name = "title_teacher" src = "title_teacher.aspx">     
    <frameset cols="20%, *">
     <frame frameborder = "0" noresize name = "function_teacher" src = "function_teacher.aspx">
     <frame frameborder = "0" noresize name = "content_teacher" src = "content_teacher.aspx">
    </frameset>
</frameset>
</html>
