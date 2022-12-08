using System;
using System.Collections.Generic;

namespace scaffold_migration.Models;

public partial class Timekeeper
{
    public string TimekeeperId { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public string InOut { get; set; } = null!;

    public decimal EmpId { get; set; }

    public virtual Employee Emp { get; set; } = null!;
}
