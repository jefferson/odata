using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

public partial class MovieReference
{
    public long MovieId { get; set; }

    public long ReferencedId { get; set; }

    public string Type { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;

    public virtual Movie Referenced { get; set; } = null!;
}
