using Microsoft.EntityFrameworkCore;
using shipsManagementAPI.API;
using shipsManagementAPI.API.DTOs;
using shipsManagementAPI.Data.Models;
using shipsManagementAPI.Data.ProgramDbContext;

namespace shipsManagementAPI.Data.Repository
{
    public class SupplierRepository : ISupplierRepository, IDisposable
    {
        private AppDbContext _context;

        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }

        #region  SupplierFunctions
        public void DeleteSupplier(int supplierId)
        {
            Supplier supplier = _context.Suppliers.Find(supplierId);
            _context.Suppliers.Remove(supplier);
        }


        public Supplier GetSupplierById(int supplierId)
        {
            return _context.Suppliers.Find(supplierId);
        }

        public List<Supplier> GetSuppliers()
        {
            return _context.Suppliers.ToList();
        }

        public Supplier InsertSupplier(CreateSupplierDTO supplier)
        {
            var supplierCreated = new Supplier
            {
                SupplierName = supplier.SupplierName,
                SupplierAddress = supplier.SupplierAddress ?? null,
                SupplierCity = supplier.SupplierCity ?? null,
                SupplierPhone = supplier.SupplierPhone ?? null,
                AmountOfShips = supplier.AmountOfShips,
                CountryId = supplier.CountryId
            };
            return _context.Suppliers.Add(supplierCreated).Entity;
        }

        public Supplier UpdateSupplier(int supplierId, UpdateSupplierDTO supplier)
        {
            var supplierToUpdate = this.GetSupplierById(supplierId);

            supplierToUpdate.SupplierName = supplier.SupplierName;
            supplierToUpdate.SupplierPhone = supplier.SupplierPhone ?? null;
            supplierToUpdate.SupplierCity = supplier.SupplierCity ?? null;
            supplierToUpdate.SupplierAddress = supplier.SupplierAddress ?? null;
            supplierToUpdate.AmountOfShips = supplier.AmountOfShips;
            supplierToUpdate.CountryId = supplier.CountryId;

            return supplierToUpdate;

        }
        public void Save()
        {
            _context.SaveChanges();
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
        #endregion

        #region CountryFunctions

        public List<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountryById(int countryId)
        {
            return _context.Countries.Find(countryId);
        }

        // public Country GetCountryByIdSupplier(int supplierId)
        // {
        //     var countries =  _context.Countries.ToList();
        //     var result = countries.Where
        // }

        public void DeleteCountry(int countryId)
        {
            Country country = _context.Countries.Find(countryId);
            _context.Countries.Remove(country);
        }

        public Country InsertCountry(string countryName)
        {
            var result = _context.Countries.Add(new Country { CountryName = countryName });
            return result.Entity;
        }

        public Country UpdateCountry(int countryId, string countryName)
        {
            var country = GetCountryById(countryId);
            country.CountryName = countryName;

            return country;
        }

        #endregion


        #region Employee func 

        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _context.Employees.Find(employeeId);
        }

        public void DeleteEmployee(int employeeId)
        {
            Employee employee = this.GetEmployeeById(employeeId);
            _context.Employees.Remove(employee);
        }

        public Employee InsertEmployee(CreateEmployeeDTO employee)
        {
            var result = _context.Employees.Add(new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                Age = employee.Age ?? 0,
                Salary = employee.Salary ?? 0,
                idEmployeeGender = employee.idEmployeeGender,
                idSupplier = employee.idSupplierCompany,
            }).Entity;

            return result;
        }

        public Employee UpdateEmployee(int idEmployee, UpdateEmployeeDTO employee)
        {
            var employeeToUpdate = this.GetEmployeeById(idEmployee);

            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.PhoneNumber = employee.PhoneNumber;
            employeeToUpdate.Age = employee.Age ?? 0;
            employeeToUpdate.Salary = employee.Salary ?? 0;
            employeeToUpdate.idEmployeeGender = employee.idEmployeeGender;
            employeeToUpdate.idSupplier = employee.idSupplierCompany;

            return employeeToUpdate;
        }

        public void PopulateEmployee(int supplierId, Employee employee)
        {
            var supplier = this.GetSupplierById(supplierId);
            supplier.Employees.Add(employee);

            _context.Entry(supplier).State = EntityState.Modified;
        }

        public void UnPopulateEmployee(int supplierId, int employeeId)
        {
            var supplier = this.GetSupplierById(supplierId);
            var employee = supplier.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

            if (employee != null)
                supplier.Employees.Remove(employee);
        }

        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}