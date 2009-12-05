<%@ Page Language="C#" MasterPageFile="~/PWAS.Master" AutoEventWireup="true" CodeBehind="customer_view_order.aspx.cs" Inherits="PWAS_Site.customer_view_order" %>
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
Order List
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="body_content" runat="server">
<asp:Label ID="lblNotify" Visible="false" runat="server" ></asp:Label>
    <asp:Panel ID="tblViewOrder" runat="server">
        <asp:Table ID="orderHistoryTable" runat="server">
            <asp:TableRow ID="headerTable1" runat="server" CssClass="orderTopRow">
                <asp:TableHeaderCell ></asp:TableHeaderCell>                
                <asp:TableHeaderCell ></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Job  #" ></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Job Name" ></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Price"  ></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Status" ></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Date" ></asp:TableHeaderCell>                               
            </asp:TableRow>
        </asp:Table>
        <br />
    </asp:Panel>
    
    <asp:Panel ID="formEditOrder" runat="server">
        <table id="ContactTable" >
	            
	            <tr>
                    <td align="right">
                        <asp:Label ID="lblJobName" runat="server" Text="Job Name:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtJobName" runat="server"></asp:TextBox>
                    </td>
                </tr>
		        <tr>
		            <td align="right">
		                <asp:Label ID="lblFinalSize" runat="server" Text="Final Size:"></asp:Label>
		            </td>
		            <td align="left">
		                <asp:TextBox ID="txtFinalSizeX" runat="server"></asp:TextBox>X
		                <asp:TextBox ID="txtFinalSizeY" runat="server"></asp:TextBox>
		            </td>
	    	    </tr>
		        <tr>
		            <td align="right">
		                <asp:Label ID="lblQty" runat="server" Text="Qty. to print:"></asp:Label>
		            </td>
		            <td align="left">
		                <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
		            </td>
		        </tr>
		        <tr>
		            <td align="right">
		                <asp:Label ID="lblFinish" runat="server" Text="Stock Finish:"></asp:Label>
		            </td>
		            <td align="left">
		                <asp:DropDownList ID="lstFinish" runat="server">
		                    <asp:ListItem>Glossy</asp:ListItem>
		                    <asp:ListItem>Flat</asp:ListItem>
		                </asp:DropDownList>
		            </td>
		        </tr>
		        <tr>
		            <td align="right">
		                <asp:Label ID="lblWeight" runat="server" Text="Stock Weight:"></asp:Label>
		            </td>
		            <td align="left">
		                <asp:DropDownList ID="lstWeight" runat="server">
		                    <asp:ListItem>Heavy</asp:ListItem>
		                    <asp:ListItem>Light</asp:ListItem>
		                </asp:DropDownList>
		            </td>
		        </tr>
		        <tr>
		            <td align="left">
		                <asp:CheckBox ID="chkTwoSide" runat="server" Text="Two Sided"/>
		            </td>
		        </tr>
		        <tr>
		            <td align="left">
		                <asp:CheckBox ID="chkfolded" runat="server" Text="Folded"/>
		            </td>
		        </tr>
		        <tr>
		            <td align="left">
		                <asp:CheckBox ID="chkShip" runat="server" Text="Ship"/>
		            </td>
		        </tr>
	        </table>
        <br /> 
            <asp:Button ID="createPay" Text="Save Order" runat="server" OnClick="func_Save" />
            <asp:Button ID="clear" Text="Clear" runat="server" OnClick="func_Clear" />
    </asp:Panel>
</asp:Content>