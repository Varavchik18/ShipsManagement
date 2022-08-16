using shipsManagementAPI.Data.Models;
using shipsManagementAPI.Data.Models.WellKnownProperty;
using shipsManagementAPI.Data.ProgramDbContext;

namespace shipsManagementAPI.Data.SeedData
{
    public static class SeedOrderStatuses
    {
        public static void InitializeOrderStatuses(AppDbContext context)
        {
            var orderStatuses = new OrderStatus[]
            {
            new OrderStatus{OrderStatusName = WKPStatus.Created},
            new OrderStatus{OrderStatusName = WKPStatus.Approved},
            new OrderStatus{OrderStatusName = WKPStatus.Closed},
            new OrderStatus{OrderStatusName = WKPStatus.Received},
            new OrderStatus{OrderStatusName = WKPStatus.Reviewed},
            new OrderStatus{OrderStatusName = WKPStatus.ReviewedByReceiver},
            new OrderStatus{OrderStatusName = WKPStatus.Sent}
            };
            foreach (OrderStatus o in orderStatuses)
            {
                context.OrderStatuses.Add(o);
            }
            context.SaveChanges();
        }
    }
}