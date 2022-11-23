using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

public partial class PeopleLink
{
    public string? Source { get; set; }

    public string Key { get; set; } = null!;

    public long PersonId { get; set; }

    public string Language { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
