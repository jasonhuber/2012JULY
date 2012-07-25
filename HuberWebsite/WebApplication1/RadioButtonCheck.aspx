<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="RadioButtonCheck.aspx.cs" Inherits="RadioButtonCheck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    Jason: <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" 
        GroupName="Jason" oncheckedchanged="RadioButton1_CheckedChanged" Text="One" /><br />
    Huber: <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" 
        GroupName="Jason" oncheckedchanged="RadioButton1_CheckedChanged" Text="Two" />
    <br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Calendar ID="Calendar1" runat="server" 
        onselectionchanged="Calendar1_SelectionChanged"></asp:Calendar>
    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" 
        ControlToValidate="TextBox1" EnableClientScript="False" 
        onservervalidate="CustomValidator1_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
</asp:Content>

