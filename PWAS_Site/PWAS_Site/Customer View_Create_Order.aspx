<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer View_Create_Order.aspx.cs" Inherits="PWAS_Site.Customer_View_Create_Order" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml" >

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Untitled Document</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="XYZ.js"></script>
</head>

<body >
<div id="header">
<div class="top-head">
<div class="logo">Printing at the Speed of Life.</div>
    <div class="nav-bar">

       <ul> 
    <li><a href="index.aspx" class="ist">Home</a></li>
    <li><a href="about-us.aspx" class="two">About Us</a></li>
    <li><a href="/CEN/index.jsp?logoff=true" class="three">Logout</a></li>
    <li><a href="projects.aspx" class="four">Projects</a></li>
    <li><a href="contact-us.aspx" class="five">Contacts</a></li>
</ul> 

<!--Hidden Pop up login prompt-->
	   <div id="loginDiv">
		<form name="loginForm">
            <table>
                <tr><td>Username: </td><td><input type="text" name="user" /><br/></td></tr>
		        <tr><td>Password: </td><td><input type="password" name="pwd"/><br /></td></tr>
            </table>
        </form>
        <table align="center">
            <tr><td  align="center"><button onclick="doLogin();">Login</button><button onclick="showLogin(false);">Cancel</button></td></tr>
            <tr><td><div id="ERROR"></div></td></tr>
		</table>
	</div>

</div>
</div>

<div class="head-cont">
    <span>XYZ Printing is your one-stop shop for all your printing needs.</span><br />
     Enjoy your stay.
</div>

<div class="box-outs">
<div class="gray-box">
<img src="images/ic-1.gif" alt="" class="img-box" /> Place an <br />
Order
<br />
<a href="#">Click here</a></div>

<div class="gray-box">
<img src="images/ic-2.gif" alt="" class="img-box" />
View Order <br />Status<br />
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
<h2><img src="images/ic-4.gif" alt="" class="img-box-2" />Menu</h2>

<ul>
    <li><a href="#">Place an Order.</a></li>
    <li><a href="#">View Order Status.</a></li>
    <li><a href="#">Edit Profile.</a></li>
    <li class="last"><a href="#">Search.</a></li>
</ul>
</div>

<div class="left-body-bt">
<h2><img src="images/ic-4.gif" alt="" class="img-box-2" />Company News!</h2>
<strong>Vestibulum sit amet nulla era</strong>
<ul>
<li>20th May 2009</li>
</ul><p><a href="#">Lorem ipsum dolor</a> sit amet, consectetur.</p>



<img src="images/br-line.gif" alt="" />

<ul>
<li>20th May 2009</li>
</ul>

<p><a href="#">Lorem ipsum dolor</a> sit amet, consectetur.</p>
</div>
</div>


<div class="right-body">
    <form id="createorder" runat="server" >
        <h1>Create new order</h1>
            <td align="left">
	            <asp:Label ID="lblNotify" runat="server" Visible="false"></asp:Label>
            </td>
            
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
		                <asp:TextBox ID="txtFinalSizeX" runat="server"></asp:TextBox>X
		                <asp:TextBox ID="txtFinalSizeY" runat="server"></asp:TextBox>
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
		            <td align="left">
		                <asp:CheckBox ID="chkTwoSide" runat="server" Text="Two Sided"/>
		            </td>
		        </tr>
		        <tr>
		            <td align="left">
		                <asp:CheckBox ID="chkfolded" runat="server" Text="Folded"/>
		            </td>
		        </tr>
		        <tr>
		            <td align="left">
		                <asp:CheckBox ID="chkShip" runat="server" Text="Ship"/>
		            </td>
		        </tr>
	        </table>
        <br /> 
            <asp:Button ID="createPay" Text="Create & Pay" runat="server" OnClick="func_createPay" />
            <asp:Button ID="clear" Text="Clear" runat="server" OnClick="func_clear" />
            
    </form>
</div>

<div class="clear"></div>

</div>


<div id="footer-back">
<div class="footer-right"><a href="index.aspx">Home</a>   |   <a href="about-us.aspx">About Us</a>   |   <a href="projects.aspx">Recent Projects</a> |   <a href="support.aspx">Support</a>   |   <a href="privacy.aspx">Privacy</a>   |   <a href="contact-us.aspx">Contact Us</a>
<br />
<span>&copy; Copyright XYZ Printing Co. All Right Reserved</span></div>
</div>
</body>
</html>

