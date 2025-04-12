using DataLayer;
using DTOs;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class SupplierService
    {
        private SupplierRepository _repo;
        public SupplierService()
        {
            _repo = new SupplierRepository();
        }
        public List<SupplierDTO> GetAllSuppliers()
        {

            return _repo.GetAllSuppliers();
        }
        public bool InsertSupplier(SupplierDTO supplier)
        {
            return _repo.InsertSupplier(supplier);
        }
        public bool UpdateSupplier(SupplierDTO supplier)
        {
            return _repo.UpdateSupplier(supplier);
        }
        public bool DeleteSupplier(int supplierId)
        {
            return _repo.DeleteSupplier(supplierId);
        }
        public List<SupplierDTO> GetSupplierByName(string kw)
        {
            return _repo.SearchSupplierByName(kw);
        }
        public SupplierDTO GetSupplierById(int id)
        {
            return _repo.SearchSupplierByID(id);
        }
        
    }
}
