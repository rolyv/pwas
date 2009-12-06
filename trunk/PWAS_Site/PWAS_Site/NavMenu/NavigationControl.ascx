<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationControl.ascx.cs" Inherits="PWAS_Site.NavMenu.NavigationControl" %>



<asp:TreeView ID="NavTreeView" runat="server" ImageSet="Arrows">
    <ParentNodeStyle Font-Bold="False" />
    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
        HorizontalPadding="5px" VerticalPadding="0px" />
    <Nodes>
    </Nodes>
    <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
        HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
</asp:TreeView>
<br />
<br />

<!--View Profile
View Users
Create User
Edit Users

View Orders
Create Order
Edit Orders

View Print Runs
Create Print Run
Edit Print Runs

Manage Security
    View Roles
    Create Role
    Edit Roles
    View Role Permissions
    Create Role Permission
    Edit Role Permissions--!/>