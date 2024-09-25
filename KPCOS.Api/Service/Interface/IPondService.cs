using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Interface
{
    public interface IPondService
    {
        Task<Pond> GetPondAsync(int pondId);
        Task<List<Pond>> GetPondsAsync();

        Task<Pond> AddPondAsync(Pond pond);
        Task<Pond> UpdatePondAsync(Pond pond);
        Task DeletePondAsync(int pondId);
    }
}