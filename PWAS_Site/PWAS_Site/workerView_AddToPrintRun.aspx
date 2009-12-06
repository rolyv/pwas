<%@ Page Language="C#" MasterPageFile="~/PWAS.Master" AutoEventWireup="true" CodeBehind="workerView_AddToPrintRun.aspx.cs" Inherits="PWAS_Site.workerView_AddToPrintRun" Title="Untitled Page" %>
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
    <asp:Label ID="messageLb" runat="server" Text="Move Selected Orders to Print Run -> "></asp:Label>
    <asp:DropDownList ID="runList" runat="server" >
    </asp:DropDownList>
   
    <br />
    <asp:Label ID="messageNotify" runat="server" Text=""  Visible="false"></asp:Label>
    <br />
    
    
     <asp:Table ID="tableCreatedOrders" runat="server">
        <asp:TableHeaderRow CssClass="orderTopRow">
            <asp:TableHeaderCell>
            Select
            </asp:TableHeaderCell>
            
            <asp:TableHeaderCell>
                    Order ID
            </asp:TableHeaderCell>
            
            <asp:TableHeaderCell>
                    Order Name
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
                    Order Quantity
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
                    Order Height
            </asp:TableHeaderCell>
            <asp:TableHeaderCell>
                    Order Width
            </asp:TableHeaderCell>
            
          
            
        </asp:TableHeaderRow>
    </asp:Table>
    <br />
    
    <asp:Button ID="submitButton" runat="server" Text="Move Orders" onClick="doSubmit"/>
    
    
    
</asp:Content>
