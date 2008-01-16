<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_tearcher.aspx.cs" Inherits="HSMS.Admin.add_tearcher" %>

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
            Text="THÊM GIÁO VIÊN MỚI"></asp:Label><br />
        <br />        
        <asp:Label ID="Label2" runat="server" ForeColor="Blue" Text="THÔNG TIN CHUNG" Width="152px"></asp:Label>        
  
  <table align=center border="1" id="Information" runat="server" style="width: 418px" >
	<tr>
		<td style="width: 180px" >Họ và tên :</td>
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
                        &nbsp;<asp:DropDownList ID="Teacher_Day" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                            <asp:ListItem>24</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                            <asp:ListItem>26</asp:ListItem>
                            <asp:ListItem>27</asp:ListItem>
                            <asp:ListItem>28</asp:ListItem>
                            <asp:ListItem>29</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>31</asp:ListItem>
                        </asp:DropDownList></td>
				    <td>
                        <asp:DropDownList ID="Teacher_Month" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>&nbsp;</td>
				    <td>				&nbsp;<asp:DropDownList ID="Teacher_Year" runat="server">
                        </asp:DropDownList>&nbsp;
				    </td>
			    </tr>
		    </table>
		    
        </td>
	</tr>	
	<tr>
		<td style="width: 180px">
            Năm băt đầu giảng dạy :</td>
		
		<td style="width: 74px">
            &nbsp;<asp:DropDownList ID="Teacher_YearStart" runat="server">
            </asp:DropDownList></td>
	</tr>
	<tr>
		<td style="width: 180px">
            Dạy môn học :</td>
		<td style="width: 74px">
            &nbsp;<asp:DropDownList ID="Teacher_Subject" runat="server">
            </asp:DropDownList></td>
	</tr>
	<tr>
		<td style="width: 180px">Chủ nhiệm lớp :</td>
		<td style="width: 74px">
            &nbsp;<asp:DropDownList ID="Teacher_MainClass" runat="server" AutoPostBack="True"
                OnSelectedIndexChanged="Teacher_MainClass_SelectedIndexChanged">
            </asp:DropDownList></td>
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
            </center>
        <center>
            &nbsp;</center>
        <center>
        <asp:Label ID="Label3" runat="server" ForeColor="Blue" Text="THÔNG TIN THÊM"
            Width="155px"></asp:Label><br />
        <asp:Label ID="Label4" runat="server" Text="Chức vụ:" Width="64px"></asp:Label>
        <asp:TextBox ID="Position" runat="server" Width="313px"></asp:TextBox><br />
        
        <br />
        <asp:Label ID="Label15" runat="server" Text="Tiểu sử công tác:" Width="110px"></asp:Label><br />
        <asp:TextBox ID="HistoryTeacher" runat="server" Height="126px" TextMode="MultiLine" Width="445px"></asp:TextBox><br />
        <br />
        
        <asp:Button ID="Add_Teacher" runat="server" OnClick="Add_Teacher_Click" Text="Thêm giáo viên mới" />&nbsp;&nbsp;&nbsp;<br />
        </center>
        <center>
            &nbsp;</center>
        <center>
        <asp:Label ID="Add_Result" runat="server" ForeColor="Red" Width="455px"></asp:Label><br />
        <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Blue" NavigateUrl="~/Admin/add_tearcher.aspx"
            Target="content_admin">thêm giáo viên khác</asp:HyperLink>
        </center>
            </div>
    </form>
</body>
</html>
