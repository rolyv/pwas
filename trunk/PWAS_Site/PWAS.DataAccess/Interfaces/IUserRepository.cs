using System;
using PWAS.Model;

namespace PWAS.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void DeleteUser(int userId);
        User GetById(int userId);
        void UpdateUserInfo(User newUser);
        void SubmitChanges();
    }
}
