using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Interfaces
{
    public interface IPondRepository
    {
        Task<List<Pond>> GetPondsAsync();
        Task<Pond> GetPondAsync(int pondId);
        Task<Pond> AddPondAsync(Pond pond);
        Task<Pond> UpdatePondAsync(Pond pond);
        Task DeletePondAsync(int pondId);
    }
}