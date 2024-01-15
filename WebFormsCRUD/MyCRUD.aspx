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
                            <asp:Button ID="btSearch" runat="server" Text="Search" />
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="Panel3" runat="server" Height="78px" Width="386px" BackColor="#00FFCC"></asp:Panel>
                    </td>
                    <td>
                        <asp:Panel ID="Panel4" runat="server" Height="78px" Width="386px" BackColor="#FFFF99"></asp:Panel>

                    </td>
                </tr>
            </table>


        </asp:Panel>
    </form>
</body>
</html>
