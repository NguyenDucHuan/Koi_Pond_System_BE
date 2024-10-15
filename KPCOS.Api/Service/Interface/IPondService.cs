
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Interface
{
    public interface IPondService
    {
        Task<Pond> GetPondAsync(int pondId);
        Task<List<Pond>> GetPondsAsync();
        Task<string> AddPondAsync(CreatePondRequest request);
        Task<Pond> UpdatePondAsync(Pond pond);
        Task DeletePondAsync(int pondId);
    }
}