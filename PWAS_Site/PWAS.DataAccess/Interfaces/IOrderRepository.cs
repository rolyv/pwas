using System;
using PWAS.Model;

namespace PWAS.DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        void DeleteOrder(int orderId);
        Order GetById(int orderId);
        System.Collections.Generic.List<Order> GetByPrintRun(int printRunId);
        void UpdateOrderInfo(Order newOrder);
        void SubmitChanges();
    }
}
