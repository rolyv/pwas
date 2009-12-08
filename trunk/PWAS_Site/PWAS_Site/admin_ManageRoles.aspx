<%@ Page Title="" Language="C#" MasterPageFile="~/PWAS.Master" AutoEventWireup="true" CodeBehind="admin_ManageRoles.aspx.cs" Inherits="PWAS_Site.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="page_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="page_head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="box1_text" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="box1_link" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="box2_text" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="box2_link" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="box3_text" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="box3_link" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="body_title" runat="server">

    Manage Roles

</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="body_content" runat="server">
<asp:Label ID="errorMessageLabel" runat="server" ForeColor="Red" 
        Text="Error Message" Visible="False" Font-Bold="True" Font-Size="Medium"></asp:Label>

    </p>
    <asp:Panel ID="editPanel" runat="server" Height="121px" Visible="False">
        <h3>
            Edit Role
            <asp:Label ID="editLabel" runat="server" Text="Label"></asp:Label>
            :</h3>
        <table style="width:100%;">
            <tr>
                <td class="style2">
                    Role Name</td>
                <td>
                    Role Description</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:TextBox ID="editRoleNameBox" runat="server" Width="161px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="editRoleDescBox" runat="server" Width="330px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="editSubmit" runat="server" Text="Confirm Edit" 
            onclick="Button1_Click" />
    </asp:Panel>
    <asp:Panel ID="addPanel" runat="server" Visible="False">
        <h3>
            Add Role:</h3>
        <table style="width:100%;">
            <tr>
                <td>
                    Role Name</td>
                <td>
                    Role Description</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="addRoleNameBox" runat="server" Width="161px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="addRoleDescBox" runat="server" Width="330px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="addSubmit" runat="server" onclick="addSubmit_Click" 
            Text="Confirm Add" />
        &nbsp;&nbsp;&nbsp;&nbsp;
    </asp:Panel>
    <asp:Panel ID="deletePanel" runat="server" Visible="False">
        <h3>
            Delete Role
            <asp:Label ID="deleteLabel" runat="server" Text="Label"></asp:Label>
            :</h3>
        <table style="width:100%;">
            <tr>
                <td class="style2">
                    Role Name</td>
                <td>
                    Role Description</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:TextBox ID="deleteRoleNameBox" runat="server" ReadOnly="True" 
                        Width="161px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="deleteRoleDescBox" runat="server" ReadOnly="True" 
                        Width="330px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="deleteSubmit" runat="server" onclick="deleteSubmit_Click" 
            Text="Confirm Delete" />
    </asp:Panel>

    <h2>
        Roles:</h2>
<asp:Table ID="roleDescriptionTable" runat="server" Width="656px">
    <asp:TableRow ID="titleRow" runat="server" CssClass="orderTopRow">
        <asp:TableCell ID="TableCell1" runat="server">Edit</asp:TableCell>
        <asp:TableCell ID="TableCell2" runat="server">Delete</asp:TableCell>
        <asp:TableHeaderCell ID="TableHeaderCell1" runat="server" Text="Role ID" ></asp:TableHeaderCell>
        <asp:TableHeaderCell ID="TableHeaderCell2" runat="server" Text="Role Name" ></asp:TableHeaderCell>
        <asp:TableHeaderCell ID="TableHeaderCell3" runat="server" Text="Role Description" ></asp:TableHeaderCell>
    </asp:TableRow>
</asp:Table>

    <br />
    <asp:Button ID="addButton" runat="server" onclick="addButton_Click" Text="Add Role" 
        Width="90px" />
&nbsp;<br />
</asp:Content>
