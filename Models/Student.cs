using System;
using System.Collections.Generic;

namespace student.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Gender { get; set; } = null!;

    public string StudentName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Standard { get; set; }
}
