﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PWAS.Master" AutoEventWireup="true" CodeBehind="view_Single_Order.aspx.cs" Inherits="PWAS_Site.view_Single_Order" %>
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
View Single Order
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="body_content" runat="server">

    
	        <asp:Label ID="lblNotify" runat="server" Visible="false"></asp:Label>
            
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
		                <asp:TextBox ID="txtFinalSizeX" runat="server" Width="40px"></asp:TextBox> &nbsp;in.
		                <font style="vertical-align:middle" >&nbsp;<b>x</b>&nbsp;</font>
		                <asp:TextBox ID="txtFinalSizeY" runat="server" Width="40px"></asp:TextBox> &nbsp;in.
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
		            <td>
		            </td>
		            <td align="left">
		                <asp:CheckBox ID="chkTwoSide" runat="server" Text="Two Sided"/>
		            </td>
		        </tr>
		        <tr>
		            <td>
		            </td>
		            <td align="left">
		                <asp:CheckBox ID="chkfolded" runat="server" Text="Folded"/>
		            </td>
		        </tr>
		        <tr>
		            <td>
		            </td>
		            <td align="left">
		                <asp:CheckBox ID="chkShip" runat="server" Text="Ship"/>
		            </td>
		        </tr>
		        <tr>
		            <td>
		                <br /> 
		            </td>
		            <td>
		                <br />
		                <asp:Button ID="OkviewOrder" Text="OK" runat="server" OnClick="okButton" />
		                <asp:Button ID="BackButton" Text="Back" runat="server" OnClick="backButton" />
		            </td>
		        </tr>
	        </table>
        <br />
</asp:Content>
