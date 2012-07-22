<%@ Page Title="Week 1" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Week1.aspx.cs" Inherits="WebApplication1.Week1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Week 1 where I will initially connect to a DB!
    </h2>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="userid" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="userid" HeaderText="userid" ReadOnly="True" 
                    SortExpression="userid" />
                <asp:BoundField DataField="password" HeaderText="password" 
                    SortExpression="password" />
                <asp:BoundField DataField="firstname" HeaderText="firstname" 
                    SortExpression="firstname" />
                <asp:BoundField DataField="lastname" HeaderText="lastname" 
                    SortExpression="lastname" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="photo" HeaderText="photo" SortExpression="photo" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConflictDetection="CompareAllValues" 
            ConnectionString="<%$ ConnectionStrings:GoDaddySQL %>" 
            DeleteCommand="DELETE FROM [Huber_Logon] WHERE [userid] = @original_userid AND (([password] = @original_password) OR ([password] IS NULL AND @original_password IS NULL)) AND (([firstname] = @original_firstname) OR ([firstname] IS NULL AND @original_firstname IS NULL)) AND (([lastname] = @original_lastname) OR ([lastname] IS NULL AND @original_lastname IS NULL)) AND (([email] = @original_email) OR ([email] IS NULL AND @original_email IS NULL)) AND (([photo] = @original_photo) OR ([photo] IS NULL AND @original_photo IS NULL))" 
            InsertCommand="INSERT INTO [Huber_Logon] ([userid], [password], [firstname], [lastname], [email], [photo]) VALUES (@userid, @password, @firstname, @lastname, @email, @photo)" 
            OldValuesParameterFormatString="original_{0}" 
            SelectCommand="SELECT * FROM [Huber_Logon]" 
            UpdateCommand="UPDATE [Huber_Logon] SET [password] = @password, [firstname] = @firstname, [lastname] = @lastname, [email] = @email, [photo] = @photo WHERE [userid] = @original_userid AND (([password] = @original_password) OR ([password] IS NULL AND @original_password IS NULL)) AND (([firstname] = @original_firstname) OR ([firstname] IS NULL AND @original_firstname IS NULL)) AND (([lastname] = @original_lastname) OR ([lastname] IS NULL AND @original_lastname IS NULL)) AND (([email] = @original_email) OR ([email] IS NULL AND @original_email IS NULL)) AND (([photo] = @original_photo) OR ([photo] IS NULL AND @original_photo IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_userid" Type="String" />
                <asp:Parameter Name="original_password" Type="String" />
                <asp:Parameter Name="original_firstname" Type="String" />
                <asp:Parameter Name="original_lastname" Type="String" />
                <asp:Parameter Name="original_email" Type="String" />
                <asp:Parameter Name="original_photo" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="userid" Type="String" />
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="firstname" Type="String" />
                <asp:Parameter Name="lastname" Type="String" />
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="photo" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="firstname" Type="String" />
                <asp:Parameter Name="lastname" Type="String" />
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="photo" Type="String" />
                <asp:Parameter Name="original_userid" Type="String" />
                <asp:Parameter Name="original_password" Type="String" />
                <asp:Parameter Name="original_firstname" Type="String" />
                <asp:Parameter Name="original_lastname" Type="String" />
                <asp:Parameter Name="original_email" Type="String" />
                <asp:Parameter Name="original_photo" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>
