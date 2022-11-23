using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

public partial class Person
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public DateOnly? Birthday { get; set; }

    public DateOnly? Deathday { get; set; }

    public int? Gender { get; set; }

    public virtual ICollection<Cast> Casts { get; } = new List<Cast>();

    public virtual ICollection<PeopleAlias> PeopleAliases { get; } = new List<PeopleAlias>();

    public virtual ICollection<PeopleLink> PeopleLinks { get; } = new List<PeopleLink>();
}
