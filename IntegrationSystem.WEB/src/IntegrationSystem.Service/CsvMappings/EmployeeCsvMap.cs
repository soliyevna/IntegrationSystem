using CsvHelper.Configuration;
using IntegrationSystem.Domain.Entities;

namespace IntegrationSystem.Service.CsvMappings;

/// <summary>
/// Maps CSV columns to the <see cref="Employee"/> class properties for importing employee data.
/// </summary>
public class EmployeeCsvMap: ClassMap<Employee>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmployeeCsvMap"/> class.
    /// </summary>
    public EmployeeCsvMap()
    {
        Map(m => m.PayrollNumber).Name("Personnel_Records.Payroll_Number");
        Map(m => m.Forenames).Name("Personnel_Records.Forenames");
        Map(m => m.Surname).Name("Personnel_Records.Surname");
        Map(m => m.DateOfBirth).Name("Personnel_Records.Date_of_Birth").TypeConverter<StringToDateOnlyConverter>();
        Map(m => m.Telephone).Name("Personnel_Records.Telephone");
        Map(m => m.Mobile).Name("Personnel_Records.Mobile");
        Map(m => m.Address).Name("Personnel_Records.Address");
        Map(m => m.Address2).Name("Personnel_Records.Address_2");
        Map(m => m.Postcode).Name("Personnel_Records.Postcode");
        Map(m => m.EmailHome).Name("Personnel_Records.EMail_Home");
        Map(m => m.StartDate).Name("Personnel_Records.Start_Date").TypeConverter<StringToDateOnlyConverter>();
    }
}