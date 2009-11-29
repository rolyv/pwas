using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWAS.Model;
using System.Data.Linq;

namespace PWAS.DataAccess.SQLRepositories
{
    public class RolePermissionRepository : PWAS.DataAccess.Interfaces.IRolePermissionRepository
    {
        private Table<RolePermission> rolePermissionTable;

        public RolePermissionRepository(string connectionString)
        {
            rolePermissionTable = new PWASDataContext(connectionString).RolePermissions;
        }

        public void AddRolePermission(RolePermission rolePermission)
        {
            rolePermissionTable.InsertOnSubmit(rolePermission);
        }

        public RolePermission GetById(int rolePermissionId)
        {
            return rolePermissionTable.Single(rp => rp.permissionID == rolePermissionId);
        }

        public void DeleteRolePermission(int rolePermissionId)
        {
            rolePermissionTable.DeleteOnSubmit(GetById(rolePermissionId));
        }

        public void UpdateRolePermission(RolePermission newRolePermission)
        {
            RolePermission originalRolePermission = rolePermissionTable.Single(rp => rp.permissionID == newRolePermission.permissionID);
            rolePermissionTable.Attach(newRolePermission, originalRolePermission);
        }

        public void SubmitChanges()
        {
            rolePermissionTable.Context.SubmitChanges();
        }

        public IQueryable<RolePermission> RolePermissions
        {
            get { return rolePermissionTable; }
        }
    }
}
