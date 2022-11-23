using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

public partial class Movie
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public long? ParentId { get; set; }

    public DateOnly? Date { get; set; }

    public long? SeriesId { get; set; }

    public int? Runtime { get; set; }

    public decimal? Budget { get; set; }

    public decimal? Revenue { get; set; }

    public string? Homepage { get; set; }

    public decimal? VoteAverage { get; set; }

    public long? VotesCount { get; set; }

    public virtual ICollection<Cast> Casts { get; } = new List<Cast>();

    public virtual ICollection<Movie> InverseParent { get; } = new List<Movie>();

    public virtual ICollection<Movie> InverseSeries { get; } = new List<Movie>();

    public virtual MovieAbstractsDe? MovieAbstractsDe { get; set; }

    public virtual MovieAbstractsE? MovieAbstractsE { get; set; }

    public virtual MovieAbstractsEn? MovieAbstractsEn { get; set; }

    public virtual MovieAbstractsFr? MovieAbstractsFr { get; set; }

    public virtual ICollection<MovieAliasesIso> MovieAliasesIsos { get; } = new List<MovieAliasesIso>();

    public virtual ICollection<MovieCountry> MovieCountries { get; } = new List<MovieCountry>();

    public virtual ICollection<MovieLanguage> MovieLanguages { get; } = new List<MovieLanguage>();

    public virtual ICollection<MovieLink> MovieLinks { get; } = new List<MovieLink>();

    public virtual ICollection<MovieReference> MovieReferenceMovies { get; } = new List<MovieReference>();

    public virtual ICollection<MovieReference> MovieReferenceReferenceds { get; } = new List<MovieReference>();

    public virtual Movie? Parent { get; set; }

    public virtual Movie? Series { get; set; }

    public virtual ICollection<Trailer> Trailers { get; } = new List<Trailer>();

    public virtual ICollection<Category> Categories { get; } = new List<Category>();

    public virtual ICollection<Category> CategoriesNavigation { get; } = new List<Category>();
}
