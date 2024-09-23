using System;
using System.Collections.Generic;

namespace KPOCOS.Domain.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime CreateOn { get; set; }

    public int AccountId { get; set; }

    public string Status { get; set; } = null!;

    public int? DiscouId { get; set; }

    public decimal TotalMoney { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Discount? Discou { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
