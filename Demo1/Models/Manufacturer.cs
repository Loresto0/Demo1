using System;
using System.Collections.Generic;

namespace Demo1.Models;

public partial class Manufacturer
{
    public int Idmanufacturer { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly Startdate { get; set; }
}
