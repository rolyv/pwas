using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using PWAS.DataAccess.Interfaces;
using PWAS.Model;
using System.Security.Cryptography;
using System.Text;

namespace PWAS_Site
{
    internal static class Security
    {
        private static IRoleRepository RolesRepo { get; set; }
        private static IRolePermissionRepository RolePermissionsRepo { get; set; }
        private static IUserRepository UsersRepo { get; set; }

        static Security()
        {
            Security.RolesRepo = RepositoryFactory.Get<IRoleRepository>();
            Security.RolePermissionsRepo = RepositoryFactory.Get<IRolePermissionRepository>();
            Security.UsersRepo = RepositoryFactory.Get<IUserRepository>();
        }

        internal static int Authenticate(string email, string password)
        {
            if (Security.UsersRepo.Users.Any(u => u.email.Equals(email)))
            {
                User user = Security.UsersRepo.Users.Single(u => u.email.Equals(email));

                if (MD5Encode(password).Equals(user.password.Trim()))
                {
                    return user.userID;
                }
                else
                {
                    return (int)AuthenticationResult.InvalidPassword;
                }
            }
            else
            {
                return (int)AuthenticationResult.UserDoesNotExist;
            }
        }

        internal static bool IsAuthorized(int userId, PwasObject obj, PwasAction action, PwasScope scope)
        {
            PwasScope permissionScope = IsAuthorized(userId, obj, action);

            return permissionScope >= scope;
        }

        internal static PwasScope IsAuthorized(int userId, PwasObject obj, PwasAction action)
        {
            RolePermission permission = Security.RolePermissionsRepo.RolePermissions.Single(rp => rp.roleID == Security.UsersRepo.GetById(userId).roleID && rp.@object == obj.StringValue());

            switch (action)
            {
                case PwasAction.View:
                    return (PwasScope)permission.obj_view;
                case PwasAction.Create:
                    return (PwasScope)permission.obj_create;
                case PwasAction.Update:
                    return (PwasScope)permission.obj_update;
                case PwasAction.Delete:
                    return (PwasScope)permission.obj_delete;
                default:
                    return PwasScope.None;
            }
        }

        internal static string MD5Encode(string input)
        {
            //Declarations
            byte[] originalBytes;
            byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(input);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }
    }

    internal enum PwasObject
    {
        User,
        Order,
        PrintRun,
        Role,
        RolePermission
    }

    internal enum PwasAction
    {
        View,
        Create,
        Update,
        Delete
    }

    internal enum PwasScope
    {
        None,
        Self,
        All
    }

    internal enum AuthenticationResult
    {
        InvalidPassword = -1,
        UserDoesNotExist = -2
    }

    internal static class PwasEnumUtilities
    {
         internal static string StringValue(this PwasObject obj)
         {
             switch (obj)
             {
                 case PwasObject.Order:
                     return "order";
                 case PwasObject.PrintRun:
                     return "run";
                 case PwasObject.Role:
                     return "role";
                 case PwasObject.RolePermission:
                     return "permission";
                 case PwasObject.User:
                     return "user";
                 default:
                     return null;
             }
         }
    }
}
