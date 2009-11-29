using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using PWAS.Model;

namespace PWAS.DataAccess.SQLRepositories
{
    public class OrderRepository : PWAS.DataAccess.Interfaces.IOrderRepository
    {
        private Table<Order> orderTable;

        public OrderRepository(string connectionString)
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
