<%@ Page Language="C#" MasterPageFile="~/PWAS_Out.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PWAS_Site.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="page_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="page_head" runat="server">
 <style type="text/css">
        #tableLoginInformation
        {
            width: 300px;
        }
        #tableContactInformation
        {
            width: 300px;
        }
        #tableBillingAddress
        {
            width: 300px;
        }
        .style1
        {
            width: 125px;
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
<asp:Content ID="Content10" ContentPlaceHolderID="body_title" runat="server">
    Registration
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="body_content" runat="server">
<table width="600">
                <tr>
                    <td>
                        <asp:Table runat="server" ID="tableErrorMessage" Visible="false">
                            <asp:TableRow>
                                <asp:TableCell HorizontalAlign="right">
                                    <h3><asp:Label ID="lblErrorMessage" runat="server" Style="color: red;" Text="Error" Visible="false"></asp:Label></h3>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>
                            Login Information</h3>
                        <table id="tableLoginInformation">
                            <tr>
                                <td align="right" class="style1">
                                    <asp:Label ID="lblEmailAddress" runat="server" Text="Email Address:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <img src="images/red_asterisk.png" alt="required" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style1">
                                    <asp:Label ID="lblPassword" runat="server" Text="Password:" ></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                </td>
                                <td>
                                    <img src="images/red_asterisk.png" alt="required"  />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style1">
                                    <asp:Label ID="lblPasswordConfirm" runat="server" Text="Confirm Password:" ></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password" ></asp:TextBox>
                                </td>
                                <td>
                                    <img src="images/red_asterisk.png" alt="required" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>
                            Contact Information</h3>
                        <table id="tableContactInformation">
                            <tr>
                                <td align="right" class="style1">
                                    <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <img src="images/red_asterisk.png" alt="required" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style1">
                                    <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <img src="images/red_asterisk.png" alt="required" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style1">
                                    <asp:Label ID="lblCompanyName" runat="server" Text="Company Name:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style1">
                                    <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone #:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <img src="images/red_asterisk.png" alt="required" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>
                            Billing Address</h3>
                        <table id="tableBillingAddress">
                            <tr>
                                <td align="right" class="style1">
                                    <asp:Label ID="lblBillAddressLine1" runat="server" Text="Address Line 1:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBillAddressLine1" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <img src="images/red_asterisk.png" alt="required" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style1">
                                    <asp:Label ID="lblBillAddressLine2" runat="server" Text="Address Line 2:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBillAddressLine2" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style1">
                                    <asp:Label ID="lblBillCity" runat="server" Text="City:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBillCity" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <img src="images/red_asterisk.png" alt="required" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style1">
                                    <asp:Label ID="lblBillState" runat="server" Text="State:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBillState" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <img src="images/red_asterisk.png" alt="required" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style1">
                                    <asp:Label ID="lblBillZipCode" runat="server" Text="Zip Code:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBillZipCode" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <img src="images/red_asterisk.png" alt="required" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnRegister" runat="server" Text="Register" style="margin:10px 0 0 133px" OnClick="btnRegister_Click" />
                    </td>
                </tr>
                <br />
            </table>
            <br />
</asp:Content>
