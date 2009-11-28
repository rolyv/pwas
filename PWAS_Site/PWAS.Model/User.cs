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
        }
    }
}
