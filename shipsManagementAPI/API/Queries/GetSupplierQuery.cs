using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace shipsManagementAPI.API.Queries
{
    public class GetSupplier
    {
        public class Query
        {
            public int Id { get; set; }
        }

        public class Result
        {
            public int Id { get; set; }
            public string SupplierName { get; set; }
            public int SupplierPhone { get; set; }
            public string SupplierAddress { get; set; }
            public string SupplierCity { get; set; }

            public int AmountOfCustomers { get; set; }
            public int AmountOfShips { get; set; }
        }
    }
}