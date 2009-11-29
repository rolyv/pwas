using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWAS.DataAccess.Interfaces;
using PWAS.Model;
using System.Data.Linq;

namespace PWAS.DataAccess.SQLRepositories
{
    public class OrderHistoryRepository : IOrderHistoryRepository
    {
        private Table<OrderHistory> orderHistoryTable;

        public OrderHistoryRepository(string connectionString)
        {
            orderHistoryTable = new PWASDataContext(connectionString).OrderHistories;
        }

        #region IOrderHistoryRepository Members

        public IQueryable<PWAS.Model.OrderHistory> OrderHistories
        {
            get { return orderHistoryTable; }
        }

        #endregion
    }
}
