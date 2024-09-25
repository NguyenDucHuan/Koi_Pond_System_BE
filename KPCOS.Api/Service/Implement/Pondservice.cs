using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Service.Interface;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Implement
{
    public class Pondservice : IPondService
    {
        private readonly IPondRepository _pondRepository;

        public Pondservice(IPondRepository pondRepository)
        {
            _pondRepository = pondRepository;
        }

        public async Task<Pond> AddPondAsync(Pond pond)
        {
            var check = await _pondRepository.AddPondAsync(pond);
            return pond;
        }

        public async Task DeletePondAsync(int pondId)
        {
            await _pondRepository.DeletePondAsync(pondId);
        }

        public async Task<List<Pond>> GetPondsAsync()
        {
            return await _pondRepository.GetPondsAsync();
        }

        public async Task<Pond> UpdatePondAsync(Pond pond)
        {
            return await _pondRepository.UpdatePondAsync(pond);
        }

        public async Task<Pond> GetPondAsync(int pondId)
        {
            return await _pondRepository.GetPondAsync(pondId);
        }
    }
}