using System;
using System.Collections.Generic;

namespace KPOCOS.Domain.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
