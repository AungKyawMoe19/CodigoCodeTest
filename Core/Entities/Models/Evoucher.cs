using System;
using System.Collections.Generic;

namespace Core.Entities.Models;

public partial class Evoucher
{
    public string EVoucherId { get; set; } = null!;

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public byte[]? Image { get; set; }

    public double? Amount { get; set; }

    public int? Quantity { get; set; }

    public string? QrCode { get; set; }

    public bool? Active { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifyBy { get; set; }

    public DateTime? ModifyOn { get; set; }

    public int? MaxEvoucher { get; set; }

    public int? MaxGiftEvoucher { get; set; }

    public virtual ICollection<Buyevoucher> Buyevouchers { get; set; } = new List<Buyevoucher>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
