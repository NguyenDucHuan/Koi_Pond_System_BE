using System;
using System.Collections.Generic;

namespace KPOCOS.Domain.Models;

public partial class UserProfile
{
    public int UserId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Phone { get; set; }

    public DateOnly? Birthday { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;
}
