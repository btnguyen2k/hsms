﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_del_teacher.aspx.cs" Inherits="HSMS.Admin.edit_del_teacher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
        
        <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Font-Size="XX-Large" ForeColor="Red"
            Text="THÔNG TIN GIÁO VIÊN"></asp:Label>&nbsp;</center>
        <center>
            <br />        
        <asp:Label ID="Label2" runat="server" Text="Mã số giáo viên :"></asp:Label>
        <asp:DropDownList ID="Teacher_FindId" runat="server">
        </asp:DropDownList>
            &nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="bộ môn" Width="52px"></asp:Label>
        <asp:DropDownList ID="SubjectList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SubjectList_SelectedIndexChanged">
        </asp:DropDownList>
            &nbsp; &nbsp;<asp:Button ID="Find_Teacher" runat="server" Text="Tìm kiếm" OnClick="Find_Teacher_Click" />
        <asp:Label ID="TeacherFindResultText" runat="server" ForeColor="Red" Width="386px"></asp:Label><br />
        
        <asp:Label ID="Label4" runat="server" ForeColor="Blue" Text="THÔNG TIN CHUNG" Visible="False"></asp:Label><br />
 
 <table border="1" id="Information" align=center runat="server" style="width: 435px">
	<tr>
		<td style="width: 180px" >&nbsp;Họ và tên :</td>
		<td style="width: 74px" >		
			<input type="text" runat="server" name="T1" size="20" id="Teacher_name"/>		
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
			<input type="text" name="T2" style="width: 60px" runat="server" id="Teacher_id" readonly="readOnly"/>		
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
        </center>
        <center>
            &nbsp;</center>
        <center>
        <asp:Label ID="Label5" runat="server" ForeColor="Blue" Text="THÔNG TIN THÊM" Visible="False"
            Width="229px"></asp:Label><br />
        <asp:Label ID="Label3" runat="server" Text="Chức vụ:" Width="69px" Visible="False"></asp:Label>
        <asp:TextBox ID="Position" runat="server" Width="367px" Visible="False"></asp:TextBox><br />
        <asp:Label ID="Label15" runat="server" Text="Tiểu sử công tác:" Width="110px" Visible="False"></asp:Label><br />
        <asp:TextBox ID="HistoryTeacher" runat="server" Height="126px" TextMode="MultiLine"
            Width="445px" Visible="False"></asp:TextBox><br />
        <asp:Button ID="Teacher_DelInf" runat="server"
            OnClick="Teacher_DelInf_Click" Text="Xoá" Width="90px" />
        <asp:Button
            ID="Teacher_EditInf" runat="server" Text="Cập nhật mới" OnClick="Teacher_EditInf_Click" /><br />
        <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" NavigateUrl="~/Admin/edit_del_teacher.aspx"
            Target="content_admin" Visible="False" Width="68px">Quay lại</asp:HyperLink><br />
        <asp:Label ID="Teacher_EditResult" runat="server" ForeColor="Red" Width="491px"></asp:Label>
        </center>
    </div>
    </form>
</body>
</html>
