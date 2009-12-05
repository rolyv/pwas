<%@ Page Language="C#" MasterPageFile="~/PWAS.Master" AutoEventWireup="true" CodeBehind="workerView_CreatePrintRun.aspx.cs"
    Inherits="PWAS_Site.workerView_CreatePrintRun" Title="Create Print Run" %>

<asp:Content ID="Content1" ContentPlaceHolderID="page_title" runat="server">
Create Print Run
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="page_head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 99px;
        }
        .style2
        {
            width: 173px;
        }
    </style>
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
    Create Print Run
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="body_content" runat="server">
    <asp:Label ID="notifyMsg" runat="server" Visible="false"></asp:Label>
    <table width="300">
        <tr>
            <td class="style1">
                Print Run Name:
            </td>
            <td class="style2">
                <asp:TextBox ID="runName" runat="server" Width="165px" ></asp:TextBox>
            </td>
            <td>
                <img src="images/red_asterisk.png" style="width: 11px; height: 11px" /></td>
        </tr>
        <tr>
            <td class="style1">
                Run Size:
            </td>
            <td class="style2">
                <asp:TextBox ID="runWidth" runat="server" Width="75px"></asp:TextBox>X<asp:TextBox ID="runHeight" runat="server" Width="75px"></asp:TextBox>
            </td>
            <td>
                <img src="images/red_asterisk.png" style="width: 11px; height: 11px" /></td>
        </tr>
        <tr>
            <td class="style1">
                Run Quantity:
            </td>
            <td class="style2">
                <asp:TextBox ID="runQuantity" runat="server" Width="165px" ></asp:TextBox>
            </td>
            <td>
                <img src="images/red_asterisk.png" style="width: 11px; height: 11px" /></td>
        </tr>
        <tr>
            <td class="style1">
                Stock Finish
            </td>
            <td class="style2">
                <asp:DropDownList ID="runFinish" runat="server">
                    <asp:ListItem>Glossy</asp:ListItem>
                    <asp:ListItem>Flat</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <img src="images/red_asterisk.png" style="width: 11px; height: 11px" /></td>
        </tr>
        <tr>
            <td class="style1">
                Stock Weight:
            </td>
            <td class="style2">
                <asp:DropDownList ID="runWeight" runat="server">
                    <asp:ListItem>Heavy</asp:ListItem>
                    <asp:ListItem>Light</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <img src="images/red_asterisk.png" style="width: 11px; height: 11px" /></td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td class="style2">
                <asp:Button ID="Button1" runat="server" Text="Create Print Run" Width="110px" OnClick="createPrintRun"/>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
