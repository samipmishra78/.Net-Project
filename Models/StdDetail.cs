using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace student.Models;

public partial class StdDetail
{
    public int StdId { get; set; }

    public string Email { get; set; } = null!;

    [DataType("Datatype")] //hide password
    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Class { get; set; }
}
