
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Untitled Document</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="XYZ.js"></script>
</head>

<body >
    <form id="form1" runat="server">
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
        <table>
        <tr>
        	<td>Username: </td><td><input type="text" name="user" /><br/></td>
        </tr>
		<tr>
        	<td>Password: </td><td><input type="password" name="pwd"/><br /></td>
        </tr>    
        </table>
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
<h1>User Roles</h1>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="userID" DataSourceID="SqlDataSource1" 
        EmptyDataText="There are no data records to display." ForeColor="#333333" 
        GridLines="None">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="userID" HeaderText="User ID" ReadOnly="True" 
                SortExpression="userID" />
            <asp:BoundField DataField="firstName" HeaderText="First Name" 
                SortExpression="firstName" />
            <asp:BoundField DataField="lastName" HeaderText="Last Name" 
                SortExpression="lastName" />
            <asp:BoundField DataField="roleID" HeaderText="Role ID" 
                SortExpression="roleID" />
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:PWAS_DBConnectionString1 %>" 
        DeleteCommand="DELETE FROM [User] WHERE [userID] = @userID" 
        InsertCommand="INSERT INTO [User] ([firstName], [lastName], [company], [email], [homePhone], [otherPhone], [s_address1], [s_address2], [s_city], [s_state], [s_zip], [cc_num], [cc_type], [exp_date], [b_address1], [b_address2], [b_city], [b_state], [b_zip], [roleID], [password]) VALUES (@firstName, @lastName, @company, @email, @homePhone, @otherPhone, @s_address1, @s_address2, @s_city, @s_state, @s_zip, @cc_num, @cc_type, @exp_date, @b_address1, @b_address2, @b_city, @b_state, @b_zip, @roleID, @password)" 
        ProviderName="<%$ ConnectionStrings:PWAS_DBConnectionString1.ProviderName %>" 
        SelectCommand="SELECT [userID], [firstName], [lastName], [company], [email], [homePhone], [otherPhone], [s_address1], [s_address2], [s_city], [s_state], [s_zip], [cc_num], [cc_type], [exp_date], [b_address1], [b_address2], [b_city], [b_state], [b_zip], [roleID], [password] FROM [User]" 
        UpdateCommand="UPDATE [User] SET [firstName] = @firstName, [lastName] = @lastName, [company] = @company, [email] = @email, [homePhone] = @homePhone, [otherPhone] = @otherPhone, [s_address1] = @s_address1, [s_address2] = @s_address2, [s_city] = @s_city, [s_state] = @s_state, [s_zip] = @s_zip, [cc_num] = @cc_num, [cc_type] = @cc_type, [exp_date] = @exp_date, [b_address1] = @b_address1, [b_address2] = @b_address2, [b_city] = @b_city, [b_state] = @b_state, [b_zip] = @b_zip, [roleID] = @roleID, [password] = @password WHERE [userID] = @userID">
        <DeleteParameters>
            <asp:Parameter Name="userID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="firstName" Type="String" />
            <asp:Parameter Name="lastName" Type="String" />
            <asp:Parameter Name="company" Type="String" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="homePhone" Type="String" />
            <asp:Parameter Name="otherPhone" Type="String" />
            <asp:Parameter Name="s_address1" Type="String" />
            <asp:Parameter Name="s_address2" Type="String" />
            <asp:Parameter Name="s_city" Type="String" />
            <asp:Parameter Name="s_state" Type="String" />
            <asp:Parameter Name="s_zip" Type="String" />
            <asp:Parameter Name="cc_num" Type="String" />
            <asp:Parameter Name="cc_type" Type="String" />
            <asp:Parameter Name="exp_date" Type="String" />
            <asp:Parameter Name="b_address1" Type="String" />
            <asp:Parameter Name="b_address2" Type="String" />
            <asp:Parameter Name="b_city" Type="String" />
            <asp:Parameter Name="b_state" Type="String" />
            <asp:Parameter Name="b_zip" Type="String" />
            <asp:Parameter Name="roleID" Type="Int32" />
            <asp:Parameter Name="password" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="firstName" Type="String" />
            <asp:Parameter Name="lastName" Type="String" />
            <asp:Parameter Name="company" Type="String" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="homePhone" Type="String" />
            <asp:Parameter Name="otherPhone" Type="String" />
            <asp:Parameter Name="s_address1" Type="String" />
            <asp:Parameter Name="s_address2" Type="String" />
            <asp:Parameter Name="s_city" Type="String" />
            <asp:Parameter Name="s_state" Type="String" />
            <asp:Parameter Name="s_zip" Type="String" />
            <asp:Parameter Name="cc_num" Type="String" />
            <asp:Parameter Name="cc_type" Type="String" />
            <asp:Parameter Name="exp_date" Type="String" />
            <asp:Parameter Name="b_address1" Type="String" />
            <asp:Parameter Name="b_address2" Type="String" />
            <asp:Parameter Name="b_city" Type="String" />
            <asp:Parameter Name="b_state" Type="String" />
            <asp:Parameter Name="b_zip" Type="String" />
            <asp:Parameter Name="roleID" Type="Int32" />
            <asp:Parameter Name="password" Type="String" />
            <asp:Parameter Name="userID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
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



    </form>



</body>
</html>
