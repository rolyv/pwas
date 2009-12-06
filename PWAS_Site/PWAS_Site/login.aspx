<%@ Page Language="C#" MasterPageFile="~/PWAS_Out.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PWAS_Site.login" Title="Untitled Page" %>
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
<asp:Content ID="Content9" ContentPlaceHolderID="body_title" runat="server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="body_content" runat="server">
<div>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Email Address"></asp:Label>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:TextBox ID="loginEmail" runat="server" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:TextBox ID="pwd" runat="server" TextMode="password" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <a href="Register.aspx">Register</a>
                            &nbsp;&nbsp;&nbsp;
                            <a href="ForgotPassword.aspx">Forgot Password</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="loginSubmit" runat="server" Text="Login" OnClick="doLogin" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="messageLabel" runat="server" Text="" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
</asp:Content>
