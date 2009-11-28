
    
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
<h1>Roles</h1>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                DataKeyNames="roleID" DataSourceID="SqlDataSource1" 
                EmptyDataText="There are no data records to display." ForeColor="#333333" 
                GridLines="None">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                        ShowSelectButton="True" />
                    <asp:BoundField DataField="roleID" HeaderText="Role ID" ReadOnly="True" 
                        SortExpression="roleID" />
                    <asp:BoundField DataField="role_name" HeaderText="Role Name" 
                        SortExpression="role_name" />
                    <asp:BoundField DataField="role_desc" HeaderText="Role Desc" 
                        SortExpression="role_desc" />
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
                DeleteCommand="DELETE FROM [Role] WHERE [roleID] = @roleID" 
                InsertCommand="INSERT INTO [Role] ([role_name], [role_desc]) VALUES (@role_name, @role_desc)" 
                ProviderName="<%$ ConnectionStrings:PWAS_DBConnectionString1.ProviderName %>" 
                SelectCommand="SELECT [roleID], [role_name], [role_desc] FROM [Role]" 
                UpdateCommand="UPDATE [Role] SET [role_name] = @role_name, [role_desc] = @role_desc WHERE [roleID] = @roleID">
                <DeleteParameters>
                    <asp:Parameter Name="roleID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="role_name" Type="String" />
                    <asp:Parameter Name="role_desc" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="role_name" Type="String" />
                    <asp:Parameter Name="role_desc" Type="String" />
                    <asp:Parameter Name="roleID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <h1>Role Permissions</h1>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                DataKeyNames="permissionID" DataSourceID="SqlDataSource2" 
                EmptyDataText="There are no data records to display." ForeColor="#333333" 
                GridLines="None">
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                        ShowSelectButton="True" />
                    <asp:BoundField DataField="permissionID" HeaderText="Permission ID" 
                        ReadOnly="True" SortExpression="permissionID" />
                    <asp:BoundField DataField="roleID" HeaderText="Role ID" 
                        SortExpression="roleID" />
                    <asp:BoundField DataField="object" HeaderText="Object" 
                        SortExpression="object" />
                    <asp:BoundField DataField="obj_update" HeaderText="Update" 
                        SortExpression="obj_update" />
                    <asp:BoundField DataField="obj_view" HeaderText="View" 
                        SortExpression="obj_view" />
                    <asp:BoundField DataField="obj_create" HeaderText="Create" 
                        SortExpression="obj_create" />
                    <asp:BoundField DataField="obj_delete" HeaderText="Delete" 
                        SortExpression="obj_delete" />
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:PWAS_DBConnectionString1 %>" 
                DeleteCommand="DELETE FROM [RolePermission] WHERE [permissionID] = @permissionID" 
                InsertCommand="INSERT INTO [RolePermission] ([roleID], [object], [obj_update], [obj_view], [obj_create], [obj_delete]) VALUES (@roleID, @object, @obj_update, @obj_view, @obj_create, @obj_delete)" 
                ProviderName="<%$ ConnectionStrings:PWAS_DBConnectionString1.ProviderName %>" 
                SelectCommand="SELECT [permissionID], [roleID], [object], [obj_update], [obj_view], [obj_create], [obj_delete] FROM [RolePermission]" 
                UpdateCommand="UPDATE [RolePermission] SET [roleID] = @roleID, [object] = @object, [obj_update] = @obj_update, [obj_view] = @obj_view, [obj_create] = @obj_create, [obj_delete] = @obj_delete WHERE [permissionID] = @permissionID">
                <DeleteParameters>
                    <asp:Parameter Name="permissionID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="roleID" Type="Int32" />
                    <asp:Parameter Name="object" Type="String" />
                    <asp:Parameter Name="obj_update" Type="Int32" />
                    <asp:Parameter Name="obj_view" Type="Int32" />
                    <asp:Parameter Name="obj_create" Type="Int32" />
                    <asp:Parameter Name="obj_delete" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="roleID" Type="Int32" />
                    <asp:Parameter Name="object" Type="String" />
                    <asp:Parameter Name="obj_update" Type="Int32" />
                    <asp:Parameter Name="obj_view" Type="Int32" />
                    <asp:Parameter Name="obj_create" Type="Int32" />
                    <asp:Parameter Name="obj_delete" Type="Int32" />
                    <asp:Parameter Name="permissionID" Type="Int32" />
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
