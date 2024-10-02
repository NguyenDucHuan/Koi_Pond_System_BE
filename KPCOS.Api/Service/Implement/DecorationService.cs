using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Service.Interface;
using KPCOS.DataAccess.Repository.Implemnts;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Implement
{
    public class DecorationtService : IDecorationService
    {
        private readonly IDecorationRepository _decorationRepository;

        public DecorationtService(IDecorationRepository decorationRepository)
        {
            _decorationRepository = _decorationRepository;
        }

        public async Task<Decoration> AddDecorationAsync(Decoration decoration)
        {
            var check = await _decorationRepository.AddDecorationAsync(decoration);
            return decoration;
        }

        public async Task DeleteDecorationAsync(int decorationId)
        {
            await _decorationRepository.DeleteDecorationAsync(decorationId);
        }

        public async Task<List<Decoration>> GetDecorationsAsync()
        {
            return await _decorationRepository.GetDecorationsAsync();
        }

        public async Task<Decoration> UpdateDecorationAsync(Decoration decoration)
        {
            return await _decorationRepository.UpdateDecorationAsync(decoration);
        }

        public async Task<Decoration> GetDecorationAsync(int decorationId)
        {
            var decoration = await _decorationRepository.GetDecorationAsync(decorationId);
            if (decoration == null)
            {
                throw new ArgumentException("No decoration found");
            }
            return decoration;
        }

    }
}