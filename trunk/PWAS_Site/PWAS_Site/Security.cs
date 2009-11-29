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
    public static class Security
    {
        private static IQueryable<Role> Roles { get; set; }
        private static IQueryable<RolePermission> RolePermissions { get; set; }
        private static IQueryable<User> Users { get; set; }

        internal const string PWAS_SESSION_ID = "PWAS_ID";
        internal const string PWAS_SESSION_NAME = "PWAS_NAME";


        static Security()
        {
            Security.Roles = RepositoryFactory.Get<IRoleRepository>().Roles;
            Security.RolePermissions = RepositoryFactory.Get<IRolePermissionRepository>().RolePermissions;
            Security.Users = RepositoryFactory.Get<IUserRepository>().Users;
        }

        public static int Authenticate(string email, string password)
        {
            if (Security.Users.Any(u => u.email.Equals(email)))
            {
                User user = Security.Users.Single(u => u.email.Equals(email));

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

        public static bool IsAuthorized(int roleId, PwasObject obj, PwasAction action, PwasScope scope)
        {
            PwasScope permissionScope = IsAuthorized(roleId, obj, action);

            return permissionScope >= scope;
        }

        public static PwasScope IsAuthorized(int roleId, PwasObject obj, PwasAction action)
        {
            RolePermission permission = Security.RolePermissions.Single(rp => rp.roleID == roleId && rp.@object == obj.StringValue());

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

    public enum PwasObject
    {
        User,
        Order,
        PrintRun,
        Role,
        RolePermission
    }

    public enum PwasAction
    {
        View,
        Create,
        Update,
        Delete
    }

    public enum PwasScope
    {
        None,
        Self,
        All
    }

    public enum AuthenticationResult
    {
        InvalidPassword = -1,
        UserDoesNotExist = -2
    }

    public static class PwasEnumUtilities
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
