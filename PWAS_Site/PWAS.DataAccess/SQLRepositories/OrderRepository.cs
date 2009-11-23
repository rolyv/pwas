using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using PWAS.Model;

namespace PWAS.DataAccess.SQLRepositories
{
    public class OrdersRepository : PWAS.DataAccess.Interfaces.IOrderRepository
    {
        private Table<Order> orderTable;

        public OrdersRepository(string connectionString)
        {
            orderTable = new PWASDataContext(connectionString).Orders;
        }

        public void AddOrder(Order order)
        {
            orderTable.InsertOnSubmit(order);
        }

        public void SubmitChanges()
        {
            orderTable.Context.SubmitChanges();
        }

        public Order GetById(int orderId)
        {
            return orderTable.FirstOrDefault(o => o.orderID == orderId);
        }

        public void DeleteOrder(int orderId)
        {
            orderTable.DeleteOnSubmit(GetById(orderId));
        }

        public List<Order> GetByPrintRun(int printRunId)
        {
            return orderTable.Context.GetTable<PrintRun>().FirstOrDefault(p => p.runID == printRunId).Orders.ToList<Order>();
        }

        public List<Order> GetByUser(int userId)
        {
            var orders = (from order in orderTable
                          where order.userID == userId
                          select order).ToList<Order>();

            return orders;
        }

        public void UpdateOrderInfo(Order newOrder)
        {
            Order orderOriginal = orderTable.Single(o => o.orderID == newOrder.orderID);
            orderTable.Attach(newOrder, orderOriginal);
        }

        public IQueryable<Order> Orders
        {
            get { return orderTable; }
        }
    }
}
