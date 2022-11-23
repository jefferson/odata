using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

public partial class MovieAbstractsE
{
    public long MovieId { get; set; }

    public string? Abstract { get; set; }

    public virtual Movie Movie { get; set; } = null!;
}
