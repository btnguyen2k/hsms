<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_del_pupil.aspx.cs" Inherits="HSMS.Admin.del_pupil" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Font-Size="XX-Large" ForeColor="Red"
            Text="THÔNG TIN HỌC SINH" Width="379px"></asp:Label><br />
        <br />
        &nbsp;<br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label2" runat="server" Text="Mã số học sinh : " Width="107px"></asp:Label>
        <asp:TextBox ID="Find_Pupil_id" runat="server" Width="130px"></asp:TextBox>
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="FindPupil" runat="server" Text="Tìm kiếm" Width="116px" OnClick="FinPupil_Click" /><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Find_Result" runat="server" Font-Names="Verdana" ForeColor="Red" Width="329px"></asp:Label><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Edit_Result" runat="server" ForeColor="Red" Width="248px"></asp:Label><br />
        &nbsp;&nbsp;
    <table border="1" id="Information" align="left" runat="server">
	<tr>
		<td style="width: 140px" >&nbsp;Họ và tên :</td>
		<td style="width: 83px" >		
			<input type="text" runat="server" name="T1" size="20" id="Name_Find">		
		</td>
	</tr>
	<tr>
		<td style="width: 140px" >&nbsp;Ngày tháng năm sinh :</td>
		<td style="width: 83px" >
		    <table border="1" width="100%" id="table2" runat="server">
			    <tr>
				    <td>
					    <input type="text" name="T6" runat="server" style="width: 30px" id="Day_Find">				
				    </td>
				    <td>
					    <input type="text" name="T7" style="width: 30px" runat="server" id="Month_Find">							
				    </td>
				    <td>				
					    <input type="text" name="T8" style="width: 60px" runat="server" id="Year_Find">				
				    </td>
			    </tr>
		    </table>
        </td>
	</tr>
	<tr>
		<td style="width: 140px">
            Năm nhập học :</td>
		<td style="width: 83px">
			<input type="text" name="T2" style="width: 60px" runat="server" id="EnrollYear_Find">		
		</td>
	</tr>
	<tr>
		<td style="width: 140px">
            Theo học lớp</td>
		<td style="width: 83px">
			<input type="text" name="T3" style="width: 96px" runat="server" id="Classid_find">
		</td>
	</tr>
	<tr>
		<td style="width: 140px">&nbsp;Mã số học sinh :</td>
		<td style="width: 83px">
			<input type="text" name="T4" style="width: 95px" runat="server" id="PupilId_Find" readonly="readOnly">
		</td>
	</tr>
	<tr>
		<td style="width: 140px">&nbsp;Email :
        </td>
		<td style="width: 83px">
			<input type="text" name="T5" size="20" runat="server" id="Email_Find">
		</td>
	</tr>
</table>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <br />
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Button ID="Del_Inf" runat="server" OnClick="Del_Inf_Click" Text="Xoá thông tin"
            Width="91px" /><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Button ID="Change_inf" runat="server" OnClick="Change_inf_Click" Text="Sữa"
            Width="93px" /><br />
        <br />
        <br />
        &nbsp;
    
    </div>
    </form>
</body>
</html>
