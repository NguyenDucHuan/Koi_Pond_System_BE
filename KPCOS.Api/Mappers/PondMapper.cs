using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}