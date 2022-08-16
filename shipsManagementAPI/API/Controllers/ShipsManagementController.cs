using MediatR;
using Microsoft.AspNetCore.Mvc;
using shipsManagementAPI.API;
using shipsManagementAPI.API.Queries;
using shipsManagementAPI.Data.ProgramDbContext;
using shipsManagementAPI.Data.Models;
using shipsManagementAPI.Data.Repository;
using shipsManagementAPI.API.DTOs;

namespace shipsManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipsManagementController : ControllerBase
{
    private AppDbContext _context;
    private ICustomerRepository _customerRepo;
    private ISupplierRepository _supplierRepo;
    private IOrderRepository _orderRepo;

    public ShipsManagementController(AppDbContext context, ICustomerRepository customerRepo, ISupplierRepository supplierRepo, IOrderRepository orderRepo)
    {
        _context = context;
        _customerRepo = customerRepo;
        _supplierRepo = supplierRepo;
        _orderRepo = orderRepo;
    }

    #region  SupplierCommands
    [HttpPost("CreateSupplier")]
    public async Task<ActionResult> CreateSuplier([FromBody] CreateSupplierDTO supplier)
    {
        try
        {
            var result = _supplierRepo.InsertSupplier(supplier);
            _supplierRepo.Save();
            return Ok(result.Id);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost("UpdateSupplier/{id}")]
    public async Task<ActionResult> UpdateSupplier([FromRoute] int id, [FromBody] UpdateSupplierDTO supplier)
    {
        try
        {
            var result = _supplierRepo.UpdateSupplier(id, supplier);
            _supplierRepo.Save();
            return Ok(result.Id);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("DeleteSupplier/{id}")]
    public async Task<ActionResult> DeleteSupplier([FromRoute] int id)
    {
        try
        {
            _supplierRepo.DeleteSupplier(id);
            _supplierRepo.Save();
            return Ok(id);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    #endregion

    #region SupplierQuery

    [HttpGet("Supplier/{id}")]
    public async Task<Supplier> GetSupplier([FromRoute] int id)
    {
        return _supplierRepo.GetSupplierById(id);
    }

    [HttpGet("Suppliers")]
    public List<Supplier> GetSuppliersList()
    {
        return _supplierRepo.GetSuppliers();
    }
    #endregion

    #region CountryCommands

    [HttpPost("CreateCountry")]
    public async Task<ActionResult> CreateCountry([FromBody] string countryName)
    {
        try
        {
            var result = _supplierRepo.InsertCountry(countryName);
            _supplierRepo.Save();
            return Ok(result.CountryId);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost("UpdateCountry/{id}")]
    public async Task<ActionResult> UpdateCountry([FromRoute] int id, [FromBody] string countryName)
    {
        var targetCountry = _supplierRepo.GetCountryById(id);

        try
        {
            var country = _supplierRepo.UpdateCountry(id, countryName);
            _supplierRepo.Save();
            return Ok(country.CountryId);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("DeleteCountry/{id}")]
    public async Task<ActionResult> DeleteCountry([FromRoute] int id)
    {
        try
        {
            _supplierRepo.DeleteCountry(id);
            _supplierRepo.Save();
            return Ok(id);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    #endregion

    #region CountryQueries

    [HttpGet("Country/{id}")]
    public async Task<Country> GetCountry([FromRoute] int id)
    {
        return _supplierRepo.GetCountryById(id);
    }

    [HttpGet("Countries")]
    public List<Country> GetCountriesList()
    {
        return _supplierRepo.GetCountries();
    }

    #endregion

    #region EmployeeCommands

    [HttpPost("CreateEmployee")]
    public async Task<ActionResult> CreateEmployee([FromBody] CreateEmployeeDTO employee)
    {
        try
        {
            var result = _supplierRepo.InsertEmployee(employee);
            _supplierRepo.Save();

            // ?_supplierRepo.PopulateEmployee(result.idSupplierCompany, result);

            return Ok(result.Id);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost("UpdateEmployee/{id}")]
    public async Task<ActionResult> UpdateEmployee([FromRoute] int id, [FromBody] UpdateEmployeeDTO employee)
    {
        var targetEmployee = _supplierRepo.GetEmployeeById(id);

        try
        {
            var result = _supplierRepo.UpdateEmployee(id, employee);
            _supplierRepo.Save();
            return Ok(result.Id);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("DeleteEmployee/{id}")]
    public async Task<ActionResult> DeleteEmployee([FromRoute] int id)
    {
        try
        {
            _supplierRepo.DeleteEmployee(id);
            _supplierRepo.Save();
            return Ok(id);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    #endregion

    #region EmployeeQueries

    [HttpGet("Employee/{id}")]
    public async Task<Employee> GetEmployee([FromRoute] int id)
    {
        return _supplierRepo.GetEmployeeById(id);
    }

    [HttpGet("Employees")]
    public List<Employee> GetEmployeesList()
    {
        return _supplierRepo.GetEmployees();
    }

    #endregion

    #region CustomerCommands

    [HttpPost("CreateCustomer")]
    public async Task<ActionResult> CreateCustomer([FromBody] CreateCustomerDTO customer)
    {
        try
        {
            var result = _customerRepo.InsertCustomer(customer);
            _supplierRepo.Save();

            return Ok(result.Id);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost("UpdateCustomer/{id}")]
    public async Task<ActionResult> UpdateCustomer([FromRoute] int id, [FromBody] UpdateCustomerDTO customer)
    {
        var customerToUpdate = _customerRepo.GetCustomerById(id);

        try
        {
            var result = _customerRepo.UpdateCustomer(id, customer);
            _supplierRepo.Save();
            return Ok(result.Id);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("DeleteCustomer/{id}")]
    public async Task<ActionResult> DeleteCustomer([FromRoute] int id)
    {
        try
        {
            _customerRepo.DeleteCustomer(id);
            _customerRepo.Save();
            return Ok(id);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    #endregion

    #region CustomerQueries

    [HttpGet("Customer/{id}")]
    public async Task<Customer> GetCustomer([FromRoute] int id)
    {
        return _customerRepo.GetCustomerById(id);
    }

    [HttpGet("Customers")]
    public List<Customer> GetCustomersList()
    {
        return _customerRepo.GetCustomers();
    }

    #endregion

    #region  Order Commands

    [HttpPost("CreateOrder")]
    public async Task<ActionResult> CreateOrder([FromBody] CreateOrderDTO order)
    {
        try
        {
            var result = _orderRepo.InsertOrder(order);
            _orderRepo.Save();
            return Ok(result.CustomerId);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost("UpdateOrder/{id}")]
    public async Task<ActionResult> UpdateOrder([FromRoute] int id, [FromBody] UpdateOrderDTO order)
    {
        try
        {
            var result = _orderRepo.UpdateOrder(id, order);
            _orderRepo.Save();
            return Ok(result.CustomerId);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("DeleteOrder/{id}")]
    public async Task<ActionResult> DeleteOrder([FromRoute] int id)
    {
        try
        {
            _orderRepo.DeleteOrder(id);
            _orderRepo.Save();
            return Ok(id);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    #endregion

    #region Order queries

    [HttpGet("Order/{id}")]
    public async Task<Order> GetOrder([FromRoute] int id)
    {
        return _orderRepo.GetOrderById(id);
    }

    [HttpGet("Orders")]
    public List<Order> GetOrdersList()
    {
        return _orderRepo.GetOrders();
    }

    #endregion
}
