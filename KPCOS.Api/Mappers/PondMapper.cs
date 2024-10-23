using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Models;

namespace KPCOS.Api.Mappers
{
    public static class PondMapper
    {
        public static (Pond, List<PondComponent>) MapCreatePondRequestToPond(this CreatePondRequest request)
        {
            var pondComponents = new List<PondComponent>();
            foreach (var component in request.ListComponent)
            {
                pondComponents.Add(new PondComponent
                {
                    PondId = 0,
                    ComponentId = component.ComponentId,
                    Amount = component.Amount
                });
            }
            return (new Pond
            {
                PondName = request.PondName,
                Decription = request.Decription,
                PondDepth = request.PondDepth,
                Area = request.Area,
                Location = request.Location,
                Shape = request.Shape,
                AccountId = request.AccountId,
            }, pondComponents);
        }
        public static GetPondDetailResponse ToPondDetailResponse(this Pond pond)
        {

            return new GetPondDetailResponse
            {
                AccountId = pond.AccountId ?? 0,
                Area = pond.Area ?? 0,
                Decription = pond.Decription,
                DesignImage = pond.DesignImage,
                Id = pond.Id,
                Location = pond.Location,
                PondDepth = pond.PondDepth ?? 0,
                PondName = pond.PondName,
                Shape = pond.Shape,
                SampleType = pond.SampleType,
                SamplePrice = pond.SamplePrice,
                Components = pond.PondComponents.Select(pc => new GetPondOrderComponentResponse
                {
                    ComponentId = pc.ComponentId,
                    Amount = pc.Amount
                }).ToList()
            };
        }
    }
}