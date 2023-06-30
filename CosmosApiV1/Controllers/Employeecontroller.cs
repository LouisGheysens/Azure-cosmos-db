using Business.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CosmosApiV1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class Employeecontroller : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public Employeecontroller(IEmployeeService employeeService)
    {
        this._employeeService = employeeService;
    }


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllEmployees()
    {
        var response = await _employeeService.GetAllEmployees();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var response = await _employeeService.GetById(id);
        return Ok(response);
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> PutEmployee(string id, Employee employee)
    {
        await _employeeService.UpdateAsync(id, employee);
        return Ok(employee);
    }


    [HttpPost("Save")]
    public async Task<IActionResult> PostEmployee(Employee employee)
    {
        await _employeeService.AddAsync(employee);
        return Ok(employee);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteEmployee(string id)
    {
        await _employeeService.DeleteAsync(id);
        return NoContent();
    }
}
