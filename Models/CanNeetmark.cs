using System;
using System.Collections.Generic;

namespace WebApplication14.Models;

public partial class CanNeetmark
{
    public long CanAppId { get; set; }

    public long? CanNeetId { get; set; }

    public decimal? Physics { get; set; }

    public decimal? Chemistry { get; set; }

    public decimal? Biology { get; set; }
}
