using System;
using System.Collections.Generic;

namespace Dal_Repository.Modules;

public partial class Buy
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? Date { get; set; }

    public int? Price { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<BuysDetail> BuysDetails { get; set; } = new List<BuysDetail>();

    public virtual User? User { get; set; }
}
