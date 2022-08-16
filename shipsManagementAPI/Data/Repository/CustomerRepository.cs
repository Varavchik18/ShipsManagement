using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shipsManagementAPI.API.DTOs;
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
            Customer customer = GetCustomerById(customerId);
            _context.Customers.Remove(customer);
        }


        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.Find(customerId);
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer InsertCustomer(CreateCustomerDTO customer)
        {
            var result = _context.Customers.Add(
                new Customer
                {
                    CustomerName = customer.CustomerName,
                    CustomerPhone = customer.CustomerPhone ?? null,
                    CustomerAddress = customer.CustomerAddress ?? null,
                    CustomerCity = customer.CustomerCity ?? null,
                    AmountOfOrders = customer.AmountOfOrders
                }
            ).Entity;

            return result;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Customer UpdateCustomer(int customerId, UpdateCustomerDTO customer)
        {
            var customerToUpdate = GetCustomerById(customerId);

            customerToUpdate.CustomerName = customer.CustomerName;
            customerToUpdate.CustomerPhone = customer.CustomerPhone;
            customerToUpdate.CustomerAddress = customer.CustomerAddress;
            customerToUpdate.CustomerCity = customer.CustomerCity;
            customerToUpdate.AmountOfOrders = customer.AmountOfOrders;

            return customerToUpdate;
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