using System;
using System.Collections.Generic;

namespace Dto_Common_Enteties;

public partial class BuyDto
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? UserName { get; set; }

    public DateTime? Date { get; set; }

    public int? Price { get; set; }

    public string? Note { get; set; }

}
