<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_pupil.aspx.cs" Inherits="HSMS.Admin.add_pupil" %>

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
        &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Font-Size="XX-Large" ForeColor="Red"
            Height="26px" Text="THÊM HỌC SINH MỚI" Width="370px"></asp:Label><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label10" runat="server" ForeColor="Blue" Text="THÔNG TIN CHUNG" Width="155px"></asp:Label><br />
        &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label2" runat="server" Text="Họ và Tên : "
            Width="102px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="Name" runat="server" Width="229px" ></asp:TextBox><br />
        <br />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Ngày tháng năm sinh :" Width="141px"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:DropDownList
            ID="Day" runat="server">
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
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>&nbsp; &nbsp; &nbsp;<asp:DropDownList ID="Month" runat="server">
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
        </asp:DropDownList>
        &nbsp; &nbsp;<asp:DropDownList ID="Year" runat="server">
        </asp:DropDownList>&nbsp;
        <asp:Label ID="Label4" runat="server" Text="(ngày/tháng/năm)" Width="113px"></asp:Label><br />
        <br />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="Năm nhập học :" Width="106px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="Year_Enroll" runat="server" Width="80px"></asp:TextBox><br />
        <br />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="Theo học lớp :" Width="92px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:DropDownList
            ID="Class" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Class_SelectedIndexChanged">
        </asp:DropDownList><br />
        <br />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label7" runat="server" Text="Mã số học sinh :" Width="122px"></asp:Label>
        &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="Pupil_id" runat="server" Width="90px"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Label ID="Label8" runat="server" Text="(mặc định là username và pass cho học sinh đó)"
            Width="300px"></asp:Label><br />
        <br />
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label9" runat="server" Text="Email :" Width="65px"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:TextBox ID="Email" runat="server" Width="178px"></asp:TextBox><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label11" runat="server" ForeColor="Blue" Text="THÔNG TIN THÊM"></asp:Label><br />
        &nbsp;
        <br />
        <asp:Label ID="Label12" runat="server" Text="Chức vụ trong lớp:"></asp:Label>
        <asp:TextBox ID="Position" runat="server" Width="238px"></asp:TextBox><br />
        <asp:Label ID="Label13" runat="server" Text="Thành tích cá nhân:" Width="117px"></asp:Label><br />
        <asp:TextBox ID="History" runat="server" Height="154px" TextMode="MultiLine" Width="576px"></asp:TextBox><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; 
        <asp:Button ID="AddPupil" runat="server" Text="Thêm học sinh" Width="184px" OnClick="AddPupil_Click" /><br />
        <asp:Label ID="Add_Result" runat="server" ForeColor="Red" Width="475px"></asp:Label></div>
    </form>
</body>
</html>
