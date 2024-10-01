using System;
using System.Collections.Generic;

namespace Demo1.Models;

public partial class Client
{
    public int Idclient { get; set; }

    public string Nameclient { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Idgender { get; set; }

    public virtual Gender IdgenderNavigation { get; set; } = null!;

    public virtual ICollection<Tag> Idtags { get; set; } = new List<Tag>();
}
