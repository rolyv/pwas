<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PWAS_Site.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
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
                Login
            </h1>
            <form id="form1" runat="server">
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
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="loginSubmit" runat="server" Text="Login" OnClick="doLogin" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="messageLabel" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                    </tr>
                </table>
            </div>
            </form>
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
