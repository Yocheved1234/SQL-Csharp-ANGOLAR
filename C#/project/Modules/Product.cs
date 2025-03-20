using System;
using System.Collections.Generic;

namespace Dal_Repository.Modules;

public partial class Product
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public string? DescriptionP { get; set; }

    public int? Price { get; set; }

    public string? ImageP { get; set; }

    public DateTime? Date { get; set; }

    public int? Winner { get; set; }

    public string? Info { get; set; }

    public virtual ICollection<BuysDetail> BuysDetails { get; set; } = new List<BuysDetail>();

    public virtual Category? Category { get; set; }
}
