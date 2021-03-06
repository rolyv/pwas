﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using PWAS.Model;
using PWAS.DataAccess.Interfaces;
using System.Web.SessionState;

namespace PWAS_Site
{
    public static class OrderUtilities
    {
        public static IQueryable<Order> getOrdersByUser(int userID, HttpResponse r)
        {
            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();

            IQueryable<Order> orders_User = null;

            if (Security.IsAuthorized(userID, PwasObject.Order, PwasAction.View, PwasScope.All))
            {
                orders_User = from p
                              in orderRepository.Orders
                              select p;
            }
            else if (Security.IsAuthorized(userID, PwasObject.Order, PwasAction.View, PwasScope.Self))
            {
                orders_User = from p
                              in orderRepository.Orders
                              where p.userID == userID
                              select p;
            }
            else
            {
                r.Redirect("index.aspx");
            }
            return orders_User;
        }

        public static Status getCurrentOrderStatus(int orderID)
        {
            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();
            IStatusRepository statusReposiory = RepositoryFactory.Get<IStatusRepository>();

            Order currentOrder = orderRepository.GetById(orderID);

            int tempStatus = (int)currentOrder.currentStatus;

            Status currentStatus = statusReposiory.GetById(tempStatus);

            return currentStatus;
        }

        public static string getCurrentOrderStatusDate(int orderID)
        {
            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();
            IOrderHistoryRepository historyRepository = RepositoryFactory.Get<IOrderHistoryRepository>();

            Order currentOrder = orderRepository.GetById(orderID);
            //OrderHistory currentHistory = historyRepository.OrderHistories.Single(x => x.orderId == orderID 
             //                                                    && x.statusId == currentOrder.Status.statusId);
            OrderHistory currentHistory = (from history in historyRepository.OrderHistories
                                           where history.orderId == orderID && history.statusId == currentOrder.currentStatus
                                           orderby history.modifiedDate descending
                                           select history).First();

            return currentHistory.modifiedDate.ToString();
        }

        public static string getOrderPrice(int orderID)
        {
            return "100 $us";
        }


        internal static bool isMyOrder(int orderID, int userID)
        {            
            IOrderRepository orderRepository = RepositoryFactory.Get<IOrderRepository>();
            Order currentOrder = orderRepository.GetById(orderID);

            if (currentOrder.userID == userID)
                return true;
            else
                return false;           
        }
    }

    public static class OrderConstants
    {
        internal const int ORDER_STATUS_CREATED = 1;
        internal const int ORDER_STATUS_PAID = 2;
        internal const int ORDER_STATUS_PRINTING = 3;
        internal const int ORDER_STATUS_FINISHING = 4;
        internal const int ORDER_STATUS_SHIPPING = 5;
        internal const int ORDER_STATUS_CLOSED = 6;
        internal const int ORDER_STATUS_PREPRINTING = 7;
        internal const int ORDER_STATUS_PROCESSING = 8;
        internal const int ORDER_STATUS_SHIPPED = 9;      
    }
}
