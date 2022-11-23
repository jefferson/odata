using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

public partial class MovieAliasesIso
{
    public long MovieId { get; set; }

    public string Name { get; set; } = null!;

    public string Language { get; set; } = null!;

    public int OfficialTranslation { get; set; }

    public virtual Movie Movie { get; set; } = null!;
}
