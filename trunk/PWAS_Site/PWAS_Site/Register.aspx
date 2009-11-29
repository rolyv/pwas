﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PWAS_Site.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="XYZ.js"></script>

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

</head>
<body>
    <div id="header">
        <div class="top-head">
            <div class="logo">
                Printing at the Speed of Life.</div>
            <div class="nav-bar">
                <ul>
                    <li><a href="index.aspx" class="ist">Home</a></li>
                    <li><a href="about-us.aspx" class="two">About Us</a></li>
                    <li><a href="login.aspx" class="three">Login</a></li>
                    <li><a href="projects.aspx" class="four">Projects</a></li>
                    <li><a href="contact-us.aspx" class="five">Contacts</a></li>
                </ul>
                <!--Hidden Pop up login prompt-->
            </div>
        </div>
        <div class="head-cont">
            <span>XYZ Printing is your one-stop shop for all your printing needs.</span><br />
            </b> Enjoy your stay.
        </div>
        <div class="box-outs">
            <div class="gray-box">
                <img src="images/ic-1.gif" alt="" class="img-box" />
                Place an
                <br />
                Order
                <br />
                <a href="#">Click here</a></div>
            <div class="gray-box">
                <img src="images/ic-2.gif" alt="" class="img-box" />
                View Order
                <br />
                Status<br />
                <a href="#">click here</a></div>
            <div class="gray-box">
                <img src="images/ic-3.gif" alt="" class="img-box" />
                Customer Support<br />
                <a href="#">click here</a></div>
        </div>
    </div>
    <div id="body-part">
        <div class="left-body">
            <div class="left-body-top">
                <h2>
                    <img src="images/ic-4.gif" alt="" class="img-box-2" />Menu</h2>
                <ul>
                    <li><a href="#">Place an Order.</a></li>
                    <li><a href="#">View Order Status.</a></li>
                    <li><a href="#">Edit Profile.</a></li>
                    <li class="last"><a href="#">Search.</a></li>
                </ul>
            </div>
            <div class="left-body-bt">
                <h2>
                    <img src="images/ic-4.gif" alt="" class="img-box-2" />Company News!</h2>
                <strong>Vestibulum sit amet nulla era</strong>
                <ul>
                    <li>20th May 2009</li>
                </ul>
                <p>
                    <a href="#">Lorem ipsum dolor</a> sit amet, consectetur.</p>
                <img src="images/br-line.gif" alt="" />
                <ul>
                    <li>20th May 2009</li>
                </ul>
                <p>
                    <a href="#">Lorem ipsum dolor</a> sit amet, consectetur.</p>
            </div>
        </div>
        <div class="right-body">
            <h1>
                Registration Form</h1>
            <form id="registrationForm" runat="server">
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
                            </tr>
                            <tr>
                                <td align="right" class="style1">
                                    <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style1">
                                    <asp:Label ID="lblPasswordConfirm" runat="server" Text="Confirm Password:" ></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPasswordConfirm" runat="server" TextMode="Password" ></asp:TextBox>
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
                            </tr>
                            <tr>
                                <td align="right" class="style1">
                                    <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
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
                            </tr>
                            <tr>
                                <td align="right" class="style1">
                                    <asp:Label ID="lblBillState" runat="server" Text="State:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBillState" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style1">
                                    <asp:Label ID="lblBillZipCode" runat="server" Text="Zip Code:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBillZipCode" runat="server"></asp:TextBox>
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
            </form>
            <br />
            <img src="images/br-body.gif" alt="" />
        </div>
        <div class="clear">
        </div>
    </div>
    <div id="footer-back">
        <div class="footer-right">
            <a href="index.aspx">Home</a> | <a href="about-us.aspx">About Us</a> | <a href="projects.aspx">
                Recent Projects</a> | <a href="support.aspx">Support</a> | <a href="privacy.aspx">Privacy</a>
            | <a href="contact-us.aspx">Contact Us</a>
            <br />
            <span>&copy; Copyright XYZ Printing Co. All Right Reserved</span></div>
    </div>
</body>
</html>