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
        public long? CustomerPhone { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerCity { get; set; }
        public int AmountOfOrders { get; set; }
        public virtual ICollection<Order> CustomersOrders { get; set; }
    }
}