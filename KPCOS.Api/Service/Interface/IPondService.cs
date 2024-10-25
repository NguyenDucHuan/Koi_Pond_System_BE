
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Interface
{
    public interface IPondService
    {
        Task<GetPondDetailResponse> GetPondAsync(int pondId);
        Task<List<GetPondDetailResponse>> GetPondsAsync();
        Task<string> AddPondAsync(CreatePondRequest request);
        Task DeletePondAsync(int pondId);
        Task<List<GetPondDetailResponse>> GetPondsDisplayAsync();
    }
}