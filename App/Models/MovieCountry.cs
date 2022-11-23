using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

public partial class MovieCountry
{
    public long MovieId { get; set; }

    public string Country { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
