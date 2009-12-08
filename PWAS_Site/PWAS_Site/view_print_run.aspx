<%@ Page Title="" Language="C#" MasterPageFile="~/PWAS.Master" AutoEventWireup="true" CodeBehind="view_print_run.aspx.cs" Inherits="PWAS_Site.WebForm6" %>
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
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="body_content" runat="server">
<asp:Table ID="PrintRunTable" runat="server" Height="23px" Width="656px">
    <asp:TableRow ID="headerTable1" runat="server" CssClass="orderTopRow">
        <asp:TableHeaderCell ID="editColumn"></asp:TableHeaderCell>
        <asp:TableHeaderCell ID="deleteColumn"></asp:TableHeaderCell>
        <asp:TableHeaderCell ID="TableHeaderCell1" runat="server" Text="Run ID" ></asp:TableHeaderCell>
        <asp:TableHeaderCell ID="TableHeaderCell2" runat="server" Text="PrintRun Name" ></asp:TableHeaderCell>
        <asp:TableHeaderCell ID="TableHeaderCell3" runat="server" Text="Status" ></asp:TableHeaderCell>
        <asp:TableHeaderCell ID="TableHeaderCell4" runat="server" Text="Action" ></asp:TableHeaderCell>
    </asp:TableRow>
</asp:Table>
</asp:Content>
