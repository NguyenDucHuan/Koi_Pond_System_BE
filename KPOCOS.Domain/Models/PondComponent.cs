using System;
using System.Collections.Generic;

namespace KPOCOS.Domain.Models;

public partial class PondComponent
{
    public int ComponentId { get; set; }

    public int PondId { get; set; }

    public decimal Amount { get; set; }

    public virtual Component Component { get; set; } = null!;

    public virtual Pond Pond { get; set; } = null!;
}
