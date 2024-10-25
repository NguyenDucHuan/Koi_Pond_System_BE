using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Mappers;
using KPCOS.Api.Service.Interface;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Service.Implement
{
    public class Pondservice : IPondService
    {
        private readonly IPondRepository _pondRepository;
        private readonly IPondComponentRepository _pondComponentRepository;
        private readonly IComponentRepository _componentRepository;

        public Pondservice(IPondRepository pondRepository, IPondComponentRepository pondComponentRepository, IComponentRepository componentRepository)
        {
            _pondRepository = pondRepository;
            _pondComponentRepository = pondComponentRepository;
            _componentRepository = componentRepository;
        }

        public async Task DeletePondAsync(int pondId)
        {
            await _pondRepository.DeletePondAsync(pondId);
        }

        public async Task<List<GetPondDetailResponse>> GetPondsAsync()
        {
            var ponds = await _pondRepository.GetPondsAsync();
            var response = new List<GetPondDetailResponse>();
            foreach (var pond in ponds)
            {
                var res = pond.ToPondDetailResponse();
                foreach (var comp in res.Components)
                {
                    comp.ComponentName = await _componentRepository.GetComponentNameById(comp.ComponentId);
                }
                response.Add(res);
            }
            return response;
        }

        public async Task<GetPondDetailResponse> GetPondAsync(int pondId)
        {
            var pond = await _pondRepository.GetPondAsync(pondId);
            var res = pond.ToPondDetailResponse();
            foreach (var comp in res.Components)
            {
                comp.ComponentName = await _componentRepository.GetComponentNameById(comp.ComponentId);
            }
            return res;
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

        public async Task<List<GetPondDetailResponse>> GetPondsDisplayAsync()
        {
            var ponds = await _pondRepository.GetPondsAsync();
            var ress = ponds.Where(i => i.AccountId == null).ToList();
            var response = new List<GetPondDetailResponse>();
            foreach (var pond in ress)
            {
                var res = pond.ToPondDetailResponse();
                foreach (var comp in res.Components)
                {
                    comp.ComponentName = await _componentRepository.GetComponentNameById(comp.ComponentId);
                }
                response.Add(res);
            }
            return response;
        }
    }
}