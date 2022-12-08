using System;
using System.Collections.Generic;

namespace scaffold_migration.Models;

public partial class SalaryGrade
{
    public int Grade { get; set; }

    public double HighSalary { get; set; }

    public double LowSalary { get; set; }
}
