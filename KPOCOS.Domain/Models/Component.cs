using System;
using System.Collections.Generic;

namespace KPOCOS.Domain.Models;

public partial class Component
{
    public int Id { get; set; }

    public string? Decription { get; set; }

    public string Name { get; set; } = null!;

    public decimal PricePerItem { get; set; }

    public int ComponentTypeId { get; set; }

    public string? Image { get; set; }

    public virtual ComponentType ComponentType { get; set; } = null!;

    public virtual ICollection<PondComponent> PondComponents { get; set; } = new List<PondComponent>();
}
