using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWAS.Model;

namespace PWAS.DataAccess.Interfaces
{
    /// <summary>
    /// Interface for Order History repository. 
    /// Order histories are not inserted or deleted by users,
    /// they are created externally, this interface only
    /// specifies a property with a getter to be able to 
    /// view the order histories.
    /// </summary>
    public interface IOrderHistoryRepository
    {
        IQueryable<OrderHistory> OrderHistories { get; }
    }
}
