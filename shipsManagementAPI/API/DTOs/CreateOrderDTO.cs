using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shipsManagementAPI.API.DTOs
{
    public class CreateOrderDTO
    {
        public int customerId { get; set; }
        public int supplierId { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderTitle { get; set; }
        public string Destination { get; set; }
        public int OfferValueAmount { get; set; }
        public string? Notes { get; set; }
    }
}