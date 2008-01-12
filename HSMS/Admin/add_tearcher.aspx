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
            Text="THÊM GIÁO VIÊN MỚI"></asp:Label><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 
        <asp:Label ID="Label2" runat="server" ForeColor="Blue" Text="THÔNG TIN CHUNG" Width="152px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
  
  <table border="1" id="Information" align="left" runat="server" >
	<tr>
		<td style="width: 180px" >&nbsp;Họ và tên :</td>
		<td style="width: 74px" >		
			<input type="text" runat="server" name="T1" id="Teacher_name" style="width: 185px"/>		
		</td>
	</tr>
	<tr>
		<td style="width: 180px" >&nbsp;Ngày tháng năm sinh :</td>
		<td style="width: 74px" >
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
		<td style="width: 180px">
            Năm băt đầu giảng dạy :</td>
		<td style="width: 74px">
			<input type="text" name="T2" style="width: 60px" runat="server" id="Teacher_YearStart"/>		
		</td>
	</tr>
	<tr>
		<td style="width: 180px">
            Dạy môn học :</td>
		<td style="width: 74px">
			<input type="text" name="T3" style="width: 96px" runat="server" id="Teacher_Subject"/>
		</td>
	</tr>
	<tr>
		<td style="width: 180px">Chủ nhiệm lớp :</td>
		<td style="width: 74px">
			<input type="text" name="T4" style="width: 95px" runat="server" id="Teacher_MainClass" />
		</td>
	</tr>
	<tr>
		<td style="width: 180px">Năm học:</td>
		<td style="width: 74px">
			<input type="text" name="T4" style="width: 95px" runat="server" id="Teacher_MainClass_Year" />
		</td>
	</tr>
	<tr>
		<td style="width: 180px">
            Mã số giáo viên :</td>
		<td style="width: 74px">
			<input type="text" name="T2" style="width: 60px" runat="server" id="Teacher_id"/>		
		</td>
	</tr>
	<tr>
		<td style="width: 180px">&nbsp;Email :
        </td>
		<td style="width: 74px">
			<input type="text" name="T5" size="20" runat="server" id="Teacher_Email"/>
		</td>
	</tr>
</table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label3" runat="server" ForeColor="Blue" Text="THÔNG TIN THÊM"
            Width="155px"></asp:Label><br />
        <asp:Label ID="Label4" runat="server" Text="Chức vụ:" Width="64px"></asp:Label>
        <asp:TextBox ID="Position" runat="server" Width="313px"></asp:TextBox><br />
        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <br />
        <asp:Label ID="Label15" runat="server" Text="Tiểu sử công tác:" Width="110px"></asp:Label><br />
        <asp:TextBox ID="HistoryTeacher" runat="server" Height="126px" TextMode="MultiLine" Width="445px"></asp:TextBox><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Button ID="Add_Teacher" runat="server" OnClick="Add_Teacher_Click" Text="Thêm giáo viên mới" />&nbsp;
        <asp:Button ID="ViewClassList" runat="server" OnClick="ViewClassList_Click" Text="Danh sách lớp"
            Width="103px" />&nbsp;<asp:Button ID="ViewSubjectList" runat="server" OnClick="ViewSubjectList_Click"
                Text="Danh sách môn hoc" /><br />
        &nbsp;&nbsp;<br />
        &nbsp;<asp:Label ID="Add_Result" runat="server" ForeColor="Red" Width="455px"></asp:Label></div>
    </form>
</body>
</html>
