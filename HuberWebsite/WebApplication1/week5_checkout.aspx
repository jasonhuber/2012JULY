﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="week5_checkout.aspx.cs" Inherits="week5_checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<!--should have a repeater here showing me what I am going to order....
-->

Credit Card Number: <asp:TextBox ID="cc" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
    <br />

<asp:Button ID="btncheckout" runat="server" Text="Checkout!" 
    onclick="btncheckout_Click" />

</asp:Content>

