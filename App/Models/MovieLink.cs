using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

public partial class MovieLink
{
    public string? Source { get; set; }

    public string Key { get; set; } = null!;

    public long MovieId { get; set; }

    public string Language { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
