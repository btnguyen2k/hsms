<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MapDetail.aspx.cs" Inherits="HSMS.Admin.MapDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" ForeColor="Blue" Text="DANH SÁCH PHÂN BỐ PHÒNG HỌC"
            Width="268px"></asp:Label><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label2" runat="server" Text="Phòng" Width="68px"></asp:Label><asp:Label
            ID="Label3" runat="server" Text="Sáng" Width="74px"></asp:Label><asp:Label ID="Label4"
                runat="server" Text="Chiều" Width="97px"></asp:Label><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label5" runat="server" Text="A11" Width="53px"></asp:Label><asp:DropDownList
            ID="Class1_S" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="Class1_C" runat="server">
        </asp:DropDownList><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label6" runat="server" Text="A12" Width="53px"></asp:Label><asp:DropDownList
            ID="Class2_S" runat="server" >
        </asp:DropDownList>
        &nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="Class2_C" runat="server">
        </asp:DropDownList><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label7" runat="server" Text="A13" Width="53px"></asp:Label><asp:DropDownList
            ID="Class3_S" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="Class3_C" runat="server">
        </asp:DropDownList><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label8" runat="server" Text="A14" Width="53px"></asp:Label><asp:DropDownList
            ID="Class4_S" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="Class4_C" runat="server">
        </asp:DropDownList><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label9" runat="server" Text="A15" Width="53px"></asp:Label><asp:DropDownList
            ID="Class5_S" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="Class5_C" runat="server">
        </asp:DropDownList><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label11" runat="server" Text="A21" Width="53px"></asp:Label><asp:DropDownList
            ID="Class6_S" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="Class6_C" runat="server" >
        </asp:DropDownList><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label13" runat="server" Text="A22" Width="53px"></asp:Label><asp:DropDownList
            ID="Class7_S" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="Class7_C" runat="server">
        </asp:DropDownList><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label15" runat="server" Text="A23" Width="53px"></asp:Label><asp:DropDownList
            ID="Class8_S" runat="server" >
        </asp:DropDownList>
        &nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="Class8_C" runat="server">
        </asp:DropDownList><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label16" runat="server" Text="A24" Width="53px"></asp:Label><asp:DropDownList
            ID="Class9_S" runat="server" >
        </asp:DropDownList>
        &nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="Class9_C" runat="server">
        </asp:DropDownList><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label14" runat="server" Text="A25" Width="53px"></asp:Label><asp:DropDownList
            ID="Class10_S" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="Class10_C" runat="server">
        </asp:DropDownList><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label12" runat="server" Text="A26" Width="53px"></asp:Label><asp:DropDownList
            ID="Class11_S" runat="server" >
        </asp:DropDownList>
        &nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="Class11_C" runat="server">
        </asp:DropDownList><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label10" runat="server" Text="A27" Width="53px"></asp:Label><asp:DropDownList
            ID="Class12_S" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp;&nbsp;
        <asp:DropDownList ID="Class12_C" runat="server">
        </asp:DropDownList><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label17" runat="server" Text="B11" Width="53px"></asp:Label><asp:DropDownList
            ID="Class13_S" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp;
        <asp:DropDownList ID="Class13_C" runat="server" >
        </asp:DropDownList><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label18" runat="server" Text="B12" Width="53px"></asp:Label><asp:DropDownList
            ID="Class14_S" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp;
        <asp:DropDownList ID="Class14_C" runat="server">
        </asp:DropDownList><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label19" runat="server" Text="B13" Width="53px"></asp:Label><asp:DropDownList
            ID="Class15_S" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp;
        <asp:DropDownList ID="Class15_C" runat="server">
        </asp:DropDownList><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label20" runat="server" Text="B14" Width="53px"></asp:Label><asp:DropDownList
            ID="Class16_S" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp;
        <asp:DropDownList ID="Class16_C" runat="server">
        </asp:DropDownList><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label21" runat="server" Text="B21" Width="53px"></asp:Label><asp:DropDownList
            ID="Class17_S" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp;
        <asp:DropDownList ID="Class17_C" runat="server" >
        </asp:DropDownList><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label22" runat="server" Text="B22" Width="53px"></asp:Label><asp:DropDownList
            ID="Class18_S" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp;
        <asp:DropDownList ID="Class18_C" runat="server">
        </asp:DropDownList><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label23" runat="server" Text="B23" Width="53px"></asp:Label><asp:DropDownList
            ID="Class19_S" runat="server" >
        </asp:DropDownList>
        &nbsp; &nbsp;
        <asp:DropDownList ID="Class19_C" runat="server">
        </asp:DropDownList><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Label ID="Label24" runat="server" Text="B24" Width="53px"></asp:Label><asp:DropDownList
            ID="Class20_S" runat="server">
        </asp:DropDownList>
        &nbsp; &nbsp;
        <asp:DropDownList ID="Class20_C" runat="server" >
        </asp:DropDownList><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="Save" runat="server"
            OnClick="Save_Click" Text="Cập nhật" /><br />
        <asp:Label ID="Result" runat="server" ForeColor="Red" Width="627px"></asp:Label></div>
    </form>
</body>
</html>
