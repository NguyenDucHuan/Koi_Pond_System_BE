using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Interfaces
{
    public interface IDecorationRepository
    {
        Task<List<Decoration>> GetDecorationsAsync();
        Task<Decoration> GetDecorationAsync(int decorationId);
        Task<Decoration> AddDecorationAsync(Decoration decoration);
        Task<Decoration> UpdateDecorationAsync(Decoration decoration);
        Task DeleteDecorationAsync(int decorationId);
    }
}