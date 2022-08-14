using System.ComponentModel.DataAnnotations;

namespace shipsManagementAPI.Data.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SupplierName { get; set; }

        public int? SupplierPhone { get; set; }

        public string SupplierAddress { get; set; }
        public string SupplierCity { get; set; }

        public int? AmountOfCustomers { get; set; }

        [Required]
        public int AmountOfShips { get; set; }

        public Country? Country { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Order> SupplierCustomers { get; set; }

    }
}