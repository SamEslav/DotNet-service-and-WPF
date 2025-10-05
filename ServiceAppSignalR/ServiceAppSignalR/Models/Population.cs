using System;
using System.Collections.Generic;

namespace ServiceAppSignalR.Models;

public partial class Population
{
    public int Id { get; set; }

    public string? Country { get; set; }

    public int? Quantity { get; set; }
}
