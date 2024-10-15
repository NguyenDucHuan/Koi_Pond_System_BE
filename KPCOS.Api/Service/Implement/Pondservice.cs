using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Mappers;
using KPCOS.Api.Service.Interface;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Implement
{
    public class Pondservice : IPondService
    {
        private readonly IPondRepository _pondRepository;
        private readonly IPondComponentRepository _pondComponentRepository;


        public Pondservice(IPondRepository pondRepository, IPondComponentRepository pondComponentRepository)
        {
            _pondRepository = pondRepository;
            _pondComponentRepository = pondComponentRepository;
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

        public async Task<string> AddPondAsync(CreatePondRequest request)
        {
            if (request.AccountId == 0)
            {
                request.AccountId = null;
            }
            var (pond, pondComponents) = request.MapCreatePondRequestToPond();
            Console.WriteLine(pond);
            await _pondRepository.AddPondAsync(pond);
            foreach (var component in pondComponents)
            {
                component.PondId = pond.Id;
                await _pondComponentRepository.AddPondComponentAsync(component);
            }
            return "Pond added successfully";

        }
    }
}