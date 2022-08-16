using shipsManagementAPI.Data.ProgramDbContext;

namespace shipsManagementAPI.Data.SeedData
{
    public static class Seed
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any() || context.Suppliers.Any() || context.Customers.Any())
            {
                return;
            }

            SeedGenders.InitializeGenders(context);

            SeedOrderStatuses.InitializeOrderStatuses(context);

            SeedCountries.InitializeCountries(context);

            SeedCustomers.InitializeCustomers(context);

            SeedSuppliers.InitializeSupplier(context);
        }
    }
}