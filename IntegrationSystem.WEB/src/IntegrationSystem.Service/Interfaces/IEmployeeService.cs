using IntegrationSystem.DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;

namespace IntegrationSystem.Service.Interfaces;

/// <summary>
/// Provides methods for managing employee data.
/// </summary>
public interface IEmployeeService
{
    /// <summary>
    /// Asynchronously imports employee data from a CSV file.
    /// </summary>
    /// <param name="file">An <see cref="IFormFile"/> representing the uploaded CSV file containing employee records.</param>
    /// <returns>
    /// A task that represents the asynchronous operation, containing a tuple with the following:
    /// <list type="bullet">
    /// <item><description><c>isSuccessful</c>: A boolean indicating whether the import was successful.</description></item>
    /// <item><description><c>message</c>: A string containing a message describing the result of the operation.</description></item>
    /// <item><description><c>numberOfRecordsAdded</c>: An integer representing the number of employee records successfully added to the database.</description></item>
    /// </list>
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="file"/> parameter is null.</exception>
    /// <exception cref="FormatException">Thrown when the CSV file format is invalid or cannot be parsed.</exception>
    /// <exception cref="DbUpdateException">Thrown when an error occurs while saving changes to the database.</exception>
    public Task<(bool isSuccessful, string message, int numberOfRecordsAdded)> ImportEmployeesFromCVSFileAsync(IFormFile file);
}
