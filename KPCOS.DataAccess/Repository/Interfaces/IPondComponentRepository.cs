using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Interfaces
{
    public interface IPondComponentRepository
    {
        Task<PondComponent> AddPondComponentAsync(PondComponent pondComponent);
        Task<PondComponent> GetPondComponentAsync(int pondComponentId);
        Task<PondComponent> UpdatePondComponentAsync(PondComponent pondComponent);
        Task DeletePondComponentAsync(int pondComponentId);
        Task<List<PondComponent>> GetPondComponentByPondIdAsync(int pondId);
        Task<List<PondComponent>> GetPondComponentByComponentIdAsync(int componentId);

    }
}