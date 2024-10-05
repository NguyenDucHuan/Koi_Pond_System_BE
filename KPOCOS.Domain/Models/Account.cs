using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KPOCOS.Domain.Models;

public partial class Account
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<DiscountPound> DiscountPounds { get; set; } = new List<DiscountPound>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Pond> Ponds { get; set; } = new List<Pond>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    [JsonIgnore]
    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
}
