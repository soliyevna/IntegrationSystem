using CsvHelper;
using IntegrationSystem.DataAccess.Interfaces;
using IntegrationSystem.Domain.Entities;
using IntegrationSystem.Service.CsvMappings;
using IntegrationSystem.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace IntegrationSystem.Service.Services;

/// <summary>
/// Provides methods for managing employee data.
/// </summary>
public class EmployeeService: IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmployeeService"/> class.
    /// </summary>
    /// <param name="employeeRepository">An <see cref="IEmployeeRepository"/> implementation for accessing employee data.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="employeeRepository"/> parameter is null.</exception>
    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        this._employeeRepository = employeeRepository;
    }

    /// <inheritdoc/>
    public async Task<(bool isSuccessful, string message, int numberOfRecordsAdded)> ImportEmployeesFromCVSFileAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return (isSuccessful: false,  message: "Invalid file",  numberOfRecordsAdded: 0);
        }

        var employees = new List<Employee>();
        try
        {
            using (var stream = file.OpenReadStream())
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Register the class map for proper column mapping
                csv.Context.RegisterClassMap<EmployeeCsvMap>();

                var records = csv.GetRecords<Employee>();

                foreach (var record in records)
                {
                    // Convert CSV model to Employee entity
                    var employee = new Employee
                    {
                        PayrollNumber = record.PayrollNumber,
                        Forenames = record.Forenames,
                        Surname = record.Surname,
                        DateOfBirth = record.DateOfBirth,
                        Telephone = record.Telephone,
                        Mobile = record.Mobile,
                        Address = record.Address,
                        Address2 = record.Address2,
                        Postcode = record.Postcode,
                        EmailHome = record.EmailHome,
                        StartDate = record.StartDate
                    };

                    employees.Add(employee);
                }
            }

            await _employeeRepository.AddRangeAsync(employees);
            await _employeeRepository.SaveAsync();

            return (isSuccessful: true, message: $"{employees.Count} employees added successfully.", numberOfRecordsAdded: employees.Count);
        }
        catch (CsvHelperException csvEx)
        {
            return (isSuccessful: false, message: $"CSV error: {csvEx.Message}", numberOfRecordsAdded: 0);
        }
        catch (DbUpdateException dbEx)
        {
            return (isSuccessful: false, message: $"Database error: {dbEx.Message}", numberOfRecordsAdded: 0);
        }
        catch (Exception ex)
        {
            return (isSuccessful: false, message: $"An error occurred: {ex.Message}", numberOfRecordsAdded: 0);
        }
    }
}