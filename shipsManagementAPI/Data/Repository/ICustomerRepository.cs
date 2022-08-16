using shipsManagementAPI.API.DTOs;
using shipsManagementAPI.Data.Models;

namespace shipsManagementAPI.Data.Repository
{
    public interface ICustomerRepository : IDisposable
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(int customerId);
        Customer InsertCustomer(CreateCustomerDTO customer);
        void DeleteCustomer(int customerId);
        Customer UpdateCustomer(int customerId, UpdateCustomerDTO customer);
        void Save();
    }
}