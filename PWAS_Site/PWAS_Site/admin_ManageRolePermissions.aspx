<%@ Page Title="" Language="C#" MasterPageFile="~/PWAS.Master" AutoEventWireup="true" CodeBehind="admin_ManageRolePermissions.aspx.cs" Inherits="PWAS_Site.WebForm5" %>
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
<asp:Content ID="Content9" ContentPlaceHolderID="navigation_menu" runat="server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="body_title" runat="server">
Roles
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="body_content" runat="server">

    <p>
        <br />
        <asp:Table ID="rolePermissionTable" runat="server" Width="656px">
            <asp:TableRow runat="server">
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
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <p>
    </p>

</asp:Content>
