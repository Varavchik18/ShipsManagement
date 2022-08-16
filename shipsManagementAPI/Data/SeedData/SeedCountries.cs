using shipsManagementAPI.Data.Models;
using shipsManagementAPI.Data.Models.WellKnownProperty;
using shipsManagementAPI.Data.ProgramDbContext;

namespace shipsManagementAPI.Data.SeedData
{
    public class SeedCountries
    {
        public static void InitializeCountries(AppDbContext context)
        {
            var countries = new Country[]
            {
                new Country{CountryName = WKPCountry.Canada},
                new Country{CountryName = WKPCountry.France},
                new Country{CountryName = WKPCountry.Lebannon},
                new Country{CountryName = WKPCountry.Spain},
                new Country{CountryName = WKPCountry.Turkey},
                new Country{CountryName = WKPCountry.Ukraine},
                new Country{CountryName = WKPCountry.UnitedKingdom},
                new Country{CountryName = WKPCountry.USA},
            };
            foreach (Country c in countries)
            {
                context.Countries.Add(c);
            }

            context.SaveChanges();
        }
    }
}