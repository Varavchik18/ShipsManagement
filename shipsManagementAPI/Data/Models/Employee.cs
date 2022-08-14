using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shipsManagementAPI.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public int? Age { get; set; }
        public int? Salary { get; set; }

        [Required]
        public EmployeeGender Gender { get; set; }

        [Required]
        public Supplier SupplierCompany { get; set; }
    }
}