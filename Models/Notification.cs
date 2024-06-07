using System;
using System.Collections.Generic;

namespace WebApplication14.Models;

public partial class Notification
{
    public int? NotificationId { get; set; }

    public string? NotificationSubject { get; set; }

    public string? NotificationCopy { get; set; }

    public DateTime? Lastdate { get; set; }
}
