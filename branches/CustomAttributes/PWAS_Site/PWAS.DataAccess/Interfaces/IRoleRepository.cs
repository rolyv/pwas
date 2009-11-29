using System;
using PWAS.Model;
using System.Linq;

namespace PWAS.DataAccess.Interfaces
{
    public interface IRoleRepository
    {
        IQueryable<Role> Roles { get; }
        void AddRole(PWAS.Model.Role role);
        Role GetById(int roleId);
        void DeleteRole(int roleId);
        void UpdateRole(Role newRole);
        void SubmitChanges();
    }
}
