using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shipsManagementAPI.API.DTOs
{
    public class CreateEmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public int? Age { get; set; }
        public int? Salary { get; set; }
        public int idEmployeeGender { get; set; }
        public int idSupplierCompany { get; set; }
    }
}