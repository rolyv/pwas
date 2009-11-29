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

        static RepositoryFactory()
        {
            container = new WindsorContainer(new XmlInterpreter(new ConfigResource("castle")));
        }

        internal static T Get<T>()
        {
            return container.Resolve<T>();
        }
    }
}
