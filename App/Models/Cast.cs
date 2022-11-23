using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

public partial class Cast
{
    public long MovieId { get; set; }

    public long PersonId { get; set; }

    public long JobId { get; set; }

    public string Role { get; set; } = null!;

    public int Position { get; set; }

    public virtual Job Job { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
