using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

public partial class CastsView
{
    public long? MovieId { get; set; }

    public string? MovieName { get; set; }

    public long? ParentId { get; set; }

    public DateOnly? Date { get; set; }

    public long? SeriesId { get; set; }

    public int? Runtime { get; set; }

    public decimal? Budget { get; set; }

    public decimal? Revenue { get; set; }

    public string? Homepage { get; set; }

    public decimal? VoteAverage { get; set; }

    public long? VotesCount { get; set; }

    public long? PersonId { get; set; }

    public string? PersonName { get; set; }

    public DateOnly? Birthday { get; set; }

    public DateOnly? Deathday { get; set; }

    public int? Gender { get; set; }

    public long? JobId { get; set; }

    public string? JobName { get; set; }

    public string? Role { get; set; }

    public int? Position { get; set; }
}
