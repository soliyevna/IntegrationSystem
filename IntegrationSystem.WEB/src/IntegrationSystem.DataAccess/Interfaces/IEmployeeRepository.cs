using IntegrationSystem.Domain.Entities;

namespace IntegrationSystem.DataAccess.Interfaces;

/// <summary>
/// Represents a repository for performing CRUD operations specific to the <see cref="Employee"/> entity.
/// </summary>
public interface IEmployeeRepository: IBaseRepository<Employee>
{
    /// <summary>
    /// Asynchronously adds a range of employees to the database.
    /// </summary>
    /// <param name="employees">An <see cref="IEnumerable{Employee}"/> containing the employees to be added.</param>
    /// <remarks>
    /// This method adds the provided collection of <see cref="Employee"/> objects to the database context 
    /// and saves the changes asynchronously. It is intended for batch inserts to improve performance.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="employees"/> parameter is null.</exception>
    /// <exception cref="DbUpdateException">Thrown when an error occurs while saving changes to the database.</exception>
    Task AddRangeAsync(IEnumerable<Employee> employees);
}
