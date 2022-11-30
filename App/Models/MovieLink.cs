using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace odata_hello_world.App.Models;

public partial class MovieLink
{

    [Key]
    [Column(Order = 1)]
    public long MovieId { get; set; }

    [Key]
    [Column(Order = 2)]
    public string Language { get; set; } = null!;

    [Key]
    [Column(Order = 3)]
    public string Key { get; set; } = null!;

    public string? Source { get; set; }





    public virtual Movie Movie { get; set; } = null!;
}
