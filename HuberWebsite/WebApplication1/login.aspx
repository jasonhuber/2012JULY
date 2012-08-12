<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    Username: <asp:TextBox ID="txtUsername" runat="server">
    </asp:TextBox>
    <br />
    Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <br />
    <asp:Button ID="btnLogin" runat="server" Text="Button" 
        onclick="btnLogin_Click" />
</asp:Content>

