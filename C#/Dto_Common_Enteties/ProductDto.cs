using System;
using System.Collections.Generic;

namespace Dto_Common_Enteties;

public partial class ProductDto
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public string? DescriptionP { get; set; }

    public int? Price { get; set; }

    public string? ImageP { get; set; }

    public DateTime? Date { get; set; }

    public int? Winner { get; set; }

    public string? Info { get; set; }

}
