using System;
using System.Collections.Generic;

namespace KPOCOS.Domain.Models;

public partial class DiscountPound
{
    public int DiscouId { get; set; }

    public int AccountId { get; set; }

    public decimal Amount { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Discount Discou { get; set; } = null!;
}
