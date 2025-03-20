using System;
using System.Collections.Generic;

namespace Dto_Common_Enteties;

public partial class BuysDetailDto
{
    public int Id { get; set; }

    public int? BuyId { get; set; }

    public int? ProductId { get; set; }

    public int? Amount { get; set; }

    public string? ProductN { get; set; }

}
