using IntegrationSystem.DataAccess.Interfaces;

namespace IntegrationSystem.Service.Interfaces;

public class IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public IEmployeeService(IEmployeeRepository employeeRepository)
    {
        this._employeeRepository = employeeRepository;
    }
}
