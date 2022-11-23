using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

/// <summary>
/// English-only version of job_names
/// </summary>
public partial class Job
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Cast> Casts { get; } = new List<Cast>();

    public virtual ICollection<JobName> JobNames { get; } = new List<JobName>();
}
