using System;
using PWAS.Model;
using System.Linq;

namespace PWAS.DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void AddOrder(Order order);
        void DeleteOrder(int orderId);
        Order GetById(int orderId);
        void UpdateOrderStatus(int orderId, int statusId);
        void UpdateOrderRunId(int orderId, int runId);
        void SubmitChanges();
    }
}
