using shipsManagementAPI.Data.Models;
using shipsManagementAPI.Data.ProgramDbContext;
using shipsManagementAPI.Data.Repository;

namespace shipsManagementAPI.Data.SeedData
{
    public static class SeedSuppliers
    {
        public static void InitializeSupplier(AppDbContext context)
        {
            // ISupplierRepository _supplierRepo = new SupplierRepository(context);
            // Random _rand = new Random();

            // List<Country> countriesList = new List<Country>();
            // for (int i = 0; i <= 8; i++)
            //     countriesList.Add(_supplierRepo.GetCountryById(_rand.Next(8)));

            // var suppliers = new Supplier[]
            //     {
            //     new Supplier{ SupplierName = "Supplier 1", SupplierPhone = 12552111, SupplierAddress = "Address 1",  Country = countriesList[0]},
            //     new Supplier{ SupplierName = "Supplier 2", SupplierPhone = 12552112, SupplierAddress = "Address 2",  Country = countriesList[1]},
            //     new Supplier{ SupplierName = "Supplier 3", SupplierPhone = 12552113, SupplierAddress = "Address 3",  Country = countriesList[2]},
            //     new Supplier{ SupplierName = "Supplier 4", SupplierPhone = 12552114, SupplierAddress = "Address 4",  Country = countriesList[3]},
            //     new Supplier{ SupplierName = "Supplier 5", SupplierPhone = 12552115, SupplierAddress = "Address 5",  Country = countriesList[4]},
            //     new Supplier{ SupplierName = "Supplier 6", SupplierPhone = 12552116, SupplierAddress = "Address 6",  Country = countriesList[5]},
            //     };

            // foreach (Supplier s in suppliers)
            // {
            //     context.Suppliers.Add(s);
            // }

            // context.SaveChanges();
        }
    }
}