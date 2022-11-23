using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace odata_hello_world.App.Models;

public partial class MovieLink
{
    [Key]
    public string Key { get; set; } = null!;

    public string? Source { get; set; }

    public long MovieId { get; set; }

    public string Language { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
