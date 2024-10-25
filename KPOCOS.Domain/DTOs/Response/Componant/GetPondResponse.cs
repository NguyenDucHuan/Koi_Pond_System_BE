using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs.Response
{
    public class GetPondResponse
    {
        public int Id { get; set; }
        public string PondName { get; set; } = null!;
        public string? Decription { get; set; }
        public decimal? PondDepth { get; set; }
        public decimal? Area { get; set; }
        public string? Location { get; set; }
        public string? Shape { get; set; }
        public int AccountId { get; set; }
        public string? DesignImage { get; set; }
    }
    public class GetPondDetailResponse
    {
        public int Id { get; set; }
        public string PondName { get; set; } = null!;
        public string? Decription { get; set; }
        public decimal? PondDepth { get; set; }
        public decimal? Area { get; set; }
        public string? Location { get; set; }
        public string? Shape { get; set; }
        public int AccountId { get; set; }
        public string? DesignImage { get; set; }
        public int? SampleType { get; set; }
        public decimal? SamplePrice { get; set; }
        public List<GetPondOrderComponentResponse> Components { get; set; } = new List<GetPondOrderComponentResponse>();
    }
    public class GetPondOrderComponentResponse
    {
        public int ComponentId { get; set; }
        public string ComponentName { get; set; } = null!;
        public decimal Amount { get; set; }
    }
    public class PondDashBoard
    {
        public int AccountId { get; set; }
        public int PondId { get; set; }
        public string PondName { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public int Completion { get; set; }
    }
}