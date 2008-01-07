<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailEditExercise.aspx.cs" Inherits="HSMS.Teacher.DetailEditExercise" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label ID="Label" runat="server" Text="Tiêu đề: " Width="102px"></asp:Label><asp:TextBox
                ID="ExTitle" runat="server" Width="229px"></asp:TextBox><br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Ghi chú" Width="102px"></asp:Label><br />
            <ftb:freetextbox id="FreeTextBox1" runat="server"></ftb:freetextbox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Hình đính kèm:" Width="102px"></asp:Label><asp:FileUpload
                ID="ImageUpLoad" runat="server" /><br />
            <asp:Label ID="Label3" runat="server" Text="File đính kèm: " Width="102px"></asp:Label><asp:FileUpload
                ID="FileUpLoad1" runat="server" /><br />
            <br />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:Button ID="AddNewEx" runat="server" OnClick="AddNewEx_Click"
                Text="Cập nhật bài tập" /><br />
            <asp:Label ID="Result" runat="server" ForeColor="Red" Width="597px"></asp:Label></div>
    
    </div>
    </form>
</body>
</html>
