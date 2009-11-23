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
        System.Collections.Generic.List<Order> GetByPrintRun(int printRunId);
        void UpdateOrderInfo(Order newOrder);
        void SubmitChanges();
    }
}
