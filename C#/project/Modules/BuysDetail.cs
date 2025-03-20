using System;
using System.Collections.Generic;

namespace Dal_Repository.Modules;

public partial class BuysDetail
{
    public int Id { get; set; }

    public int? BuyId { get; set; }

    public int? ProductId { get; set; }

    public int? Amount { get; set; }

    public virtual Buy? Buy { get; set; }

    public virtual Product? Product { get; set; }
}
