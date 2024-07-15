using System;
using System.Collections.Generic;

namespace ORM_SAMPLE.ORM_MODELS;

public partial class Employee
{
    public long Id { get; set; }

    public string EmployeId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }
}
