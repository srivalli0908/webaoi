using System;
using System.Collections.Generic;

namespace ORM_SAMPLE.ORM_MODELS;

public partial class Salary
{
    public long Id { get; set; }

    public string EmpId { get; set; } = null!;

    public int Salary1 { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }
}
