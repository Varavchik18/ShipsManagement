using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shipsManagementAPI.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public int? CustomerPhone { get; set; }
        public string? CustomerAddress { get; set; }
        public string? City { get; set; }
        public int AmountOfOrders { get; set; }
        public virtual ICollection<Order> SupplierCustomers { get; set; }
    }
}