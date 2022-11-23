using System;
using System.Collections.Generic;

namespace odata_hello_world.App.Models;

public partial class Category
{
    public long Id { get; set; }

    public long? ParentId { get; set; }

    public long? RootId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<CategoryName> CategoryNames { get; } = new List<CategoryName>();

    public virtual ICollection<Category> InverseParent { get; } = new List<Category>();

    public virtual ICollection<Category> InverseRoot { get; } = new List<Category>();

    public virtual Category? Parent { get; set; }

    public virtual Category? Root { get; set; }

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();

    public virtual ICollection<Movie> MoviesNavigation { get; } = new List<Movie>();
}
