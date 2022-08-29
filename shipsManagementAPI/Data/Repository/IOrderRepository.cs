using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shipsManagementAPI.API.DTOs;
using shipsManagementAPI.Data.Models;

namespace shipsManagementAPI.Data.Repository
{
    public interface IOrderRepository : IDisposable
    {
        List<Order> GetOrders();
        Order GetOrderBySupplierId(int orderId);
        Order GetOrderByCustomerId(int orderCustomerId);
        Order InsertOrder(CreateOrderDTO order);
        void DeleteOrder(int orderId);
        Order UpdateOrder(int orderId, UpdateOrderDTO order);
        int SetOrderStatus(string orderStatus, int orderId);
        void Save();
    }
}