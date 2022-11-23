using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

public partial class ImageId
{
    public long Id { get; set; }

    public long? ObjectId { get; set; }

    public string? ObjectType { get; set; }

    public int? ImageVersion { get; set; }

    public virtual ImageLicense? ImageLicense { get; set; }
}
