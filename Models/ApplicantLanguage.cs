using System;
using System.Collections.Generic;

namespace WebApplication14.Models;

public partial class ApplicantLanguage
{
    public long LangId { get; set; }

    public long? AppId { get; set; }

    public string? Language { get; set; }

    public string? States { get; set; }
}
