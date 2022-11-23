using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

public partial class JobName
{
    public long JobId { get; set; }

    public string? Name { get; set; }

    public string Language { get; set; } = null!;

    public virtual Job Job { get; set; } = null!;
}
