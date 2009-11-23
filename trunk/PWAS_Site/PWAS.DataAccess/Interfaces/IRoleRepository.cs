using System;
namespace PWAS.DataAccess.Interfaces
{
    public interface IRoleRepository
    {
        void AddRole(PWAS.Model.Role role);
        PWAS.Model.Role GetById(int roleId);
        void DeleteRole(int roleId);
        void UpdateRole(PWAS.Model.Role newRole);
        void SubmitChanges();
    }
}
