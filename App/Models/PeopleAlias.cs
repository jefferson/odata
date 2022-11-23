using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

public partial class PeopleAlias
{
    public long PersonId { get; set; }

    public string Name { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
