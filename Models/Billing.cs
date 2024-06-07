using System;
using System.Collections.Generic;

namespace WebApplication14.Models;

public partial class Billing
{
    public int BillingId { get; set; }

    public string? Transactionid { get; set; }

    public int? Totalprice { get; set; }

    public string? Remark { get; set; }

    public DateTime? Entereddate { get; set; }

    public DateTime? Transactiondate { get; set; }
}
