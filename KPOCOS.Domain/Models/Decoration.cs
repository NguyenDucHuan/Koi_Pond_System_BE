using System;
using System.Collections.Generic;

namespace KPOCOS.Domain.Models;

public partial class Decoration
{
    public int Id { get; set; }

    public string? DecorationName { get; set; }

    public string? Decription { get; set; }

    public int? DecorationTypeId { get; set; }

    public decimal? PricePerSquareMeter { get; set; }

    public virtual DecorationType? DecorationType { get; set; }

    public virtual ICollection<PondDecoration> PondDecorations { get; set; } = new List<PondDecoration>();
}
