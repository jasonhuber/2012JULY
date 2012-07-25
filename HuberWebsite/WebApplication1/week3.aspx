<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="week3.aspx.cs" Inherits="week3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="lblTemp" runat="server" Text="Label"></asp:Label>
    <table width=100%>
        <tr>
            <td><asp:TextBox name="txtIP" runat="server" ID="txtIP"></asp:TextBox></td>
            <td><asp:TextBox name="txtUserAgent" runat="server" ID="txtUserAgent"></asp:TextBox></td>
            <td><asp:TextBox name="txtreferer" runat="server" ID="txtreferer"></asp:TextBox></td>
            <td><asp:TextBox name="txtdestination" runat="server" ID="txtdestination"></asp:TextBox></td>
            <td><asp:TextBox name="txtdatetimewhen" runat="server" ID="txtdatetimewhen"></asp:TextBox></td>
            <td><asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="..." /></td>
        </tr>
        <tr>
            <td>IP</td>
            <td>useragent</td>
            <td>referer</td>
            <td>destination</td>
            <td>datetimewhen</td>
            <td>&nbsp;</td>
        </tr>
         <asp:Repeater runat="server" ID="rptData">
            <ItemTemplate>
                 <tr>
                    <td><%# DataBinder.Eval (Container.DataItem, "IP") %></td>
                    <td><%# DataBinder.Eval (Container.DataItem, "useragent") %></td>
                    <td><%# DataBinder.Eval (Container.DataItem, "referrer") %></td>
                    <td><%# DataBinder.Eval (Container.DataItem, "destination") %></td>
                    <td><%# DataBinder.Eval (Container.DataItem, "Datetimewhen") %></td>
                    <td>&nbsp;</td>
                </tr>
            </ItemTemplate>
         </asp:Repeater>
    </table>

</asp:Content>

