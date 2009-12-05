using System;
using PWAS.Model;
using System.Linq;

namespace PWAS.DataAccess.Interfaces
{
    /// <summary>
    /// IUserRepository defines the interface for an abstract
    /// UserRepository. It defines methods for basic CRUD operations
    /// as well as for retrieving a user record by ID and for 
    /// setting a user's active flag to false. 
    /// </summary>
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void AddUser(User user);
        void DeleteUser(int userId);
        void ActivateUser(int userId);
        void DeactivateUser(int userId);
        User GetById(int userId);
        void UpdateUserInfo(User newUser);
        void SubmitChanges();
    }
}
