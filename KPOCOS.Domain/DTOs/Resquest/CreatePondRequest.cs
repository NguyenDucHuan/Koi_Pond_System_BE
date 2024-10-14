using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Resquest
{
    public class CreatePondRequest
    {
        public string PondName { get; set; } = null!;

        public string? Decription { get; set; }

        public decimal? PondDepth { get; set; }

        public decimal? Area { get; set; }

        public string? Location { get; set; }

        public string? Shape { get; set; }

        public int AccountId { get; set; }

        public string? DesignImage { get; set; }
    }
}