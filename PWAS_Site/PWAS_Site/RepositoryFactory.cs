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
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using PWAS.DataAccess.Interfaces;
using PWAS.DataAccess.SQLRepositories;
using Castle.Windsor.Configuration.Interpreters;
using Castle.Core.Resource;
using System.Web.Configuration;
using System.Collections.Generic;

namespace PWAS_Site
{
    internal class RepositoryFactory
    {
        private static WindsorContainer container;
        private static Dictionary<string, string> arguments;

        static RepositoryFactory()
        {
            container = new WindsorContainer(new XmlInterpreter(new ConfigResource("castle")));

            Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/PWAS_Site");
            string connString = rootWebConfig.ConnectionStrings.ConnectionStrings["PwasConnectionString"].ConnectionString;

            arguments = new Dictionary<string, string>();
            arguments.Add("connectionString", connString);
        }

        internal static IRolePermissionRepository GetRolePermissionRepository()
        {
            return (IRolePermissionRepository)container.Resolve(typeof(IRolePermissionRepository), arguments);
        }

        internal static IRoleRepository GetRoleRepository()
        {
            return (IRoleRepository)container.Resolve(typeof(IRoleRepository), arguments);
        }

        internal static IOrderRepository GetOrderRepository()
        {
            return (IOrderRepository)container.Resolve(typeof(IOrderRepository), arguments);
        }

        internal static IUserRepository GetUserRepository()
        {
            return (IUserRepository)container.Resolve(typeof(IUserRepository), arguments);
        }

        internal static IPrintRunRepository GetPrintRunRepository()
        {
            return (IPrintRunRepository)container.Resolve(typeof(IPrintRunRepository), arguments);
        }
    }
}
