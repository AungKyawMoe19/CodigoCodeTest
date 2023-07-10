using System;
using System.Collections.Generic;

namespace Core.Entities.Models;

public partial class Payment
{
    public string PaymentId { get; set; } = null!;

    public string? PaymentType { get; set; }

    public bool? Active { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifyOn { get; set; }

    public string? ModifyBy { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
