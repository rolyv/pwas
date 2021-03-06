﻿<%@ Page Language="C#" MasterPageFile="~/PWAS.Master" AutoEventWireup="true" CodeBehind="customer_view_order.aspx.cs"
    Inherits="PWAS_Site.customer_view_order" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="page_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="box1_text" runat="server">
    Create Order
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="box1_link" runat="server">
    <a href="customer_create_order.aspx"></a>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="box2_text" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="box2_link" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="box3_text" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="box3_link" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="body_title" runat="server">
    Order List
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="body_content" runat="server">
    <asp:Panel ID="panelAlert" runat="server" Style="position: absolute; left: 50%; top: 58%;
        text-align: center" Width="300" Height="100" BackColor="Gainsboro" BorderStyle="Solid"
        BorderColor="MistyRose" BorderWidth="3px" Visible="false" >
        <asp:Label ID="lblAlert" runat="server" Font-Bold="true" >
            Your Credit Card information is not complete.
            <br />
            Would you like to update it at this time?
        </asp:Label>
        <br /><br />
        <asp:Button ID="btnAlertEdit" runat="server" Text="Edit" OnClick="btnAlertEdit_Click" />
        <asp:Button ID="btnAlertCancel" runat="server" Text="Cancel" OnClick="btnAlertCancel_Click" />
    </asp:Panel>
    <asp:Panel ID="panelAlertEmployee" runat="server" Style="position: absolute; left: 50%; top: 58%;
        text-align: center" Width="350" Height="100" BackColor="Gainsboro" BorderStyle="Solid"
        BorderColor="MistyRose" BorderWidth="3px" Visible="false" >
        <asp:Label ID="Label1" runat="server" Font-Bold="true" >
            The Credit Card information for this user is not complete.
            <br />
            Please update it through manage user before proceeding.
        </asp:Label>
        <br /><br />
        <asp:Button ID="btnAlertOk" runat="server" Text="Ok" OnClick="btnAlertOk_Click" />
    </asp:Panel>
    <asp:Label ID="lblNotify" Visible="false" runat="server"></asp:Label>
    <asp:Panel ID="tblViewOrder" runat="server">
        <asp:Table ID="orderHistoryTable" runat="server">
            <asp:TableRow ID="headerTable1" runat="server" CssClass="orderTopRow">
                <asp:TableHeaderCell></asp:TableHeaderCell>
                <asp:TableHeaderCell></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Job  #" Width="100"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Job Name" Width="200"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Price" Width="150"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Status" Width="150"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Date" Width="200"></asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
        <br />
    </asp:Panel>
    <asp:Panel ID="formEditOrder" runat="server">
        <table id="ContactTable">
            <tr>
                <td align="right">
                    <asp:Label ID="lblJobName" runat="server" Text="Job Name:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtJobName" runat="server"></asp:TextBox>
                    <img src="images/red_asterisk.png" alt="required" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblFinalSize" runat="server" Text="Final Size:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtFinalSizeX" runat="server" Width="40px"></asp:TextBox>
                    &nbsp;in. <font style="vertical-align: middle">&nbsp;<b>x</b>&nbsp;</font>
                    <asp:TextBox ID="txtFinalSizeY" runat="server" Width="40px"></asp:TextBox>
                    &nbsp;in.
                    <img src="images/red_asterisk.png" alt="required" />
                </td>
                <td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblQty" runat="server" Text="Qty. to print:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
                    <img src="images/red_asterisk.png" alt="required" />
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
                    <asp:CheckBox ID="chkTwoSide" runat="server" Text="Two Sided" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left">
                    <asp:CheckBox ID="chkfolded" runat="server" Text="Folded" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left">
                    <asp:CheckBox ID="chkShip" runat="server" Text="Ship" />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
                <td>
                    <br />
                    <asp:Button ID="createPay" Text="Save Order" runat="server" OnClick="func_Save" />
                    <asp:Button ID="cancel" Text="Cancel" runat="server" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
        <br />
    </asp:Panel>
</asp:Content>
