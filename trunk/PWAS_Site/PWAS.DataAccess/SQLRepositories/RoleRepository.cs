using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWAS.Model;
using System.Data.Linq;

namespace PWAS.DataAccess.SQLRepositories
{
    public class RoleRepository : PWAS.DataAccess.Interfaces.IRoleRepository
    {
        private Table<Role> roleTable;
        public RoleRepository(string connectionString)
        {
            roleTable = new PWASDataContext(connectionString).Roles;
        }

        public void AddRole(Role role)
        {
            roleTable.InsertOnSubmit(role);
        }

        public Role GetById(int roleId)
        {
            return roleTable.Single(r => r.roleID == roleId);
        }

        public void UpdateRole(Role newRole)
        {
            Role originalRole = roleTable.Single(r => r.roleID == newRole.roleID);
            roleTable.Attach(newRole, originalRole);
        }

        public void DeleteRole(int roleId)
        {
            roleTable.DeleteOnSubmit(GetById(roleId));
        }

        public void SubmitChanges()
        {
            roleTable.Context.SubmitChanges();
        }
    }
}
