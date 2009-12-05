using System;
using PWAS.Model;
using System.Linq;

namespace PWAS.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void AddUser(User user);
        void DeleteUser(int userId);
        void DeactivateUser(int userId);
        User GetById(int userId);
        void UpdateUserInfo(User newUser);
        void SubmitChanges();
    }
}
