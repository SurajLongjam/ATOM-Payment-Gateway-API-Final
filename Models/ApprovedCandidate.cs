using System;
using System.Collections.Generic;

namespace WebApplication14.Models;

public partial class ApprovedCandidate
{
    public long? AppId { get; set; }

    public string? FullName { get; set; }

    public string? PostCode { get; set; }

    public int? RollNo { get; set; }

    public int? CenterCode { get; set; }

    public string? CenterName { get; set; }

    public string? Acdownloaded { get; set; }

    public DateTime? Acdownloadedon { get; set; }

    public string? ExamTime { get; set; }
}
