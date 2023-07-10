using System;
using System.Collections.Generic;

namespace Core.Entities.Models;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public string? OrderCode { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? EVoucherId { get; set; }

    public string? PaymentId { get; set; }

    public string? TransactionId { get; set; }

    public int? Quantity { get; set; }

    public bool? Active { get; set; }

    public virtual Evoucher? EVoucher { get; set; }

    public virtual Payment? Payment { get; set; }

    public virtual Transaction? Transaction { get; set; }
}
