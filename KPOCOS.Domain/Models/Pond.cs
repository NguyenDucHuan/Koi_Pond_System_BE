using System;
using System.Collections.Generic;

namespace KPOCOS.Domain.Models;

public partial class Pond
{
    public int Id { get; set; }

    public string PondName { get; set; } = null!;

    public string? Decription { get; set; }

    public decimal? PondDepth { get; set; }

    public decimal? Area { get; set; }

    public string? Location { get; set; }

    public string? Shape { get; set; }

    public int AccountId { get; set; }

    public string? DesignImage { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<PondComponent> PondComponents { get; set; } = new List<PondComponent>();
}
