<%@ Page Title="Page_1" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Page_1.aspx.cs" Inherits="MyWebForms.Page_1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Button ID="Button1" runat="server" Text="go to about" OnClick="Button1_Click" />
    <a href="about.aspx">прыг</a>
</asp:Content>
