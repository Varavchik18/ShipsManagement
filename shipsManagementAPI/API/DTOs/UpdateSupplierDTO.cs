using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shipsManagementAPI.API.DTOs
{
    public class UpdateSupplierDTO
    {
        public string SupplierName { get; set; }
        public int? SupplierPhone { get; set; }
        public string? SupplierAddress { get; set; }
        public string? SupplierCity { get; set; }
        public int? AmountOfCustomers { get; set; }
        public int AmountOfShips { get; set; }
        public int CountryId { get; set; }
    }
}