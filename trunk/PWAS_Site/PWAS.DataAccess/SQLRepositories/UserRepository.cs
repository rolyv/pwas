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
            return userTable.FirstOrDefault(u => u.userID == userId);
        }

        public void DeleteUser(int userId)
        {
            userTable.DeleteOnSubmit(GetById(userId));
        }

        public void UpdateUserInfo(User newUser)
        {
            User userOriginal = userTable.Single(u => u.userID == newUser.userID);
            userTable.Attach(newUser, userOriginal);
        }

        public IQueryable<User> Users
        {
            get { return userTable; }
        }
    }
}
