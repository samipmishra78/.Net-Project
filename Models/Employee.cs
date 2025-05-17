using System;
using System.Collections.Generic;

namespace student.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Desgination { get; set; } = null!;

    public int Salary { get; set; }
}
