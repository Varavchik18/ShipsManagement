using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shipsManagementAPI.Data.Models;
using shipsManagementAPI.Data.ProgramDbContext;

namespace shipsManagementAPI.Data.Repository
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public void DeleteCustomer(int customerId)
        {
            Customer customer = _context.Customers.Find(customerId);
            _context.Customers.Remove(customer);
        }


        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.Find(customerId);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public void InsertCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}