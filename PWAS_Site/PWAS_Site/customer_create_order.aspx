﻿<%@ Page Language="C#" MasterPageFile="~/PWAS.Master" AutoEventWireup="true" CodeBehind="customer_create_order.aspx.cs"
    Inherits="PWAS_Site.customer_create_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="page_title" runat="server">
    Create Order
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
<asp:Content ID="Content9" ContentPlaceHolderID="body_title" runat="server">
    Create Order
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="body_content" runat="server">
    <asp:Label ID="lblNotify" runat="server" Visible="false"></asp:Label>
    <table id="ContactTable">
        <tr>
            <td align="right">
                <asp:Label ID="lblJobName" runat="server" Text="Job Name:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtJobName" runat="server"></asp:TextBox>
            </td>
            <td>
                <img src="images/red_asterisk.png" alt="required"/>
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
            <td>
                <img src="images/red_asterisk.png" alt="required"/>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblQty" runat="server" Text="Qty. to print:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
            </td>
            <td>
                <img src="images/red_asterisk.png" alt="required"/>
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
    </table>
    <table>
        <tr>
            <td>
                <br />
            </td>
            <td>
                <p>Please upload desired artwork.</p>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFileUpload" runat="server" Text="Upload File: " Style="float: right">
                </asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload" runat="server" />                
            </td>
            <td>
                <img src="images/red_asterisk.png" alt="required"/>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnFileUpload" runat="server" Text="Upload" OnClick="btnFileUpload_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblUploadedFileHeader" runat="server" Text="Uploaded File:" Visible="false" style="color:Red; float:right">
                </asp:Label>
            </td>
            <td>
                <asp:Label ID="lblUploadedFile" runat="server" Visible="false">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <br />
                <br />
            </td>
            <td>
                <asp:Button ID="createPay" Text="Save Order" runat="server" OnClick="saveOrder" />
                <asp:Button ID="clear" Text="Clear" runat="server" OnClick="func_clear" />
            </td>
        </tr>
    </table>
</asp:Content>
