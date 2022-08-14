using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shipsManagementAPI.Data.Models
{
    public class Order
    {
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        //* Properties :

        public string OrderTitle { get; set; }
        public string Destination { get; set; }
        public int OfferValueAmount { get; set; }
        public string Notes { get; set; }

    }
}