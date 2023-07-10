using System;
using System.Collections.Generic;

namespace Core.Entities.Models;

public partial class Transaction
{
    public string TransactionId { get; set; } = null!;

    public string? EVoucherId { get; set; }

    public string? Status { get; set; }

    public string? Phone { get; set; }

    public double? Amount { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public virtual Evoucher? EVoucher { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
