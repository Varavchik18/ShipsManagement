using MediatR;
using Microsoft.AspNetCore.Mvc;
using shipsManagementAPI.API;
using shipsManagementAPI.API.Queries;
using shipsManagementAPI.Data.ProgramDbContext;
using shipsManagementAPI.Data.Models;
using shipsManagementAPI.Data.Repository;

namespace shipsManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private AppDbContext _context;
    private ICustomerRepository _customerRepo;
    private ISupplierRepository _supplierRepo;

    public WeatherForecastController(AppDbContext context, ICustomerRepository customerRepo, ISupplierRepository supplierRepo)
    {
        _context = context;
        _customerRepo = customerRepo;
        _supplierRepo = supplierRepo;
    }

    #region  SupplierQueries
    [HttpPost("CreateSupplier")]
    public async Task<ActionResult> CreateSuplier([FromBody] Supplier supplier)
    {
        try
        {
            _supplierRepo.InsertSupplier(supplier);
            _supplierRepo.Save();
            return Ok(supplier);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost("UpdateSupplier/{id}")]
    public async Task<ActionResult> UpdateSupplier([FromRoute] int idSupplier, [FromBody] Supplier supplier)
    {
        var targetSupplier = _supplierRepo.GetSupplierById(idSupplier);

        try
        {
            _supplierRepo.UpdateSupplier(supplier);
            _supplierRepo.Save();
            return Ok(supplier);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("DeleteSupplier/{id}")]
    public async Task<ActionResult> DeleteSupplier([FromRoute] int idSupplier)
    {
        try
        {
            _supplierRepo.DeleteSupplier(idSupplier);
            _supplierRepo.Save();
            return Ok(idSupplier);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    #endregion

    #region SupplierQuery

    [HttpGet("Supplier/{id}")]
    public async Task<Supplier> GetSupplier([FromRoute] int idSupplier)
    {
        return _supplierRepo.GetSupplierById(idSupplier);
    }

    [HttpGet("Suppliers")]
    public List<Supplier> GetSuppliersList()
    {
        return _supplierRepo.GetSuppliers();
    }
    #endregion
}
