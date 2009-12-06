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
<asp:Content ID="Content9" ContentPlaceHolderID="navigation_menu" runat="server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="body_title" runat="server">
Roles&nbsp;
    &nbsp;
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="body_content" runat="server">

    <asp:Panel ID="editPanel" runat="server">
        <br />
        Edit Role:<table style="width:100%;">
            <tr>
                <td class="style1">
                    Role ID</td>
                <td class="style2">
                    <asp:TextBox ID="roleIDTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    Object</td>
                <td>
                    <asp:TextBox ID="objectTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Update</td>
                <td class="style2">
                    <asp:TextBox ID="updateTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    View</td>
                <td>
                    <asp:TextBox ID="viewTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Create</td>
                <td class="style2">
                    <asp:TextBox ID="createTextBox" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    Delete</td>
                <td>
                    <asp:TextBox ID="deleteTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="editSubmit" runat="server" onclick="editSubmit_Click" 
            Text="Submit" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="errorLabel" runat="server" Font-Bold="True" Font-Size="Medium" 
            ForeColor="Red" Text="OMG ERROR" Visible="False"></asp:Label>
    </asp:Panel>

    <p>

    <asp:Panel ID="addPanel" runat="server" Visible="False">
        <br />
        Add Role:<table style="width:100%;">
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
            Text="Submit" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="addErrorLabel" runat="server" Font-Bold="True" Font-Size="Medium" 
            ForeColor="Red" Text="OMG ERROR" Visible="False"></asp:Label>
    </asp:Panel>

    </p>
    <p>
        <br />
        <asp:Table ID="rolePermissionTable" runat="server" Width="656px">
            <asp:TableRow runat="server" CssClass="orderTopRow">
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server"></asp:TableCell>
                <asp:TableCell runat="server">Permission ID</asp:TableCell>
                <asp:TableCell runat="server">Role ID</asp:TableCell>
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
            Text="Add Role" />
    </p>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <p>
    </p>

</asp:Content>
