<%@ Page Title="" Language="C#" MasterPageFile="~/PWAS.Master" AutoEventWireup="true" CodeBehind="admin_ManageRolePermissions.aspx.cs" Inherits="PWAS_Site.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="page_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="page_head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 90px;
            text-align: right;
        }
        .style2
        {
            width: 182px;
        }
        .style3
        {
            text-align: right;
        }
    </style>
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
<asp:Content ID="Content10" ContentPlaceHolderID="body_title" runat="server">
    Manage Role Permissions&nbsp;
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="body_content" runat="server">
    <br />
        <asp:Label ID="errorLabel" runat="server" Font-Bold="True" Font-Size="Medium" 
            ForeColor="Red" Text="OMG ERROR" Visible="False"></asp:Label>
    <asp:Panel ID="editPanel" runat="server" Visible="False">
        <h3>
            Edit Permission ID
            <asp:Label ID="editPermLabel" runat="server" Text="###"></asp:Label>
            :</h3>
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    Role ID</td>
                <td class="style2">
                    <asp:TextBox ID="editRoleIDTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    Object</td>
                <td>
                    <asp:TextBox ID="editObjectTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Update</td>
                <td class="style2">
                    <asp:TextBox ID="editUpdateTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    View</td>
                <td>
                    <asp:TextBox ID="editViewTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Create</td>
                <td class="style2">
                    <asp:TextBox ID="editCreateTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    Delete</td>
                <td>
                    <asp:TextBox ID="editDeleteTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="editSubmit" runat="server" onclick="editSubmit_Click" 
            Text="Confirm Edit" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        </asp:Panel>

    <asp:Panel ID="addPanel" runat="server" Visible="False">
        <h3>
            Add New Permission:</h3>
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    Role ID</td>
                <td class="style2">
                    <asp:TextBox ID="addRoleIDTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    Object</td>
                <td>
                    <asp:TextBox ID="addObjectTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Update</td>
                <td class="style2">
                    <asp:TextBox ID="addUpdateTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    View</td>
                <td>
                    <asp:TextBox ID="addViewTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Create</td>
                <td class="style2">
                    <asp:TextBox ID="addCreateTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    Delete</td>
                <td>
                    <asp:TextBox ID="addDeleteTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="addSubmit" runat="server" onclick="addSubmit_Click" 
            Text="Confirm Add" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        </asp:Panel>

    <asp:Panel ID="deletePanel" runat="server" Visible="False">
        <h3>
            Delete Permission ID
            <asp:Label ID="deletePermLabel" runat="server" Text="###"></asp:Label>
            :</h3>
        <table style="width:100%;">
            <tr>
                <td class="style1">
                    Role ID</td>
                <td class="style2">
                    <asp:TextBox ID="deleteRoleIDTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    Object</td>
                <td>
                    <asp:TextBox ID="deleteObjectTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Update</td>
                <td class="style2">
                    <asp:TextBox ID="deleteUpdateTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    View</td>
                <td>
                    <asp:TextBox ID="deleteViewTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Create</td>
                <td class="style2">
                    <asp:TextBox ID="deleteCreateTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    Delete</td>
                <td>
                    <asp:TextBox ID="deleteDeleteTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="deleteSubmit" runat="server" onclick="deleteSubmit_Click" 
            Text="Confirm Delete" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        </asp:Panel>
    <h2>
        Role Permissions:</h2>
    <p>
        <asp:Table ID="rolePermissionTable" runat="server" Width="656px">
            <asp:TableRow runat="server" CssClass="orderTopRow" ID="titleRow">
                <asp:TableCell runat="server">Edit</asp:TableCell>
                <asp:TableCell runat="server">Delete</asp:TableCell>
                <asp:TableCell runat="server">Permission ID</asp:TableCell>
                <asp:TableCell runat="server">Role Name</asp:TableCell>
                <asp:TableCell runat="server">Object</asp:TableCell>
                <asp:TableCell runat="server">Update</asp:TableCell>
                <asp:TableCell runat="server">View</asp:TableCell>
                <asp:TableCell runat="server">Create</asp:TableCell>
                <asp:TableCell runat="server">Delete</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </p>
    <p>
        <asp:Button ID="addButton" runat="server" onclick="addButton_Click" 
            Text="Add Permission" />
    </p>
    
</asp:Content>
