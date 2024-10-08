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

    [HttpPost]
    [Route("Employee/Upload")]
    public async Task<IActionResult> UploadAsync(IFormFile employeeFile)
    {
        if (employeeFile != null && employeeFile.Length > 0)
        {
            var res = await _employeeService.ImportEmployeesFromCVSFileAsync(employeeFile);
        }
        return RedirectToAction("Index");
    }
}