using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using PWAS.Model;

namespace PWAS.DataAccess.SQLRepositories
{
    public class UserRepository : PWAS.DataAccess.Interfaces.IUserRepository
    {
        private Table<User> userTable;

        public UserRepository(string connectionString)
        {
            userTable = new PWASDataContext(connectionString).Users;
        }
        
        public void AddUser(User user)
        {
            userTable.InsertOnSubmit(user);
        }

        public void SubmitChanges()
        {
            userTable.Context.SubmitChanges();
        }

        public User GetById(int userId)
        {
            if (userTable.Any(u => u.userID == userId))
                return userTable.FirstOrDefault(u => u.userID == userId);
            return null;
        }

        public void ActivateUser(int userId)
        {
            User user = GetById(userId);
            user.active = true;

            SubmitChanges();
        }

        public void DeactivateUser(int userId)
        {
            User user = GetById(userId);
            user.active = false;

            SubmitChanges();
        }
        
        public void DeleteUser(int userId)
        {
            userTable.DeleteOnSubmit(GetById(userId));
        }

        public void UpdateUserRole(int userId, int newRoleId)
        {
            User user = GetById(userId);
            user.Role = userTable.Context.GetTable<Role>().Single(r => r.roleID == newRoleId);

            userTable.Context.SubmitChanges();
            userTable.Context.Refresh(RefreshMode.OverwriteCurrentValues, user);
        }

        public IQueryable<User> Users
        {
            get { return userTable; }
        }
    }
}
