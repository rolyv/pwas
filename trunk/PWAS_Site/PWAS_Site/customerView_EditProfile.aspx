<%@ Page Title="" Language="C#" MasterPageFile="~/PWAS.Master" AutoEventWireup="true" CodeBehind="customerView_EditProfile.aspx.cs" Inherits="PWAS_Site.customerView_EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="page_title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="page_head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 185px;
        }
        .style2
        {
            width: 93px;
        }
        .style4
        {
            width: 330px;
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
    Edit Profile
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="body_content" runat="server">
    <table width="600">
        <tr>
            <td>
                <asp:Table runat="server" ID="tableErrorMessage" Visible="false">
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="right">
                            <h3>
                                <asp:Label ID="lblErrorMessage" runat="server" Style="color: red;" Text="Error" Visible="false"></asp:Label></h3>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </td>
        </tr>
    </table>
    <table width="600">
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
                            <asp:TextBox ID="txtEmailAddress" runat="server" Width="225px"></asp:TextBox>
                        </td>
                        <td>
                            <img src="images/red_asterisk.png" alt="required" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style1">
                            <asp:Label ID="lblNewPassword" runat="server" Text="New Password:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" Width="225px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style1">
                            <asp:Label ID="lblNewPasswordConfirm" runat="server" Text="Confirm New Password:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtNewPasswordConfirm" runat="server" TextMode="Password" Width="225px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table width="600">
                    <tr>
                        <td class="style4">
                            <asp:Button ID="btnEditLoginInfo" runat="server" Text="Submit" Style="float: right;
                                margin-top: 10px;" OnClick="btnEditLoginInfo_Click" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="600">
        <tr>
            <td>
                <h3>
                    Contact Information</h3>
                <table id="tableContactInformation">
                    <tr>
                        <td align="right">
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
                        <td align="right">
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
                        <td align="right">
                            <asp:Label ID="lblCompanyName" runat="server" Text="Company Name:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
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
                        <td align="right">
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
                        <td align="right">
                            <asp:Label ID="lblBillAddressLine2" runat="server" Text="Adress Line 2:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBillAddressLine2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
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
                        <td align="right">
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
                        <td align="right">
                            <asp:Label ID="lblBillZipCode" runat="server" Text="Zip code:"></asp:Label>
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
            <td>
                <h3>
                    Shipping Address</h3>
                <table id="tableShippingAddress">
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblShipAddressLine1" runat="server" Text="Address Line 1:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtShipAddressLine1" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblShipAddressLine2" runat="server" Text="Address Line 2:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtShipAddressLine2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblShipCity" runat="server" Text="City:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtShipCity" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblShipState" runat="server" Text="State:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtShipState" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblShipZipCode" runat="server" Text="Zip code:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtShipZipCode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <h3>
                    Credit Card Information</h3>
                <table id="tableCreditCardInformation">
                    <tr>
                        <td align="right" class="style2">
                            <asp:Label ID="lblCreditCardNumber" runat="server" Text="Credit Card #"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtCreditCardNumber" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style2">
                            <asp:Label ID="lblCardType" runat="server" Text="Card Type"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddCardType" runat="server">
                                <asp:ListItem Value="AX">AMEX</asp:ListItem>
                                <asp:ListItem Value="VI">Visa</asp:ListItem>
                                <asp:ListItem Value="MC">MasterCard</asp:ListItem>
                                <asp:ListItem Value="DV">Discover</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style2">
                            <asp:Label ID="lblExpDate" runat="server" Text="Exp. Date"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtExpDate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style2">
                            <asp:Label ID="lblSecurityCode" runat="server" Text="Security Code"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtSecurityCode" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style2">
                            <asp:Label ID="lblNameOnCard" runat="server" Text="Name on Card"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtNameOnCard" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="600">
        <tr>
            <td class="style4">
                <asp:Button ID="btnEditOtherInfo" runat="server" Text="Submit" Style="float: right;
                    margin-top: 10px;" OnClick="btnEditOtherInfo_Click" />
            </td>
            <td>
            </td>
        </tr>
        <br />
    </table>
    <br />
</asp:Content>
