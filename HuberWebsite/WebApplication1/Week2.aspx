<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Week2.aspx.cs" Inherits="Week2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
   
    Fname: <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtFname" ErrorMessage="You must enter a fName" 
        ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    email: <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ErrorMessage="Your email was invalid." ControlToValidate="txtEmail" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtEmail" ErrorMessage="You must enter an Email" 
        ForeColor="Red">*</asp:RequiredFieldValidator>

    <br />

    <asp:Button ID="cmdSubmit" runat="server" Text="Submit the form!" 
        Font-Underline="False" onclick="cmdSubmit_Click" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        
        <br />
        <asp:Label runat="server" ID="lblhidden" Text="Hi" Visible=false></asp:Label>


</asp:Content>

