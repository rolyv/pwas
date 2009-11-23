using System;
namespace PWAS.DataAccess.Interfaces
{
    public interface IRolePermissionRepository
    {
        void AddRolePermission(PWAS.Model.RolePermission rolePermission);
        void DeleteRolePermission(int rolePermissionId);
        PWAS.Model.RolePermission GetById(int rolePermissionId);
        void UpdateRolePermission(PWAS.Model.RolePermission newRolePermission);
        void SubmitChanges();
    }
}
