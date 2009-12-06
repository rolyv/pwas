using System;
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
using System.Collections.Generic;

namespace PWAS_Site.NavMenu
{
    public partial class NavigationControl : System.Web.UI.UserControl
    {
        protected internal List<PWASNavigationNode> nodes;

        protected void Page_Load(object sender, EventArgs e)
        {
            InitNodes();
            if (this.NavTreeView.Nodes.Count == 0)
            {
                foreach (var node in nodes)
                {
                    if (Security.IsAuthorized((int)Session[Constants.PWAS_SESSION_ID], node.PwasObject, node.PwasAction, node.PwasScope))
                    {
                        this.NavTreeView.Nodes.Add(node);
                    }
                }
            }
        }

        protected internal void InitNodes()
        {
            nodes = new List<PWASNavigationNode>();
            nodes.AddRange(new PWASNavigationNode[] {
                new PWASNavigationNode(){ PwasObject = PwasObject.User, PwasAction = PwasAction.View, 
                                            PwasScope = PwasScope.All, Text = "Manage Users", NavigateUrl = "~/adminView_ManageAccounts.aspx" },
                new PWASNavigationNode(){ PwasObject = PwasObject.Order, PwasAction = PwasAction.Create,
                                            PwasScope = PwasScope.Self, Text = "New Order", NavigateUrl = "~/customer_create_order.aspx" },
                new PWASNavigationNode(){ PwasObject = PwasObject.Order, PwasAction = PwasAction.View,
                                            PwasScope = PwasScope.Self, Text = "Manage Orders", NavigateUrl = "~/customer_view_order.aspx" },
                new PWASNavigationNode(){ PwasObject = PwasObject.PrintRun, PwasAction = PwasAction.Create,
                                            PwasScope = PwasScope.Self, Text = "New Print Run", NavigateUrl = "~/workerView_CreatePrintRun.aspx" },
                new PWASNavigationNode(){ PwasObject = PwasObject.PrintRun, PwasAction = PwasAction.View,
                                            PwasScope = PwasScope.Self, Text = "Manage PrintRuns", NavigateUrl = "~/workerView_AddToPrintRun.aspx" },
                new PWASNavigationNode(){ PwasObject = PwasObject.Role, PwasAction = PwasAction.View,
                                            PwasScope = PwasScope.All, Text = "Manage Security Roles", NavigateUrl = "~/manageSecurityURL.aspx" } }
                );
        }

        internal protected class PWASNavigationNode : System.Web.UI.WebControls.TreeNode
        {
            internal PwasObject PwasObject { get; set; }
            internal PwasAction PwasAction { get; set; }
            internal PwasScope PwasScope { get; set; }

            internal PWASNavigationNode()
                : base()
            { }

            internal PWASNavigationNode(PwasObject obj, PwasAction action, PwasScope scope)
                : base()
            {
                this.PwasObject = obj;
                this.PwasAction = action;
                this.PwasScope = scope;
            }
        }
    }
}