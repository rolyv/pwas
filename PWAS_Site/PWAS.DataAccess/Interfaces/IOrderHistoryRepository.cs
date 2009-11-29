using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWAS.Model;

namespace PWAS.DataAccess.Interfaces
{
    public interface IOrderHistoryRepository
    {
        IQueryable<OrderHistory> OrderHistories { get; }
    }
}
