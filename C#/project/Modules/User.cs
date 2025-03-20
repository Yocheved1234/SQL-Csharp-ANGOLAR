using System;
using System.Collections.Generic;

namespace Dal_Repository.Modules;

public partial class User
{
    public int Id { get; set; }

    public string? NameU { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Buys { get; set; }

    public virtual ICollection<Buy> BuysNavigation { get; set; } = new List<Buy>();
}
