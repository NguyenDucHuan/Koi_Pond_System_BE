using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Interface
{
    public interface IDecorationService
    {
        Task<Decoration> GetDecorationAsync(int decorationId);
        Task<List<Decoration>> GetDecorationsAsync();

        Task<Decoration> AddDecorationAsync(Decoration decoration);
        Task<Decoration> UpdateDecorationAsync(Decoration decoration);
        Task DeleteDecorationAsync(int decorationId);
    }
}