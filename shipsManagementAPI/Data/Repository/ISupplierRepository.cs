using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shipsManagementAPI.Data.Models;

namespace shipsManagementAPI.Data.Repository
{
    public interface ISupplierRepository : IDisposable
    {
        List<Supplier> GetSuppliers();
        Supplier GetSupplierById(int supplierId);
        void InsertSupplier(Supplier supplier);
        void DeleteSupplier(int supplierID);
        void UpdateSupplier(Supplier supplier);
        void Save();
    }
}