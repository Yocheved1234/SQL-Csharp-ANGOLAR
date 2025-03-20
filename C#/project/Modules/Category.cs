using System;
using System.Collections.Generic;

namespace Dal_Repository.Modules;

public partial class Category
{
    public int Id { get; set; }

    public string? NameCategory { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
