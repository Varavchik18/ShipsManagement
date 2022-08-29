using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shipsManagementAPI.API.DTOs;
using shipsManagementAPI.Data.Models;
using shipsManagementAPI.Data.Models.WellKnownProperty;
using shipsManagementAPI.Data.ProgramDbContext;

namespace shipsManagementAPI.Data.Repository
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        private AppDbContext _context;


        public void Save()
        {
            _context.SaveChanges();
        }


        private bool disposed = false;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region Order 

        public List<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public Order GetOrderBySupplierId(int orderSupplierId)
        {
            return _context.Orders.Find(orderSupplierId);
        }

        public Order GetOrderByCustomerId(int orderCustomerId)
        {
            return _context.Orders.Find(orderCustomerId);
        }

        public Order InsertOrder(CreateOrderDTO order)
        {
            var orderStatusCreated = _context.OrderStatuses.ToList().Where(c => c.OrderStatusName == WKPStatus.Created).FirstOrDefault();
            var result = _context.Orders.Add(new Order
            {
                CustomerId = order.customerId,
                SupplierId = order.supplierId,
                OrderTitle = order.OrderTitle,
                Destination = order.Destination,
                OfferValueAmount = order.OfferValueAmount,
                OrderStatusId = orderStatusCreated.Id,
                Notes = order.Notes ?? null,
            }).Entity;

            return result;
        }

        public void DeleteOrder(int orderId)
        {
            var order = GetOrderBySupplierId(orderId);
            _context.Orders.Remove(order);
        }

        public Order UpdateOrder(int orderSupplierId, UpdateOrderDTO order)
        {
            var orderToUpdate = GetOrderBySupplierId(orderSupplierId);
            var orderStatusToSet = _context.OrderStatuses.ToList().Where(c => c.OrderStatusName == order.OrderStatus).FirstOrDefault();

            orderToUpdate.OrderTitle = order.OrderTitle;
            orderToUpdate.Destination = order.Destination;
            orderToUpdate.OfferValueAmount = order.OfferValueAmount;
            if (orderStatusToSet != null)
                orderToUpdate.OrderStatusId = orderStatusToSet.Id;
            orderToUpdate.Notes = order.Notes ?? null;

            return orderToUpdate;
        }

        public int SetOrderStatus(string orderStatus, int orderId)
        {
            var orderToUpdate = GetOrderBySupplierId(orderId);
            var orderStatusToSet = _context.OrderStatuses.ToList().Where(c => c.OrderStatusName == orderStatus).FirstOrDefault();

            if (orderStatusToSet is null || orderStatusToSet == default)
                return 0;
            else
            {
                orderToUpdate.OrderStatusId = orderStatusToSet.Id;
                return orderStatusToSet.Id;
            }
        }

        #endregion
    }
}