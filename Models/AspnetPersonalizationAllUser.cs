﻿using System;
using System.Collections.Generic;

namespace WebApplication14.Models;

public partial class AspnetPersonalizationAllUser
{
    public Guid PathId { get; set; }

    public byte[] PageSettings { get; set; } = null!;

    public DateTime LastUpdatedDate { get; set; }

    public virtual AspnetPath Path { get; set; } = null!;
}
