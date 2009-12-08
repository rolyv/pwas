<%@ Page Title="" Language="C#" MasterPageFile="~/PWAS.Master" AutoEventWireup="true" CodeBehind="view_Single_PrintRun.aspx.cs" Inherits="PWAS_Site.View_single_printRun" %>
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
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="body_content" runat="server">
<asp:Table ID="PrintRunTableView" runat="server" Height="23px" Width="656px">
    <asp:TableRow ID="headerTable1" runat="server" CssClass="orderTopRow">        
        <asp:TableHeaderCell ID="TableHeaderCell1" runat="server" Text="Order ID" ></asp:TableHeaderCell>
        <asp:TableHeaderCell ID="TableHeaderCell2" runat="server" Text="Job Name" ></asp:TableHeaderCell>
        <asp:TableHeaderCell ID="TableHeaderCell3" runat="server" Text="Quantity" ></asp:TableHeaderCell>
        <asp:TableHeaderCell ID="TableHeaderCell4" runat="server" Text="Price" ></asp:TableHeaderCell>
    </asp:TableRow>
</asp:Table>
 <br />       
      <asp:Button ID="BackButton" Text="Back" runat="server" OnClick="backButton"  style="margin-left:200px" />
      <asp:Button ID="OkviewOrder" Text="OK" runat="server" OnClick="okButton" style="margin-left:50px" />
 <br />
 <br />

</asp:Content>
