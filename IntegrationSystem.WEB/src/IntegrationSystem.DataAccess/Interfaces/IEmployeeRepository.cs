using IntegrationSystem.Domain.Entities;

namespace IntegrationSystem.DataAccess.Interfaces;

/// <summary>
/// Represents a repository for performing CRUD operations specific to the <see cref="Employee"/> entity.
/// </summary>
public interface IEmployeeRepository: IBaseRepository<Employee>
{
}
