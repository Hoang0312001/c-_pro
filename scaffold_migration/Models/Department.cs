using System;
using System.Collections.Generic;

namespace scaffold_migration.Models;

public partial class Department
{
    public int DeptId { get; set; }

    public string DeptName { get; set; } = null!;

    public string DeptNo { get; set; } = null!;

    public string? Location { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
