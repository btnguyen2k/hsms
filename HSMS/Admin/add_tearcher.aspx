<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_tearcher.aspx.cs" Inherits="HSMS.Admin.add_tearcher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Font-Size="XX-Large" ForeColor="Red"
            Text="THÊM GIÁO VIÊN MỚI"></asp:Label>
  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <br />
        <br />
        <br />
        <br />
  
  <table border="1" id="Information" align="left" runat="server" style="width: 545px">
	<tr>
		<td style="width: 140px" >&nbsp;Họ và tên :</td>
		<td style="width: 75px" >		
			<input type="text" runat="server" name="T1" size="20" id="Teacher_name"/>		
		</td>
	</tr>
	<tr>
		<td style="width: 140px" >&nbsp;Ngày tháng năm sinh :</td>
		<td style="width: 75px" >
		    <table border="1" width="100%" id="table2" runat="server">
			    <tr>
				    <td>
					    <input type="text" name="T6" runat="server" style="width: 30px" id="Teacher_Day"/>				
				    </td>
				    <td>
					    <input type="text" name="T7" style="width: 30px" runat="server" id="Teacher_Month"/>							
				    </td>
				    <td>				
					    <input type="text" name="T8" style="width: 60px" runat="server" id="Teacher_Year"/>				
				    </td>
			    </tr>
		    </table>
        </td>
	</tr>
	<tr>
		<td style="width: 140px">
            Năm băt đầu giảng dạy :</td>
		<td style="width: 75px">
			<input type="text" name="T2" style="width: 60px" runat="server" id="Teacher_YearStart"/>		
		</td>
	</tr>
	<tr>
		<td style="width: 140px">
            Dạy môn học :</td>
		<td style="width: 75px">
			<input type="text" name="T3" style="width: 96px" runat="server" id="Teacher_Subject"/>
		</td>
	</tr>
	<tr>
		<td style="width: 140px">Chủ nhiệm lớp :</td>
		<td style="width: 75px">
			<input type="text" name="T4" style="width: 95px" runat="server" id="Teacher_MainClass" />
		</td>
	</tr>
	<tr>
		<td style="width: 140px">
            Mã số giáo viên :</td>
		<td style="width: 75px">
			<input type="text" name="T2" style="width: 60px" runat="server" id="Teacher_id"/>		
		</td>
	</tr>
	<tr>
		<td style="width: 140px">&nbsp;Email :
        </td>
		<td style="width: 75px">
			<input type="text" name="T5" size="20" runat="server" id="Teacher_Email"/>
		</td>
	</tr>
</table>
    
    </div>
    </form>
</body>
</html>
