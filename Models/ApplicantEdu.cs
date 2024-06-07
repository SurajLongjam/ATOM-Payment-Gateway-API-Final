using System;
using System.Collections.Generic;

namespace WebApplication14.Models;

public partial class ApplicantEdu
{
    public long EduId { get; set; }

    public long? AppId { get; set; }

    public string? CourseName { get; set; }

    public string? BoardName { get; set; }

    public string? YearofPassing { get; set; }

    public string? CertificatePath { get; set; }

    public string? MarkSheetPath { get; set; }

    public string? DivGrade { get; set; }
}
