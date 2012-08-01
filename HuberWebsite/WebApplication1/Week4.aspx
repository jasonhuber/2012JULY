<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Week4.aspx.cs" Inherits="Week4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table width="100%">
        <tr>
            <td><asp:TextBox name="txtProductId" runat="server" ID="txtProductId"></asp:TextBox></td>
            <td><asp:TextBox name="txtPrice" runat="server" ID="txtPrice"></asp:TextBox></td>
            <td><asp:TextBox name="txtDescription" runat="server" ID="txtDescription"></asp:TextBox></td>
            <td><asp:TextBox name="txtQOH" runat="server" ID="txtQOH"></asp:TextBox></td>
            <td>&nbsp;</td>
            <td><asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="..." /></td>
        </tr>
        <tr>
            <td>Product Id</td>
            <td>Price</td>
            <td>Description</td>
            <td>QOH</td>
            <td>IMAGE</td>
            <td>BUY</td>
        </tr>
         <asp:Repeater runat="server" ID="rptData">
            <ItemTemplate>
                 <tr>
                    <td><%# DataBinder.Eval(Container.DataItem, "ProductId")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Price")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Description")%></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "QOH")%></td>
                    <td><img src=".<%# DataBinder.Eval(Container.DataItem, "IMAGE")%>" width="100" /></td>
                    <td><a href="week4_addtocart.aspx?ProductId=<%# DataBinder.Eval(Container.DataItem, "Productid")%>">Add to cart!</a></td>
                </tr>
            </ItemTemplate>
         </asp:Repeater>
    </table>
</asp:Content>

