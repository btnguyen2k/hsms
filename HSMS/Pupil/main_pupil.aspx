<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main_pupil.aspx.cs" Inherits="HSMS.Pupil.main_pupil" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Pupil page</title>
     <script language="javascript" type="text/javascript">
    if ( top != self ) {
        top.location.href = self.location.href;
    }
    </script>
</head>
<frameset rows="20%, *">    
    <frame frameborder = "0" noresize name = "title_pupil" src = "title_pupil.aspx">     
    <frameset cols="20%, *">
     <frame frameborder = "0" noresize name = "function_pupil" src = "function_pupil.aspx">
     <frame frameborder = "0" noresize name = "content_pupil" src = "content_pupil.aspx">
    </frameset>
</frameset>
</html>
