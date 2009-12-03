<%@ Page Language="C#" MasterPageFile="~/PWAS.Master" AutoEventWireup="true" CodeBehind="customer_view_order.aspx.cs" Inherits="PWAS_Site.Formulario_web11" Title="Página sin título" %>
<asp:Content ID="Content1" ContentPlaceHolderID="page_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="box1_text" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="box1_link" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="box2_text" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="box2_link" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="box3_text" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="box3_link" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="navigation_menu" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="body_title" runat="server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="body_content" runat="server">
<asp:Label ID="lblNotify" Visible="false" runat="server" ></asp:Label>
<asp:Table ID="orderHistoryTable" runat="server">
    <asp:TableRow ID="headerTable1" runat="server" CssClass="orderTopRow">
        <asp:TableHeaderCell ID="TableHeaderCell1" runat="server" Text="Job  #" Width="20%" ></asp:TableHeaderCell>
        <asp:TableHeaderCell ID="TableHeaderCell2" runat="server" Text="Job Name" Width="35%" ></asp:TableHeaderCell>
        <asp:TableHeaderCell ID="TableHeaderCell3" runat="server" Text="Status" Width="35%" ></asp:TableHeaderCell>
        <asp:TableHeaderCell ID="TableHeaderCell4" runat="server" Text="Date" Width="40%"  ></asp:TableHeaderCell>
    </asp:TableRow>
</asp:Table>
</asp:Content>
