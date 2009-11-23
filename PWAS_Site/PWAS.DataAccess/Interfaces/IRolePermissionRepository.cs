using System;
using PWAS.Model;
using System.Linq;

namespace PWAS.DataAccess.Interfaces
{
    public interface IRolePermissionRepository
    {
        IQueryable<RolePermission> RolePermissions { get; }
        void AddRolePermission(PWAS.Model.RolePermission rolePermission);
        void DeleteRolePermission(int rolePermissionId);
        RolePermission GetById(int rolePermissionId);
        void UpdateRolePermission(RolePermission newRolePermission);
        void SubmitChanges();
    }
}
