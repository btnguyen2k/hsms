<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacher_scheduling.aspx.cs" Inherits="HSMS.Admin.teacher_scheduling" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    
       <center>
        <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Font-Size="XX-Large" ForeColor="Red"
            Text="LỊCH CÔNG TÁC" Width="264px"></asp:Label><br />
        <br />
       
        <asp:Label ID="Label2" runat="server" Text="Mã số giáo viên :" Width="110px"></asp:Label>
       <asp:DropDownList ID="Teacher_FindId" runat="server">
        </asp:DropDownList>
           &nbsp;&nbsp; &nbsp;<asp:Label ID="Label3" runat="server" Text="bộ môn"></asp:Label>
           &nbsp;&nbsp; &nbsp;<asp:DropDownList ID="SubjectList" runat="server" AutoPostBack="True"
            OnSelectedIndexChanged="SubjectList_SelectedIndexChanged">
        </asp:DropDownList>
        </center>
        <center>
        <asp:Button ID="Teacher_Finding" runat="server" OnClick="Teacher_Finding_Click" Text="Tìm"
            Width="107px" />
        <br />
        <br />
        
        <asp:Label ID="Finding_result" runat="server" ForeColor="Red" Width="453px"></asp:Label>
        <br />
        <br />       
  <table border="1" id="schedule" runat="server" >
	<tr>
		<td align = "center" nowrap="nowrap">Ti&#7871;t\Th&#7913; </td>
		<td  align = "center">2 </td>
		<td  align = "center">3 </td>
		<td  align = "center">4 </td>
		<td  align = "center">5 </td>
		<td  align = "center">6 </td>
		<td align = "center" >7 </td>
	</tr>
	<tr>
		<td nowrap="nowrap">1(6h45-7h30) </td>
		<td >
		   <input id="T21" type="text" name="T21" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T31" type="text" name="T3" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T41" type="text" name="T41" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T51" type="text" name="T51" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T61" type="text" name="T61" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T71" type="text" name="T71" style="width:45px" runat = "server"/>		
		</td>		
	</tr>
	<tr>
		<td nowrap="nowrap">2(7h30-8h15)</td>
		<td >
		   <input id="T22" type="text" name="T22" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T32" type="text" name="T32" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T42" type="text" name="T42" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T52" type="text" name="T52" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T62" type="text" name="T62" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T72" type="text" name="T72" style="width:45px" runat = "server"/>		
		</td>		
	</tr>
	<tr>
		<td nowrap="nowrap">3(8h30-9h15)</td>
		<td  >
		   <input id="T23" type="text" name="T23" style="width:45px" runat = "server"/>		
		</td>
		<td  >
		   <input id="T33" type="text" name="T33" style="width:45px" runat = "server"/>		
		</td>
		<td  >
		   <input id="T43" type="text" name="T43" style="width:45px" runat = "server"/>		
		</td>
		<td  >
		   <input id="T53" type="text" name="T53" style="width:45px" runat = "server"/>		
		</td>
		<td  >
		   <input id="T63" type="text" name="T63" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T73" type="text" name="T73" style="width:45px" runat = "server"/>		
		</td>		
	</tr>
	<tr>
        <td nowrap="nowrap">4(9h15-10h)</td>
		<td  >
		   <input id="T24" type="text" name="T24" style="width:45px" runat = "server"/>		
		</td>
		<td  >
		   <input id="T34" type="text" name="T34" style="width:45px" runat = "server"/>		
		</td>
		<td  >
		   <input id="T44" type="text" name="T44" style="width:45px" runat = "server"/>		
		</td>
		<td  >
		   <input id="T54" type="text" name="T54" style="width:45px" runat = "server"/>		
		</td>
		<td  >
		   <input id="T64" type="text" name="T64" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T74" type="text" name="T74" style="width:45px" runat = "server"/>		
		</td>		
	</tr>
	<tr>
		<td nowrap="nowrap">5(10h15-11h)</td>
		<td >
		   <input id="T25" type="text" name="T25" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T35" type="text" name="T35" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T45" type="text" name="T45" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T55" type="text" name="T55" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T65" type="text" name="T65" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T75" type="text" name="T75" style="width:45px" runat = "server"/>		
		</td>		
	</tr>
	<tr>
		<td nowrap="nowrap">6(12h45-13h30)</td>
		<td >
		   <input id="T26" type="text" name="T26" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T36" type="text" name="T36" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T46" type="text" name="T46" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T56" type="text" name="T56" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T66" type="text" name="T66" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T76" type="text" name="T76" style="width:45px" runat = "server"/>		
		</td>		
	</tr>
	<tr>
		<td nowrap="nowrap">7(13h30-14h15)</td>
		<td >
		   <input id="T27" type="text" name="T27" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T37" type="text" name="T37" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T47" type="text" name="T47" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T57" type="text" name="T57" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T67" type="text" name="T67" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T77" type="text" name="T77" style="width:45px" runat = "server"/>		
		</td>		
	</tr>
	<tr>
		<td nowrap="nowrap">8(14h30-15h15)</td>
		<td >
		   <input id="T28" type="text" name="T28" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T38" type="text" name="T38" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T48" type="text" name="T48" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T58" type="text" name="T58" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T68" type="text" name="T68" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T78" type="text" name="T78" style="width:45px" runat = "server"/>		
		</td>		
	</tr>
	<tr>
		<td nowrap="nowrap">9(15h15-16h)</td>
		<td >
		   <input id="T29" type="text" name="T29" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T39" type="text" name="T39" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T49" type="text" name="T49" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T59" type="text" name="T59" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T69" type="text" name="T69" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T79" type="text" name="T79" style="width:45px" runat = "server"/>		
		</td>		
	</tr>
	<tr>
		<td nowrap="nowrap">10(16h15-17h)</td>
		<td >
		   <input id="T210" type="text" name="T210" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T310" type="text" name="T310" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T410" type="text" name="T410" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T510" type="text" name="T510" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T610" type="text" name="T610" style="width:45px" runat = "server"/>		
		</td>
		<td >
		   <input id="T710" type="text" name="T710" style="width:45px" runat = "server"/>		
		</td>		
	</tr>
</table> 
   
        <asp:Button ID="Teacher_AddSchedule" runat="server" Text="Thêm" OnClick="Teacher_AddSchedule_Click" Width="86px" />
        <asp:Button ID="Teacher_EditSchedule" runat="server" Text="Sữa" Width="84px" OnClick="Teacher_EditSchedule_Click" />    
        </center>
        <center>
            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" NavigateUrl="~/Admin/teacher_scheduling.aspx"
                Target="content_teacher" Width="66px">Quay lại</asp:HyperLink><br />
        
        <asp:Label ID="Result_Edit_Add" runat="server" ForeColor="Red" Width="446px"></asp:Label>
        </center>
    </form>    
</body>    
</html>
