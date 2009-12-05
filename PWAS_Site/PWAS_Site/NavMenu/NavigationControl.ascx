<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationControl.ascx.cs" Inherits="PWAS_Site.NavMenu.NavigationControl" %>



<asp:TreeView ID="NavTreeView" runat="server" ImageSet="Arrows">
    <ParentNodeStyle Font-Bold="False" />
    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
        HorizontalPadding="5px" VerticalPadding="0px" />
    <Nodes>
        <asp:TreeNode Text="Manage Users" Value="Manage Users" 
            NavigateUrl="~/WebForm3.aspx"></asp:TreeNode>
        <asp:TreeNode Text="Create Order" Value="Create Order"
            NavigateUrl="~/customer_create_order.aspx"></asp:TreeNode>
        <asp:TreeNode Text="Manage Orders" Value="Manage Orders"
            NavigateUrl="~/customer_view_order.aspx" pwasObj="order" pwasAction="view"></asp:TreeNode>
        <asp:TreeNode Text="Manage Print Runs" Value="Manage Print Runs"></asp:TreeNode>
        <asp:TreeNode Text="Manage Security Roles" Value="Manage Security Roles">
        </asp:TreeNode>
    </Nodes>
    <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
        HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
</asp:TreeView>

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