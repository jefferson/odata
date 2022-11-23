using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

public partial class CategoryName
{
    public long CategoryId { get; set; }

    public string? Name { get; set; }

    public string Language { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}
