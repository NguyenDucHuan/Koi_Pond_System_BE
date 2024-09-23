using System;
using System.Collections.Generic;

namespace KPOCOS.Domain.Models;

public partial class Rating
{
    public int RatingId { get; set; }

    public string? Image { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public int? Star { get; set; }

    public DateTime? CreateOn { get; set; }

    public int AccountId { get; set; }

    public int OrderItemId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual OrderItem OrderItem { get; set; } = null!;
}
