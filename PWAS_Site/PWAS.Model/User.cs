using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWAS.Model
{
    /// <summary>
    /// Partial class that implements partial method OnCreated()
    /// to take care of fields that have default values in the 
    /// database schema. Linq-to-SQL does not properly take 
    /// care of default values, so these have to be set explicitly
    /// if someone creates a User without assigning a value to 
    /// these fields.
    /// </summary>
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
                this.active = true;
            }
        }
    }

    /// <summary>
    /// Partial class that implements partial method OnCreated()
    /// to take care of fields that have default values in the 
    /// database schema. Linq-to-SQL does not properly take 
    /// care of default values, so these have to be set explicitly
    /// if someone creates an Order without assigning a value to 
    /// these fields.
    /// </summary>
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

    /// <summary>
    /// Partial class that implements partial method OnCreated()
    /// to take care of fields that have default values in the 
    /// database schema. Linq-to-SQL does not properly take 
    /// care of default values, so these have to be set explicitly
    /// if someone creates a PrintRun without assigning a value to 
    /// these fields.
    /// </summary>
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
