using System;
using System.Collections.Generic;

namespace WebApplication14.Models;

public partial class ApplicationStatus
{
    public long StatId { get; set; }

    public long? AppId { get; set; }

    public string? ApplicationStatus1 { get; set; }

    public string? AppState { get; set; }

    public DateTime? DoE { get; set; }

    public string? EntryBy { get; set; }
}
