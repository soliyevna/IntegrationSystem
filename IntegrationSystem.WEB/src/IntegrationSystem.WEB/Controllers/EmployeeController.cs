using IntegrationSystem.Service.Attributes;
using IntegrationSystem.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationSystem.WEB.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        this._employeeService = employeeService;
    }

    public IActionResult Index()
    {
        return View();
    }
}