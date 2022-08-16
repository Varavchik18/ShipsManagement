using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shipsManagementAPI.API.DTOs
{
    public class CreateCustomerDTO
    {
        public string CustomerName { get; set; }
        public long? CustomerPhone { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerCity { get; set; }
        public int AmountOfOrders { get; set; }
    }
}