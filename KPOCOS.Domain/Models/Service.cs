using System;
using System.Collections.Generic;

namespace KPOCOS.Domain.Models;

public partial class Service
{
    public int Id { get; set; }

    public int ServiceTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Decription { get; set; }

    public decimal PricePerM2 { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ServiceType ServiceType { get; set; } = null!;
}
