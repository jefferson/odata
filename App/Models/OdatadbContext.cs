using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace odata_hello_world.App.Models;

public partial class OdatadbContext : DbContext
{
    public OdatadbContext(DbContextOptions<OdatadbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccessLog> AccessLogs { get; set; }

    public virtual DbSet<Cast> Casts { get; set; }

    public virtual DbSet<CastsView> CastsViews { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryName> CategoryNames { get; set; }

    public virtual DbSet<ImageId> ImageIds { get; set; }

    public virtual DbSet<ImageLicense> ImageLicenses { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobName> JobNames { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieAbstractsDe> MovieAbstractsDes { get; set; }

    public virtual DbSet<MovieAbstractsE> MovieAbstractsEs { get; set; }

    public virtual DbSet<MovieAbstractsEn> MovieAbstractsEns { get; set; }

    public virtual DbSet<MovieAbstractsFr> MovieAbstractsFrs { get; set; }

    public virtual DbSet<MovieAliasesIso> MovieAliasesIsos { get; set; }

    public virtual DbSet<MovieCountry> MovieCountries { get; set; }

    public virtual DbSet<MovieLanguage> MovieLanguages { get; set; }

    public virtual DbSet<MovieLink> MovieLinks { get; set; }

    public virtual DbSet<MovieReference> MovieReferences { get; set; }

    public virtual DbSet<PeopleAlias> PeopleAliases { get; set; }

    public virtual DbSet<PeopleLink> PeopleLinks { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Trailer> Trailers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("kind", new[] { "movie", "series", "season", "episode", "movieseries" })
            .HasPostgresExtension("pg_trgm")
            .HasPostgresExtension("tsm_system_rows");

        modelBuilder.Entity<AccessLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("access_log");

            entity.Property(e => e.ClientIp).HasColumnName("client_ip");
            entity.Property(e => e.Page).HasColumnName("page");
            entity.Property(e => e.Path).HasColumnName("path");
            entity.Property(e => e.Runtime).HasColumnName("runtime");
            entity.Property(e => e.Time)
                .HasDefaultValueSql("now()")
                .HasColumnName("time");
        });

        modelBuilder.Entity<Cast>(entity =>
        {
            entity.HasKey(e => new { e.MovieId, e.PersonId, e.JobId, e.Role, e.Position }).HasName("casts_pkey");

            entity.ToTable("casts");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Position).HasColumnName("position");

            entity.HasOne(d => d.Job).WithMany(p => p.Casts)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("casts_job_id_fkey");

            entity.HasOne(d => d.Movie).WithMany(p => p.Casts)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("casts_movie_id_fkey");

            entity.HasOne(d => d.Person).WithMany(p => p.Casts)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("casts_person_id_fkey");
        });

        modelBuilder.Entity<CastsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("casts_view");

            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Budget).HasColumnName("budget");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Deathday).HasColumnName("deathday");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Homepage).HasColumnName("homepage");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.JobName).HasColumnName("job_name");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.MovieName).HasColumnName("movie_name");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.PersonName).HasColumnName("person_name");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Revenue).HasColumnName("revenue");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Runtime).HasColumnName("runtime");
            entity.Property(e => e.SeriesId).HasColumnName("series_id");
            entity.Property(e => e.VoteAverage).HasColumnName("vote_average");
            entity.Property(e => e.VotesCount).HasColumnName("votes_count");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.RootId).HasColumnName("root_id");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("categories_parent_id_fkey");

            entity.HasOne(d => d.Root).WithMany(p => p.InverseRoot)
                .HasForeignKey(d => d.RootId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("categories_root_id_fkey");
        });

        modelBuilder.Entity<CategoryName>(entity =>
        {
            entity.HasKey(e => new { e.CategoryId, e.Language }).HasName("category_names_pkey");

            entity.ToTable("category_names");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Language).HasColumnName("language");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.Category).WithMany(p => p.CategoryNames)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("category_names_category_id_fkey");
        });

        modelBuilder.Entity<ImageId>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("image_ids_pkey");

            entity.ToTable("image_ids");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ImageVersion).HasColumnName("image_version");
            entity.Property(e => e.ObjectId).HasColumnName("object_id");
            entity.Property(e => e.ObjectType).HasColumnName("object_type");
        });

        modelBuilder.Entity<ImageLicense>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("image_licenses_pkey");

            entity.ToTable("image_licenses");

            entity.Property(e => e.ImageId)
                .ValueGeneratedNever()
                .HasColumnName("image_id");
            entity.Property(e => e.Author).HasColumnName("author");
            entity.Property(e => e.LicenseId).HasColumnName("license_id");
            entity.Property(e => e.Source).HasColumnName("source");

            entity.HasOne(d => d.Image).WithOne(p => p.ImageLicense)
                .HasForeignKey<ImageLicense>(d => d.ImageId)
                .HasConstraintName("image_licenses_image_id_fkey");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jobs_pkey");

            entity.ToTable("jobs", tb => tb.HasComment("English-only version of job_names"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<JobName>(entity =>
        {
            entity.HasKey(e => new { e.JobId, e.Language }).HasName("job_names_pkey");

            entity.ToTable("job_names");

            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.Language).HasColumnName("language");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.Job).WithMany(p => p.JobNames)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("job_names_job_id_fkey");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("movies_pkey");

            entity.ToTable("movies");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Budget).HasColumnName("budget");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Homepage).HasColumnName("homepage");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Revenue).HasColumnName("revenue");
            entity.Property(e => e.Runtime).HasColumnName("runtime");
            entity.Property(e => e.SeriesId).HasColumnName("series_id");
            entity.Property(e => e.VoteAverage).HasColumnName("vote_average");
            entity.Property(e => e.VotesCount).HasColumnName("votes_count");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("movies_parent_id_fkey");

            entity.HasOne(d => d.Series).WithMany(p => p.InverseSeries)
                .HasForeignKey(d => d.SeriesId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("movies_series_id_fkey");

            entity.HasMany(d => d.Categories).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieCategory",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("movie_categories_category_id_fkey"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .HasConstraintName("movie_categories_movie_id_fkey"),
                    j =>
                    {
                        j.HasKey("MovieId", "CategoryId").HasName("movie_categories_pkey");
                        j.ToTable("movie_categories");
                    });

            entity.HasMany(d => d.CategoriesNavigation).WithMany(p => p.MoviesNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieKeyword",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("movie_keywords_category_id_fkey"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .HasConstraintName("movie_keywords_movie_id_fkey"),
                    j =>
                    {
                        j.HasKey("MovieId", "CategoryId").HasName("movie_keywords_pkey");
                        j.ToTable("movie_keywords");
                    });
        });

        modelBuilder.Entity<MovieAbstractsDe>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("movie_abstracts_de_pkey");

            entity.ToTable("movie_abstracts_de");

            entity.Property(e => e.MovieId)
                .ValueGeneratedNever()
                .HasColumnName("movie_id");
            entity.Property(e => e.Abstract).HasColumnName("abstract");

            entity.HasOne(d => d.Movie).WithOne(p => p.MovieAbstractsDe)
                .HasForeignKey<MovieAbstractsDe>(d => d.MovieId)
                .HasConstraintName("movie_abstracts_de_movie_id_fkey");
        });

        modelBuilder.Entity<MovieAbstractsE>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("movie_abstracts_es_pkey");

            entity.ToTable("movie_abstracts_es");

            entity.Property(e => e.MovieId)
                .ValueGeneratedNever()
                .HasColumnName("movie_id");
            entity.Property(e => e.Abstract).HasColumnName("abstract");

            entity.HasOne(d => d.Movie).WithOne(p => p.MovieAbstractsE)
                .HasForeignKey<MovieAbstractsE>(d => d.MovieId)
                .HasConstraintName("movie_abstracts_es_movie_id_fkey");
        });

        modelBuilder.Entity<MovieAbstractsEn>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("movie_abstracts_en_pkey");

            entity.ToTable("movie_abstracts_en");

            entity.Property(e => e.MovieId)
                .ValueGeneratedNever()
                .HasColumnName("movie_id");
            entity.Property(e => e.Abstract).HasColumnName("abstract");

            entity.HasOne(d => d.Movie).WithOne(p => p.MovieAbstractsEn)
                .HasForeignKey<MovieAbstractsEn>(d => d.MovieId)
                .HasConstraintName("movie_abstracts_en_movie_id_fkey");
        });

        modelBuilder.Entity<MovieAbstractsFr>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("movie_abstracts_fr_pkey");

            entity.ToTable("movie_abstracts_fr");

            entity.Property(e => e.MovieId)
                .ValueGeneratedNever()
                .HasColumnName("movie_id");
            entity.Property(e => e.Abstract).HasColumnName("abstract");

            entity.HasOne(d => d.Movie).WithOne(p => p.MovieAbstractsFr)
                .HasForeignKey<MovieAbstractsFr>(d => d.MovieId)
                .HasConstraintName("movie_abstracts_fr_movie_id_fkey");
        });

        modelBuilder.Entity<MovieAliasesIso>(entity =>
        {
            entity.HasKey(e => new { e.MovieId, e.Name, e.Language, e.OfficialTranslation }).HasName("movie_aliases_iso_pkey");

            entity.ToTable("movie_aliases_iso");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Language).HasColumnName("language");
            entity.Property(e => e.OfficialTranslation).HasColumnName("official_translation");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieAliasesIsos)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("movie_aliases_iso_movie_id_fkey");
        });

        modelBuilder.Entity<MovieCountry>(entity =>
        {
            entity.HasKey(e => new { e.MovieId, e.Country }).HasName("movie_countries_pkey");

            entity.ToTable("movie_countries");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.Country).HasColumnName("country");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieCountries)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("movie_countries_movie_id_fkey");
        });

        modelBuilder.Entity<MovieLanguage>(entity =>
        {
            entity.HasKey(e => new { e.MovieId, e.Language }).HasName("movie_languages_pkey");

            entity.ToTable("movie_languages");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.Language).HasColumnName("language");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieLanguages)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("movie_languages_movie_id_fkey");
        });

        modelBuilder.Entity<MovieLink>(entity =>
        {
            entity.HasKey(e => new { e.MovieId, e.Language, e.Key }).HasName("movie_links_pkey");

            entity.ToTable("movie_links");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.Language).HasColumnName("language");
            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.Source).HasColumnName("source");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieLinks)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("movie_links_movie_id_fkey");
        });

        modelBuilder.Entity<MovieReference>(entity =>
        {
            entity.HasKey(e => new { e.MovieId, e.ReferencedId, e.Type }).HasName("movie_references_pkey");

            entity.ToTable("movie_references");

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.ReferencedId).HasColumnName("referenced_id");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieReferenceMovies)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("movie_references_movie_id_fkey");

            entity.HasOne(d => d.Referenced).WithMany(p => p.MovieReferenceReferenceds)
                .HasForeignKey(d => d.ReferencedId)
                .HasConstraintName("movie_references_referenced_id_fkey");
        });

        modelBuilder.Entity<PeopleAlias>(entity =>
        {
            entity.HasKey(e => new { e.PersonId, e.Name }).HasName("people_aliases_pkey");

            entity.ToTable("people_aliases");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.Person).WithMany(p => p.PeopleAliases)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("people_aliases_person_id_fkey");
        });

        modelBuilder.Entity<PeopleLink>(entity =>
        {
            entity.HasKey(e => new { e.PersonId, e.Language, e.Key }).HasName("people_links_pkey");

            entity.ToTable("people_links");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.Language).HasColumnName("language");
            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.Source).HasColumnName("source");

            entity.HasOne(d => d.Person).WithMany(p => p.PeopleLinks)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("people_links_person_id_fkey");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("people_pkey");

            entity.ToTable("people");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Deathday).HasColumnName("deathday");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Trailer>(entity =>
        {
            entity.HasKey(e => new { e.MovieId, e.TrailerId }).HasName("trailers_pkey");

            entity.ToTable("trailers", tb => tb.HasComment("Youtube/Vimeo Trailer"));

            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.TrailerId).HasColumnName("trailer_id");
            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.Language).HasColumnName("language");
            entity.Property(e => e.Source).HasColumnName("source");

            entity.HasOne(d => d.Movie).WithMany(p => p.Trailers)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("trailers_movie_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
