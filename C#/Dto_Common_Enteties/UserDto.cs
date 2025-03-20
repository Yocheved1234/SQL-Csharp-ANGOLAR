using System;
using System.Collections.Generic;

namespace Dto_Common_Enteties;

public partial class UserDto
{
    public int Id { get; set; }

    public string? NameU { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Buys { get; set; }
}
