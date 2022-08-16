using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shipsManagementAPI.Data.Models;
using shipsManagementAPI.Data.ProgramDbContext;

namespace shipsManagementAPI.Data.SeedData
{
    public class SeedCustomers
    {
        public static void InitializeCustomers(AppDbContext context)
        {
            var customers = new Customer[]
            {
                new Customer{ CustomerName = "Artem Chunyak", CustomerAddress = "test address 1", CustomerPhone = 380507826901, CustomerCity="Kyiv", AmountOfOrders=20 },
                new Customer{ CustomerName = "Olha Davydova", CustomerAddress = "lukavytsya 101", CustomerPhone = 380507826902, CustomerCity="Obukhiv", AmountOfOrders=21 },
                new Customer{ CustomerName = "Dima Kripta", CustomerAddress = "Peremohy avenue 12", CustomerPhone = 380507826903, CustomerCity="Kharkiv", AmountOfOrders=22 },
                new Customer{ CustomerName = "Oleksii NeHochuVShkolu", CustomerAddress = "test address 2", CustomerPhone = 380507826904, CustomerCity="Odesa", AmountOfOrders=23 },
                new Customer{ CustomerName = "Oleg Chegevara", CustomerAddress = "test address 3", CustomerPhone = 380507826905, CustomerCity="Toronto", AmountOfOrders=24 },
                new Customer{ CustomerName = "Yosyp Stalin", CustomerAddress = "test address 4", CustomerPhone = 380507826906, CustomerCity="Berlin", AmountOfOrders=25 }
            };

            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }

            context.SaveChanges();
        }
    }
}