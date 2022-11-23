using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

/// <summary>
/// Youtube/Vimeo Trailer
/// </summary>
public partial class Trailer
{
    public long TrailerId { get; set; }

    public string? Key { get; set; }

    public long MovieId { get; set; }

    public string? Language { get; set; }

    public string? Source { get; set; }

    public virtual Movie Movie { get; set; } = null!;
}
