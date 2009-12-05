using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWAS.Model
{
    public partial class User
    {
        partial void OnCreated()
        {
            if (this.roleID == null)
            {
                this.roleID = 1;
            }
            if (this.active == null)
            {
                this.active = 1;
            }
        }
    }

    public partial class Order
    {
        partial void OnCreated()
        {
            if (this.currentStatus == null)
            {
                this.currentStatus = 1;
            }
        }
    }

    public partial class PrintRun
    {
        partial void OnCreated()
        {
            if (this.run_status == null)
            {
                this.run_status = 1;
            }
        }
    }

    
}
