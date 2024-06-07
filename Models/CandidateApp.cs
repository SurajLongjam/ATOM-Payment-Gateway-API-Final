using System;
using System.Collections.Generic;

namespace WebApplication14.Models;

public partial class CandidateApp
{
    public long CanId { get; set; }

    public int NotificationId { get; set; }

    public string FullName { get; set; } = null!;

    public string? PreAddress { get; set; }

    public string? PrePin { get; set; }

    public string? PreMobile { get; set; }

    public string? PermAddress { get; set; }

    public string? PermPin { get; set; }

    public string? PermMobile { get; set; }

    public DateTime? DoB { get; set; }

    public string? Age { get; set; }

    public string? Gender { get; set; }

    public string? Nationality { get; set; }

    public string? MotherTongue { get; set; }

    public string? Category { get; set; }

    public string? FatherName { get; set; }

    public string? MotherName { get; set; }

    public string? PhotoPath { get; set; }

    public string? InstitutionName { get; set; }

    public string? InstitutionAddress { get; set; }

    public string? BoardName { get; set; }
}
