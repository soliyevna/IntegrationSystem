using System.ComponentModel.DataAnnotations;

namespace IntegrationSystem.Domain.Entities;

/// <summary>
/// Represents an employee within the integration system.
/// </summary>
public class Employee: BaseEntity
{
    /// <summary>
    /// Gets or sets the payroll number of the employee.
    /// Maximum length is 100 characters.
    /// </summary>
    [StringLength(100, ErrorMessage = "PayrollNumber cannot exceed 100 characters.")]
    public string PayrollNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the forenames of the employee.
    /// Maximum length is 100 characters.
    /// </summary>
    [StringLength(100, ErrorMessage = "Forenames cannot exceed 100 characters.")]
    public string Forenames { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the surname of the employee.
    /// Maximum length is 100 characters.
    /// </summary>
    [StringLength(100, ErrorMessage = "Surname cannot exceed 100 characters.")]
    public string Surname { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date of birth of the employee.
    /// </summary>
    public DateOnly DateOfBirth { get; set; }

    /// <summary>
    /// Gets or sets the telephone number of the employee.
    /// Maximum length is 100 characters.
    /// </summary>
    [StringLength(100, ErrorMessage = "Telephone cannot exceed 100 characters.")]
    public string Telephone { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the mobile phone number of the employee.
    /// Maximum length is 100 characters.
    /// </summary>
    [StringLength(100, ErrorMessage = "Mobile cannot exceed 100 characters.")]
    public string Mobile { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the primary address of the employee.
    /// Maximum length is 100 characters.
    /// </summary>
    [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters.")]
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the secondary address of the employee.
    /// Maximum length is 100 characters.
    /// </summary>
    [StringLength(100, ErrorMessage = "Address2 cannot exceed 100 characters.")]
    public string Address2 { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the postcode of the employee's address.
    /// Maximum length is 100 characters.
    /// </summary>
    [StringLength(100, ErrorMessage = "Postcode cannot exceed 100 characters.")]
    public string Postcode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the employee's home email address.
    /// Maximum length is 100 characters.
    /// </summary>
    [StringLength(100, ErrorMessage = "EmailHome cannot exceed 100 characters.")]
    public string EmailHome { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the employee's start date in the organization.
    /// </summary>
    public DateOnly StartDate { get; set; }
}