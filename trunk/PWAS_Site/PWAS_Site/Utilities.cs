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
using PWAS.Model;
using PWAS.DataAccess.Interfaces;
using System.Web.SessionState;

namespace PWAS_Site
{
    public static class Utilities
    {
        public static bool HasPwasAttributes(this WebControl control)
        {
            if (control.HasAttributes)
            {
                if (!string.IsNullOrEmpty(control.Attributes["pwasObj"]) && !string.IsNullOrEmpty(control.Attributes["pwasAction"]) 
                    && !string.IsNullOrEmpty(control.Attributes["pwasScope"]))
                {
                    return true;
                }
            }

            return false;
        }

        public static void doLogout(HttpSessionState s, HttpResponse r)
        {
            s.Remove(Constants.PWAS_SESSION_ID);
            s.Remove(Constants.PWAS_SESSION_NAME);
            r.Redirect("index.aspx");
        }

    }

    public static class Constants
    {
        internal const string PWAS_SESSION_ID = "PWAS_ID";
        internal const string PWAS_SESSION_NAME = "PWAS_NAME";
    }
}
