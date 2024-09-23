using System;
using System.Collections.Generic;

namespace KPOCOS.Domain.Models;

public partial class ServiceType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
