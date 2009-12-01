<%@ Page AspCompat="true" Title="" Language="C#" MasterPageFile="~/PWAS_Out.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="PWAS_Site.WebForm3" %>
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
    Forgot Password
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="body_content" runat="server">
    <asp:Table runat="server" ID="tableErrorMessage">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left">
                <h4>
                    <asp:Label ID="lblResetEmailMessage" runat="server" Style="color: Black;" Text="Please enter the email address associated with the account."></asp:Label>
                </h4>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <table>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblEmailAddress" Text="Email Address:"></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEmailAddress" Width="200"></asp:TextBox>
            </td>
            <td>
                <asp:Label runat="server" ID="lblErrorMessage" Text="Please enter a valid email address" Visible="false" Style="color:Red" ></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Button runat="server" ID="btnResetPassword" OnClick="btnResetPassword_Click"
                    Text="Reset Password" style="margin:10px 0 0 90px"/>
    <br /><br />
</asp:Content>
