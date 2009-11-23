   
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
<img src="images/ic-1.gif" alt="" class="img-box" /> Create a <br />
Run
<br />
<a href="#">Click here</a></div>

<div class="gray-box">
<img src="images/ic-2.gif" alt="" class="img-box" />
Populate a<br />Run<br />
<a href="#">click here</a></div>

<div class="gray-box">
<img src="images/ic-3.gif" alt="" class="img-box" />
System Support<br />
<a href="#">click here</a></div>
</div>
</div>

<div id="body-part">
<div class="left-body">
<div class="left-body-top">
<h2><img src="images/ic-4.gif" alt="" class="img-box-2" />Menu</h2>



<ul>
<li><a href="#">Create a run.</a></li>
<li><a href="#">Populate a run.</a></li>
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

<h1>Incoming Orders</h1>
<h3>Move Selected Jobs to -> <select><option>Run 471</option></select></h3>
<table id="orderHistoryTable">
<tr class="orderTopRow"><td>Select</td><td>Job #</td><td>Job Name</td><td>Status</td><td>Date</td></tr>
<tr class="orderRow"><td><input type="checkbox"></td><td>34526</td><td>500 Business Cards</td><td class="printingCell">Unassigned</td><td>10/05/2009</td></tr>
<tr class="orderRow"><td><input type="checkbox"></td><td>87623</td><td>1000 Flyers</td><td class="printingCell">Unassigned</td><td>10/04/2009</td></tr>
<tr class="orderRow"><td><input type="checkbox"></td><td>43353</td><td>5 Posters</td><td class="printingCell">Unassigned</td><td>10/04/2009</td></tr>
<tr class="orderRow"><td><input type="checkbox"></td><td>12341</td><td>75 Invitations</td><td class="shippedCell">Assigned (471)</td><td>05/24/2009</td></tr>
<tr class="orderRow"><td><input type="checkbox"></td><td>45435</td><td>2000 Postcards</td><td class="shippedCell">Assigned (471)</td><td>01/04/2008</td></tr>

</table>

<h1>Created Runs</h1>
<Button> Print selected </button>
<table id="orderHistoryTable">
<tr class="orderTopRow"><td>Select</td><td>Run ID</td><td>Run type</td><td>Status</td><td>Date</td></tr>
<tr class="orderRow"><td><input type="checkbox"></td><td>471</td><td>500 23 x 29 Glossy Heavy</td><td class="printingCell">Open</td><td>10/05/2009</td></tr>
<tr class="orderRow"><td><input type="checkbox"></td><td>470</td><td>1000 23 x 29 Glossy Light</td><td class="printingCell">Open</td><td>10/04/2009</td></tr>
<tr class="orderRow"><td><input type="checkbox"></td><td>469</td><td>500 23 x 29 Matte Heavy</td><td class="printingCell">Open</td><td>10/04/2009</td></tr>
<tr class="orderRow"><td></td><td>468</td><td>200 23 x 29 Glossy Heavy</td><td class="shippedCell">Printing </td><td>10/02/2009</td></tr>
<tr class="orderRow"><td></td><td>467</td><td>500 23 x 29 Glossy Heavy</td><td class="shippedCell">Printing </td><td>10/01/2009</td></tr>

</table>
<br/>
<img src="images/br-body.gif" alt="" />
<br/>
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
