using System;
using System.Collections.Generic;

namespace Core.Entities.Models;

public partial class Buyevoucher
{
    public string BuyTypeId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? BuyType { get; set; }

    public string? EVoucherId { get; set; }

    public bool? Active { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifyOn { get; set; }

    public string? ModifyBy { get; set; }

    public virtual Evoucher? EVoucher { get; set; }
}
