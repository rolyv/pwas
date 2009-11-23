
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
<li>
	
           <a href="/CEN/index.jsp?logoff=true" class="three">Logout</a> 
	 
	    
</li>
<li><a href="projects.aspx" class="four">Projects</a></li>
<li><a href="contact-us.aspx" class="five">Contacts</a></li>
</ul> 

		<!--Hidden Pop up login prompt-->
	<div id="loginDiv">
		<form name="loginForm">
        <table>
        <tr>
        	<td>Username: </td><td><input type="text" name="user" /><br/></td>
        </tr>
		<tr>
        	<td>Password: </td><td><input type="password" name="pwd"/><br /></td>
        </tr>    
        </table>
        </form>
        <table align="center">
         <tr>
        	<td  align="center"><button onclick="doLogin();">Login</button><button onclick="showLogin(false);">Cancel</button></td>
        </tr>
        <tr><td><div id="ERROR"></div></td></tr>
		</table>
		
	</div>

</div>
</div>

<div class="head-cont">
<span>XYZ Printing is your one-stop shop for all your printing needs.</span><br />
</b> Enjoy your stay.
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
<h1>Profile</h1>
<table width="600">
<tr>
<td>
	<h3>Contact Information</h3>
	<table id="ContactTable" >
		<tr>
			<td align="right">First Name:</td>
			<td align="left"><input value="Masoud"></td>
		</tr>
		
		<tr>
			<td align="right">Last Name:</td>
			<td align="left"><input value="Sadjadi"></td>
		</tr>
		<tr>
			<td align="right">Company Name:</td>
			<td align="left"><input value="M.S.Soft Inc."></td>
		</tr>
		<tr>
			<td align="right">Email Address:</td>
			<td align="left"><input value="M.S@MSSoft.com"></td>
		</tr>
		<tr>
			<td align="right">Phone #:</td>
			<td align="left"><input value="305-345-6321"></td>
		</tr>
	</table>
</td>
<td>
	<h3>Shipping Information</h3>
	<table id="ContactTable">
		<tr>
			<td align="right">Address Line 1:</td>
			<td align="left"><input value="123 Main St."></td>
		</tr>
		
		<tr>
			<td align="right">Adress Line 2:</td>
			<td align="left"><input value="Suite 1023"></td>
		</tr>
		<tr>
			<td align="right">City:</td>
			<td align="left"><input value="Miami Beach"></td>
		</tr>
		<tr>
			<td align="right">State:</td>
			<td align="left"><select><option>FL</option></select></td>
		</tr>
		<tr>
			<td align="right">Zip code:</td>
			<td align="left"><input value="33131"></td>
		</tr>
	</table>
</td>
</tr>
<tr>
<td>	
	<h3>Billing Information</h3>
	<table id="ContactTable">
		<tr>
			<td align="right">Credit Card #</td>
			<td align="left"><input value="3713 3452 2567 123"></td>
		</tr>
		
		<tr>
			<td align="right">Card Type</td>
			<td align="left"><select><option>Amex</option></select></td>
		</tr>
		<tr>
			<td align="right">Exp. Date</td>
			<td align="left"><input value="10/10"></td>
		</tr>
		<tr>
			<td align="right">Security Code</td>
			<td align="left"><input value="5643"></td>
		</tr>
		<tr>
			<td align="right">Name on Card</td>
			<td align="left"><input value="Masoud Sadjadi"></td>
		</tr>
	</table>
</td>
<td>
	<h3>Billing Address</h3>
	<table id="ContactTable">
		<tr>
			<td align="right">Address Line 1:</td>
			<td align="left"><input value="123 Main St."></td>
		</tr>
		
		<tr>
			<td align="right">Adress Line 2:</td>
			<td align="left"><input value="Suite 1023"></td>
		</tr>
		<tr>
			<td align="right">City:</td>
			<td align="left"><input value="Miami Beach"></td>
		</tr>
		<tr>
			<td align="right">State:</td>
			<td align="left"><select><option>FL</option></select></td>
		</tr>
		<tr>
			<td align="right">Zip code:</td>
			<td align="left"><input value="33131"></td>
		</tr>
	</table>
</td>
</tr>
<br/>
</table>	
<button>Update Profile</button>

<br />
<img src="images/br-body.gif" alt="" />

<h2><img src="images/ic-5.gif" alt="" class="img-box-2" />Discounted Products</h2>

<div class="right-content">
<img src="images/img_02.gif" alt="" />
<p><strong>20% Off Blueprints</strong><br />
For your construction needs </p>
<a href="#"><img src="images/read-more.gif" alt="" border="0" /></a>
</div>

<div class="left-content">
<img src="images/img_03.gif" alt="" />
<p><strong>10% off Postcards.</strong><br />
Glossy full color </p>
<a href="#"><img src="images/read-more.gif" alt="" border="0" /></a>
</div>

<div class="left-content">
<img src="images/img_04.gif" alt="" />
<p><strong>Call for Website Specials!</strong><br />
You'll be surprised </p>
<a href="#"><img src="images/read-more.gif" alt="" border="0" /></a>
</div>

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
