<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MyWebForms.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                <asp:TextBox ID="tb_1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tb_2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button BackColor="Yellow" ID="bt_result" runat="server" Text="Результат" OnClick="bt_result_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tb_result" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:DropDownList ID="cb_operation" runat="server">
        <asp:ListItem Selected="True">+</asp:ListItem>
        <asp:ListItem>-</asp:ListItem>
        <asp:ListItem>*</asp:ListItem>
        <asp:ListItem>/</asp:ListItem>
    </asp:DropDownList>
</asp:Content>
