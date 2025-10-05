using System;
using System.Collections.Generic;

namespace ServiceAppSignalR.Models;

public partial class TblUser
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Dept { get; set; } = null!;
}
