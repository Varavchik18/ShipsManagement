using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shipsManagementAPI.Data.Models
{
    public class EmployeeGender
    {
        public int Id { get; set; }
        public string Sex { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}