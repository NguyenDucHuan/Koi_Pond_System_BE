using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Interfaces
{
    public interface IDecorationTypeRepository
    {
        Task<List<DecorationType>> GetDecorationTypesAsync();
        Task<DecorationType> GetDecorationTypeAsync(int decorationTypeId);
        Task<DecorationType> AddDecorationTypeAsync(DecorationType decorationType);
        Task<DecorationType> UpdateDecorationTypeAsync(DecorationType decorationType);
        Task DeleteDecorationTypeAsync(int decorationTypeId);
    }
}