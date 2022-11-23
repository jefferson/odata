using System;
using System.Collections.Generic;
using System.Net;

namespace odata_hello_world.App.Models;

public partial class AccessLog
{
    public DateTime Time { get; set; }

    public IPAddress? ClientIp { get; set; }

    public string Page { get; set; } = null!;

    public string Path { get; set; } = null!;

    public double? Runtime { get; set; }
}
