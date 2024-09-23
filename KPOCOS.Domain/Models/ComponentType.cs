using System;
using System.Collections.Generic;

namespace KPOCOS.Domain.Models;

public partial class ComponentType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Component> Components { get; set; } = new List<Component>();
}
