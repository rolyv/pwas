<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>Hello world!</p>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="permissionID" DataSourceID="SqlDataSource1" 
            EmptyDataText="There are no data records to display.">
            <Columns>
                <asp:BoundField DataField="permissionID" HeaderText="permissionID" 
                    ReadOnly="True" SortExpression="permissionID" />
                <asp:BoundField DataField="roleID" HeaderText="roleID" 
                    SortExpression="roleID" />
                <asp:BoundField DataField="object" HeaderText="object" 
                    SortExpression="object" />
                <asp:BoundField DataField="obj_update" HeaderText="obj_update" 
                    SortExpression="obj_update" />
                <asp:BoundField DataField="obj_view" HeaderText="obj_view" 
                    SortExpression="obj_view" />
                <asp:BoundField DataField="obj_create" HeaderText="obj_create" 
                    SortExpression="obj_create" />
                <asp:BoundField DataField="obj_delete" HeaderText="obj_delete" 
                    SortExpression="obj_delete" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:PWAS_DBConnectionString %>" 
            DeleteCommand="DELETE FROM [RolePermission] WHERE [permissionID] = @permissionID" 
            InsertCommand="INSERT INTO [RolePermission] ([roleID], [object], [obj_update], [obj_view], [obj_create], [obj_delete]) VALUES (@roleID, @object, @obj_update, @obj_view, @obj_create, @obj_delete)" 
            ProviderName="<%$ ConnectionStrings:PWAS_DBConnectionString.ProviderName %>" 
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
    </div>
    </form>
</body>
</html>
