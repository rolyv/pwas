<%@ Page Title="" Language="C#" MasterPageFile="~/PWAS.Master" AutoEventWireup="true" CodeBehind="adminView_ManageAccounts.aspx.cs" Inherits="PWAS_Site.adminView_ManageAccounts" %>
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
<asp:Content ID="Content10" ContentPlaceHolderID="body_title" runat="server">
    Manage User Accounts
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="body_content" runat="server">
    <asp:Table ID="tableManageUsers" runat="server">
        <asp:TableHeaderRow CssClass="orderTopRow">
            <asp:TableHeaderCell>
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
                    Username
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
                    Full Name
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
                    Telephone
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
                    Email
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <br />
</asp:Content>
