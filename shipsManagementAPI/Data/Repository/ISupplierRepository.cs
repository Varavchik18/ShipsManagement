using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shipsManagementAPI.API;
using shipsManagementAPI.API.DTOs;
using shipsManagementAPI.Data.Models;

namespace shipsManagementAPI.Data.Repository
{
    public interface ISupplierRepository : IDisposable
    {
        #region  Supplier functions
        List<Supplier> GetSuppliers();
        Supplier GetSupplierById(int supplierId);
        Supplier InsertSupplier(CreateSupplierDTO supplier);
        Supplier UpdateSupplier(int supplierId, UpdateSupplierDTO supplier);
        void DeleteSupplier(int supplierID);

        #endregion

        #region Country functions

        List<Country> GetCountries();
        Country GetCountryById(int countryId);
        Country InsertCountry(string countryName);
        void DeleteCountry(int countryId);
        Country UpdateCountry(int countryId, string countryName);
        #endregion

        #region Employee functions
        List<Employee> GetEmployees();
        Employee GetEmployeeById(int employeeId);
        Employee InsertEmployee(CreateEmployeeDTO employee);
        void DeleteEmployee(int employeeId);
        Employee UpdateEmployee(int employeeId, UpdateEmployeeDTO employee);

        void PopulateEmployee(int supplierId, Employee employee);

        #endregion
        void Save();
    }
}