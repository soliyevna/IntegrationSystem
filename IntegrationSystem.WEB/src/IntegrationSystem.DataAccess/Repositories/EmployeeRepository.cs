using IntegrationSystem.DataAccess.DbContexts;
using IntegrationSystem.DataAccess.Interfaces;
using IntegrationSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntegrationSystem.DataAccess.Repositories;

/// <summary>
/// Represents a repository for performing CRUD operations specific to the <see cref="Employee"/> entity.
/// </summary>
public class EmployeeRepository: BaseRepository<Employee>, IEmployeeRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmployeeRepository"/> class with the provided database context.
    /// </summary>
    /// <param name="context">The database context associated with the repository.</param>
    public EmployeeRepository(DataContext dataContext): base(dataContext)
    {
        
    }

    /// <inheritdoc/>
    public async Task AddRangeAsync(IEnumerable<Employee> employees)
    {
        await _dataContext.Employees.AddRangeAsync(employees);
    }
}