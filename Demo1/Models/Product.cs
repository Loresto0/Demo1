using System;
using System.Collections.Generic;

namespace Demo1.Models;

public partial class Product
{
    public int Idproduct { get; set; }

    public string Title { get; set; } = null!;

    public string Cost { get; set; } = null!;

    public string? Description { get; set; }

    public string? Mainimagepath { get; set; }
}
