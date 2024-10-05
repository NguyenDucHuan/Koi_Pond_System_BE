﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KPOCOS.Domain.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Type { get; set; }
    [JsonIgnore]
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
