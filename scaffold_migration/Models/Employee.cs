using System;
using System.Collections.Generic;

namespace scaffold_migration.Models;

public partial class Employee
{
    public decimal EmpId { get; set; }

    public string EmpName { get; set; } = null!;

    public string EmpNo { get; set; } = null!;

    public DateTime HireDate { get; set; }

    public byte[]? Image { get; set; }

    public string Job { get; set; } = null!;

    public double Salary { get; set; }

    public int DeptId { get; set; }

    public decimal? MngId { get; set; }
    public string infoadd { get; set; }

    public virtual Department Dept { get; set; } = null!;

    public virtual ICollection<Employee> InverseMng { get; } = new List<Employee>();

    public virtual Employee? Mng { get; set; }

    public virtual ICollection<Timekeeper> Timekeepers { get; } = new List<Timekeeper>();
}
