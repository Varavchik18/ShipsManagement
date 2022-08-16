using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shipsManagementAPI.API.DTOs;
using shipsManagementAPI.Data.Models;
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

        public Order GetOrderById(int orderId)
        {
            return _context.Orders.Find(orderId);
        }

        public Order InsertOrder(CreateOrderDTO order)
        {
            var result = _context.Orders.Add(new Order
            {
                CustomerId = order.customerId,
                SupplierId = order.supplierId,
                OrderTitle = order.OrderTitle,
                Destination = order.Destination,
                OfferValueAmount = order.OfferValueAmount,
                OrderStatusId = order.OrderStatusId,
                Notes = order.Notes ?? null,
            }).Entity;

            return result;
        }

        public void DeleteOrder(int orderId)
        {
            var order = GetOrderById(orderId);
            _context.Orders.Remove(order);
        }

        public Order UpdateOrder(int orderId, UpdateOrderDTO order)
        {
            var orderToUpdate = GetOrderById(orderId);

            orderToUpdate.OrderTitle = order.OrderTitle;
            orderToUpdate.Destination = order.Destination;
            orderToUpdate.OfferValueAmount = order.OfferValueAmount;
            orderToUpdate.OrderStatusId = order.OrderStatusId;
            orderToUpdate.Notes = order.Notes ?? null;

            return orderToUpdate;
        }

        #endregion
    }
}