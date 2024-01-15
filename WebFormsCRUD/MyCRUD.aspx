<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCRUD.aspx.cs" Inherits="WebFormsCRUD.MyCRUD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>CRUD operations</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <link href="Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server" BackColor="#99CCFF" Height="78px">
            <table>
                <tr>
                    <td>
                        <asp:Panel ID="Panel2" runat="server" Height="78px" Width="386px" BackColor="#FF9999">
                            <asp:TextBox ID="tbSearch" runat="server"></asp:TextBox>
                            <asp:Button ID="btSearch" runat="server" Text="Search" OnClick="btSearch_Click" />
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="Panel3" runat="server" Height="78px" Width="386px" BackColor="#00FFCC">
                            <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
                            <asp:Button ID="btAdd" runat="server" Text="Add" OnClick="btAdd_Click" />
                            <asp:Button ID="btEdit" runat="server" Text="Edit" OnClick="btEdit_Click" />
                            <asp:Button ID="btDelete" runat="server" Text="Delete" OnClick="btDelete_Click" />
                            <asp:HiddenField ID="hfId" runat="server" />

                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="Panel4" runat="server" Height="78px" Width="386px" BackColor="#FFFF99">
                            <asp:DropDownList ID="cbReportType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cbReportType_SelectedIndexChanged" Width="197px">
                                <asp:ListItem>Excel</asp:ListItem>
                                <asp:ListItem>CSV</asp:ListItem>
                            </asp:DropDownList>
                        </asp:Panel>

                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:GridView ID="gvCity" runat="server" CssClass="GridView_With_GridLines" DataKeyNames="id,name"
            AllowPaging="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
            BorderWidth="1px" CellPadding="4" PageSize="21" AutoGenerateColumns="False" OnSelectedIndexChanged="gvCity_SelectedIndexChanged">
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#FFD789" BorderStyle="Groove" BorderWidth="2" />
            <PagerSettings Position="TopAndBottom" />
            <PagerStyle CssClass="cssPager" />
            <Columns>
                <asp:CommandField SelectText="Выбрать" ShowSelectButton="True">
                    <HeaderStyle Wrap="True" Width="100" />
                    <ItemStyle CssClass="GridView_HyperLink" Wrap="True" ForeColor="Red" />
                    <ControlStyle Width="50px" />
                </asp:CommandField>
                <asp:BoundField DataField="id" HeaderText="№">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="Название">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="700px" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle CssClass="GridView_With_GridLines_Header" ForeColor="#CCCCFF" HorizontalAlign="Left"
                Wrap="False" BackColor="#003399" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>


    </form>
</body>
</html>
