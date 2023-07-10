using System;
using System.Collections.Generic;

namespace Core.Entities.Models;

public partial class Promotion
{
    public string PromotionId { get; set; } = null!;

    public string? PromoCode { get; set; }

    public string? EVoucherId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifyOn { get; set; }

    public string? ModifyBy { get; set; }

    public sbyte? Active { get; set; }

    public virtual Evoucher? EVoucher { get; set; }
}
