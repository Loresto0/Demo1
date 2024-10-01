using System;
using System.Collections.Generic;

namespace Demo1.Models;

public partial class Gender
{
    public int Idgender { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
