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

namespace PWAS_Site
{
    public static class Security
    {
        private static IQueryable<Role> Roles { get; set; }
        private static IQueryable<RolePermission> RolePermissions { get; set; }

        static Security()
        {
            Security.Roles = RepositoryFactory.Get<IRoleRepository>().Roles;
            Security.RolePermissions = RepositoryFactory.Get<IRolePermissionRepository>().RolePermissions;
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
