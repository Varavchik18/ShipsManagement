using MediatR;
using Microsoft.AspNetCore.Mvc;
using shipsManagementAPI.API;
using shipsManagementAPI.API.Queries;
using shipsManagementAPI.Data.AppDbContext;
using shipsManagementAPI.Data.Models;

namespace shipsManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private AppDbContext _context;

    public WeatherForecastController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("CreateSupplier")]
    public async Task<ActionResult> CreateSuplier([FromBody] CreateSupplierDTO supplier)
    {
        var result = _context.AddAsync(new Supplier
        {
            SupplierName = supplier.SupplierName,
            SupplierAddress = supplier.SupplierAddress,
            SupplierCity = supplier.SupplierCity,
            SupplierPhone = supplier.SupplierPhone
        });

        _context.SaveChanges();
        return Ok(result);
    }
}
