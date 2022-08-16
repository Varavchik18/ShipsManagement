using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shipsManagementAPI.Data.Models;
using shipsManagementAPI.Data.Models.WellKnownProperty;
using shipsManagementAPI.Data.ProgramDbContext;

namespace shipsManagementAPI.Data.SeedData
{
    public class SeedGenders
    {
        public static void InitializeGenders(AppDbContext context)
        {
            var genders = new EmployeeGender[]
           {
            new EmployeeGender{Sex=WKPGender.Male},
            new EmployeeGender{Sex=WKPGender.Female},
            new EmployeeGender{Sex=WKPGender.Neutral},
           };

            foreach (EmployeeGender g in genders)
            {
                context.EmployeeGenders.Add(g);
            }
            context.SaveChanges();
        }
    }
}