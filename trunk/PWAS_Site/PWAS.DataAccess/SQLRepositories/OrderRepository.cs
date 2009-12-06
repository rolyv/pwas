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

        public void UpdateOrderStatus(int orderId, int statusId)
        {
            Order o = GetById(orderId);
            Status newStatus = orderTable.Context.GetTable<Status>().Single(s => s.statusId == statusId);
            o.Status = newStatus;
            orderTable.Context.SubmitChanges();
        }

        public IQueryable<Order> Orders
        {
            get { return orderTable; }
        }
    }
}
