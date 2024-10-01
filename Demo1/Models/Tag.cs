using System;
using System.Collections.Generic;

namespace Demo1.Models;

public partial class Tag
{
    public int Idtag { get; set; }

    public string Titletag { get; set; } = null!;

    public string? Color { get; set; }

    public virtual ICollection<Client> Idclients { get; set; } = new List<Client>();
}
