﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace PWAS_Site
{
    public partial class customerView_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            welcomeName.Text = (string)Session[Constants.PWAS_SESSION_NAME];
        }
    }
}