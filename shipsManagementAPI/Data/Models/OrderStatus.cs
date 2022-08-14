using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shipsManagementAPI.Data.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string OrderStatusName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}