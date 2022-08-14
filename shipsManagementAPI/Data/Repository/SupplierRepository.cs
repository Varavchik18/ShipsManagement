using Microsoft.EntityFrameworkCore;
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

        public void InsertSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            _context.Entry(supplier).State = EntityState.Modified;
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