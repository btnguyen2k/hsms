<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="People.aspx.cs" Inherits="HSMS.People" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
    
        <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="Blue" Text="DANH SÁCH CÁN BỘ - GIÁO VIÊN  CÔNG NHÂN VIÊN CỦA TRƯỜNG"
            Width="380px"></asp:Label>        
        </center>
        <center>
            &nbsp;</center>
        <center>
        <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="BAN GIÁM HIỆU"></asp:Label>
        <table width="520" border="1">
            <tr>
                <th colspan="3" scope="col"><p class="style2">HIỆU TRƯỞNG</p>      
                <blockquote>
                <div align="left">
                    <p><em>&Ocirc;ng </em><strong>NG&Ocirc; HUYNH</strong><br />
                    <em>N&#259;m Sinh :</em> <strong>1952 </strong><br />
                    <em>N&#417;i Sinh : </em><strong>Qu&#7843;ng Nam </strong><br />
                    <em>&#272;&#7883;a ch&#7881; : </em><strong>557/H 13 Nguy&#7877;n Tri Ph&#432;&#417;ng, P.14, Q.10   TP.HCM</strong></p>
                </div>
                </blockquote></th>
            </tr>
            <tr>
                <td width="260"><p><strong class="style2">PH&Oacute; HI&#7878;U TR&#431;&#7902;NG 
                        CHUY&Ecirc;N M&Ocirc;N</strong></p><p><br /><p>
                    <em>&Ocirc;ng </em>&nbsp;<strong>L&ecirc; Duy T&acirc;n </strong><br />
                    <em>N&#259;m sinh : </em><strong>1964 </strong><br />
                    <em>N&#417;i Sinh : </em><strong>TP. H&#7891; Ch&iacute; Minh </strong><br />
                    <em>&#272;&#7883;a ch&#7881;   :</em> <strong>83 &#273;&#432;&#7901;ng 16, khu ph&#7889; 3, Hi&#7879;p   B&igrave;nh Ch&aacute;nh, Q.Th&#7911; &#272;&#7913;c TP.HCM </strong></p></td>
                <td width="234"><p><strong class="style2">PH&Oacute; HI&#7878;U TR&#431;&#7902;NG
                        C&#416; S&#7902; V&#7852;T CH&#7844;T</strong><br /></p><p>
                    <em>B&agrave; </em><strong>Nguy&#7877;n Th&#7883; Thu Ba </strong><br />
                    <em>N&#259;m sinh :</em> <strong>1959 </strong><br />
                    <em>N&#417;i Sinh :</em> <strong>H&#7843;i Ph&ograve;ng </strong><br />
                    <em>&#272;&#7883;a ch&#7881;:</em> <strong>79/62   Ph&#7841;m Vi&#7871;t Ch&aacute;nh, P.19,Q. B&igrave;nh Th&#7841;nh TP.HCM</strong> </p></td>
                <td width="4">&nbsp;</td>
            </tr>
        </table>
    
        </center>
    </div>
        <br />
        <center>
        <asp:Label ID="Label3" runat="server" Text="DANH SÁCH GIÁO VIÊN" ForeColor="Red"></asp:Label>
            &nbsp; &nbsp;
            <asp:DropDownList ID="SubjectList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SubjectList_SelectedIndexChanged">
            </asp:DropDownList></center>
        <center>
            <asp:Label ID="TeacherTable" runat="server" Width="638px"></asp:Label>&nbsp;</center>
        <center>
            <asp:Label ID="Label4" runat="server" ForeColor="Blue" Width="249px"></asp:Label>&nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="CHI TIẾT" Visible="False"
                Width="74px"></asp:Label>&nbsp;</center>
        <center>
            <asp:Label ID="SubjectDetail" runat="server" Width="335px"></asp:Label>&nbsp;</center>
    </form>
</body>
</html>
