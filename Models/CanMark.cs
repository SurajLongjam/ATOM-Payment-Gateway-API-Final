using System;
using System.Collections.Generic;

namespace WebApplication14.Models;

public partial class CanMark
{
    public long CanApp { get; set; }

    public long CanMarksId { get; set; }

    public string? SubjectName { get; set; }

    public decimal? MarksObtained { get; set; }

    public decimal? MarkAllotted { get; set; }

    public decimal? Percentage { get; set; }
}
