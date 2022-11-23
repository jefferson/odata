using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

public partial class ImageLicense
{
    public long ImageId { get; set; }

    public string? Source { get; set; }

    public long? LicenseId { get; set; }

    public string? Author { get; set; }

    public virtual ImageId Image { get; set; } = null!;
}
