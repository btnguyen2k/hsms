<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailExercise.aspx.cs" Inherits="HSMS.Pupil.DetaiExercisel"  ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label" runat="server" Text="Tiêu đề: " Width="102px"></asp:Label><asp:TextBox
            ID="ExTitle" runat="server" Width="229px"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label2" runat="server"
                Text="Ghi chú" Width="102px"></asp:Label><ftb:freetextbox id="FreeTextBox1" runat="server"></ftb:freetextbox>
        &nbsp;</div>
        <br />
        <asp:Label ID="ImageEx" runat="server" Width="598px"></asp:Label>
        <br />
        <asp:Label ID="FileEx" runat="server" Width="596px"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="File đính kèm: " Width="102px"></asp:Label><asp:FileUpload
            ID="FileUpLoad1" runat="server" /><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;<asp:Button ID="Submit" runat="server" OnClick="Submit_Click"
            Text="Gởi bài giải" Width="187px" />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <br />
        <asp:Label ID="Result" runat="server" ForeColor="Red" Width="597px"></asp:Label>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" NavigateUrl="~/Pupil/Exercise.aspx"
            Target="content_pupil" Width="61px">Quay lại</asp:HyperLink>
    </form>
</body>
</html>
