using System;
using System.Collections.Generic;

namespace KPOCOS.Domain.Models;

public partial class Discount
{
    public int Id { get; set; }

    public string? FieldOnDiscount { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal? MinRequireDiscount { get; set; }

    public decimal? MaxTotalDiscount { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? FinishTime { get; set; }

    public decimal? Amount { get; set; }

    public decimal? RemainingAmount { get; set; }

    public virtual ICollection<DiscountPound> DiscountPounds { get; set; } = new List<DiscountPound>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
